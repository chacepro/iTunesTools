Imports Microsoft.VisualBasic
Imports System.Net.NetworkCredential
Imports System.Threading

Public Class frmClean

    Public newTemp As New ArrayList

    Function CheckFileInList(ByVal cpath)
        CheckFileInList = False
        ' Loop through all the tracks..
        If cpath = Nothing Then
            CheckFileInList = False
        Else
            For Each tmpObj As String In newTemp
                'MsgBox("cpath: " & cpath & vbCrLf & _
                '       "coll: " & tmpObj.ToString)
                If tmpObj.ToString = cpath Then
                    CheckFileInList = True
                    Exit For
                End If
            Next tmpObj
        End If
    End Function

    Sub AddLeftOvers(ByVal lstTemp)
        Dim objApp, objLibrary
        objApp = CreateObject("iTunes.Application")
        objLibrary = objApp.LibraryPlaylist
        'Me.prgBar.Value = Me.prgBar.Value - lst.Count
        MsgBox(lstTemp.count)
        For Each file As Object In lstTemp
            SetLB("*** Adding File: " & file & " ***")
            objLibrary.AddFile(file.ToString)
        Next
        lstTemp.Clear()
    End Sub

    Sub RemoveDupes(ByVal lstTemp As ArrayList)
        Dim objApp, objLibrary, colTracks, colTracksSrch, fso, objlog, objTrackSrch, objTrack, intCount
        Dim intOrphans, intDups, intAdded, intCurrent, intCountDone
        Const ITTrackKindFile = 1
        Const ITPlaylistSearchFieldSongNames = 5
        ' Create the iTunes Objects and get all the tracks.
        intOrphans = 0
        intDups = 0
        intAdded = 0
        intCurrent = 0
        objApp = CreateObject("iTunes.Application")
        objLibrary = objApp.LibraryPlaylist
        'Check to make sure library is an object before proceding
        If objLibrary.GetType.ToString <> "System.__ComObject" Then
            MsgBox("iTunes Library not found!!")
            Exit Sub
        End If
        colTracks = objLibrary.Tracks
        intCount = colTracks.Count
        SetLB("Found " & intCount & " tracks in iTunes...")
        SetLB("Found " & lstTemp.Count & " tracks in your music directory...")
        fso = CreateObject("Scripting.FileSystemObject")
        ' Loop through all the tracks..
        For Each objTrack In colTracks
            'SetLB("Running: Searching file " & intCurrent & " of " & intCount.ToString & " files...")
            If chkNewSongs.Checked = True Then
                Do Until CheckFileInList(UCase(objTrack.Location)) = False
                    newTemp.Remove(UCase(objTrack.Location))
                Loop
            End If
            If objTrack.Kind = ITTrackKindFile Then
                'SetLB(objTrack.Name & " (" & objTrack.location & ")")
                'check to see if it is an orpan entry
                If objTrack.Location = "" Then
                    If chkOrphans.Checked = True Then
                        SetLB("*** Orphan file found and deleted: " & objTrack.Name & " ***")
                        Try
                            objTrack.delete()
                        Catch ex2 As Exception
                            SetLB("*** Error Caught: " & ex2.Message & " -- Playlist SKIPPED!! ***")
                        End Try
                        intOrphans = intOrphans + 1
                    Else
                        SetLB("*** Orphan file found: " & objTrack.Name & " ***")
                    End If

                Else
                    'Do a search for songs with the same name
                    Try
                        colTracksSrch = objLibrary.Search(objTrack.Name, ITPlaylistSearchFieldSongNames)
                        'objlog.Items.Insert(0, "     (Matches: " & colTracksSrch.count & ")")
                        ' If more than one song by the same name is found in the search
                        If colTracksSrch.count > 1 Then
                            ' Loop through all the search results
                            For Each objTrackSrch In colTracksSrch
                                If objTrackSrch.Kind = ITTrackKindFile Then
                                    'objlog.Items.Insert(0, "     Track:    " & objTrack.Name & "       " & objTrack.Album)
                                    'objlog.Items.Insert(0, "     TrackSrch:" & objTrackSrch.Name & "       " & objTrackSrch.Album)
                                    ' Check to make sure the Name and Albums are the sa.
                                    If (objTrack.Name = objTrackSrch.Name) And (objTrack.Album = objTrackSrch.Album) Then
                                        ' the size and/or qualitly of the original file is smaller delete it and exit loop
                                        'objlog.Items.Insert(0, "*** Match Made *****")
                                        'objlog.Items.Insert(0, "    Track: " & objTrack.SampleRate & " - " & objTrack.Size & " - " & objTrack.Location)

                                        If (objTrack.SampleRate < objTrackSrch.SampleRate) Or (objTrack.Size < objTrackSrch.Size) Then
                                            SetLB("*** Deleted " & objTrack.Name & " because the other file was better quality ***")
                                            If (objTrack.location = Nothing) Then
                                                'prgBar.Value = intCount
                                                'btnRun.Enabled = False
                                                'Exit For
                                            Else
                                                If fso.fileexists(objTrack.Location) Then
                                                    If chkDupilcates.Checked = True Then
                                                        My.Computer.FileSystem.DeleteFile(objTrack.Location)
                                                        intDups = intDups + 1
                                                    End If
                                                End If
                                                objTrack.delete()
                                                Exit For
                                            End If
                                        End If
                                        ' if this is a duplicate file with all the same atributes with the exception of location.
                                        If (objTrack.SampleRate = objTrackSrch.SampleRate) And (objTrack.Size = objTrackSrch.Size) And (objTrack.Location <> objTrackSrch.Location) Then
                                            SetLB("*** Deleted " & objTrackSrch.name & " because it is a duplicate ***")
                                            If objTrackSrch.Location = Nothing Then
                                                SetLB("*** Skipped without location ***")
                                            Else
                                                If chkDupilcates.Checked = True Then
                                                    My.Computer.FileSystem.DeleteFile(objTrack.Location)
                                                    intDups = intDups + 1
                                                End If
                                            End If
                                            objTrackSrch.delete()
                                        End If
                                    End If
                                Else
                                    SetLB("*** " & objTrack.Name & " is not a track")
                                End If
                            Next
                        End If
                    Catch ex As Exception
                        SetLB("*** Error Caught: " & ex.Message & " -- SKIPPED!! ***")
                    End Try

                    'Destroy the search objects
                    objTrackSrch = Nothing
                    colTracksSrch = Nothing
                End If
            End If
            intCurrent = intCurrent + 1
            SetProg((intCurrent / intCount) * 100)
        Next

        AddLeftOvers(newTemp)
        intCountDone = colTracks.Count

        'Destroy the objects 
        objApp = Nothing
        objTrack = Nothing
        objLibrary = Nothing
        colTracks = Nothing
        objlog = Nothing
        fso = Nothing

        intAdded = (intCountDone - intCount)
        SetLB("Done searching all " + intCount.ToString + " songs!")
        SetLB("Done!")
        SetLB("Duplicates found and removed: " & intDups)
        SetLB("Orphaned files found and removed: " & intOrphans)
        SetLB("New files added: " & intAdded)

    End Sub

    '-----|  Check iTunes: Returns true if iTunes object is found
    Function CheckiTunes()
        Dim objApp As Object
        objApp = CreateObject("iTunes.Application")
        If (objApp.GetType.Name = "__ComObject") Then
            CheckiTunes = True
        Else
            MsgBox("Cannot create iTunes object. Either iTunes isn't updated or you don't have it installed.")
            MsgBox(objApp.GetType.Name)
            CheckiTunes = False
        End If
    End Function


    Function MapDirectory(ByVal dir)
        Dim extString
        For Each file In My.Computer.FileSystem.GetFiles(dir)
            extString = Microsoft.VisualBasic.Right(file, 4)
            If extString = ".ini" Or extString = ".jpg" Or extString = ".itc" Or extString = ".txt" Or extString = "bite" Or extString = ".xml" Or extString = ".itl" Or Microsoft.VisualBasic.Right(extString, 3) = ".db" Then
                'skip because it's not a music file
            Else
                newTemp.Add(UCase(file))
            End If
        Next file

        ' Search child directories.
        For Each folder In My.Computer.FileSystem.GetDirectories(dir)
            MapDirectory(folder)
            For Each folder2 In My.Computer.FileSystem.GetDirectories(folder)
                MapDirectory(folder2)
                For Each folder3 In My.Computer.FileSystem.GetDirectories(folder2)
                    MapDirectory(folder3)
                Next folder3
            Next folder2
        Next folder

        MapDirectory = newTemp
    End Function

    '-----|  Handle any errors
    Sub ErrHandler(ByVal pstrObjName, ByVal pintErrNo, ByVal pstrErrDesc)
        MsgBox("An error occurred in Archiver.vbs on " & pstrObjName & ": " & pintErrNo & " Desc: " & pstrErrDesc)
        Err.Clear()
    End Sub

    '-----|  Verify that a path exists: Checks the given path
    Function VerifyPath(ByVal strPathName)
        Dim gobjFso
        gobjFso = CreateObject("Scripting.FileSystemObject")
        '-----|  Verify that a \ is at the end of the path variables
        If Not Microsoft.VisualBasic.Right(strPathName, 1) = "\" Then
            strPathName = strPathName & "\"
        End If
        '-----|  Verify paths exist
        If Not gobjFso.FolderExists(strPathName) Then
            MsgBox("Source Path " & strPathName & " does not exist.")
            VerifyPath = False
        Else
            VerifyPath = True
        End If

    End Function

    '-----|  Verify that a path exists: Checks the given path
    Function VerifyPath2(ByVal strPathName)
        Dim gobjFso
        gobjFso = CreateObject("Scripting.FileSystemObject")
        '-----|  Verify that a \ is at the end of the path variables
        If Not Microsoft.VisualBasic.Right(strPathName, 1) = "\" Then
            strPathName = strPathName & "\"
        End If
        '-----|  Verify paths exist
        If Not gobjFso.FolderExists(strPathName) Then
            MsgBox("Source Path " & strPathName & " does not exist.")
            VerifyPath2 = strPathName
        Else
            VerifyPath2 = strPathName
        End If

    End Function

    Public Delegate Sub SetTextCallback(ByVal [text] As String)

    Public Sub SetLB(ByVal [text] As String)
        Dim ctrl = Me.lstOutput
        If ctrl.InvokeRequired Then
            ' It's on a different thread, so use Invoke.
            Dim d As New SetTextCallback(AddressOf SetLB)
            ctrl.Invoke(d, New Object() {[text]})
        Else
            ' It's on the same thread, no need for Invoke.
            Try
                ctrl.Items.Insert(0, [text])
            Catch ex As Exception
                MsgBox("Error: " & ex.ToString)
            End Try
        End If

    End Sub

    Public Sub SetProg(ByVal [text] As String)
        Dim ctrl = Me.prgBar
        If ctrl.InvokeRequired Then
            ' It's on a different thread, so use Invoke.
            Dim d As New SetTextCallback(AddressOf SetProg)
            ctrl.Invoke(d, New Object() {[text]})
        Else
            ' It's on the same thread, no need for Invoke.
            ctrl.Value = [text]
        End If
    End Sub

    Private Sub Timer3_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'lblListCount.Text = 5
    End Sub

    Private Sub btnRun_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRun.Click
        'Assign status and disable controls
        chkDupilcates.Enabled = False
        chkNewSongs.Enabled = False
        chkOrphans.Enabled = False
        btnRun.Enabled = False
        txtPath.Enabled = False
        btnDialog.Enabled = False

        If chkNewSongs.Checked = False Then
            bgDupes.RunWorkerAsync()
            'Option to add songs that havent
        ElseIf chkNewSongs.Checked = True Then
            If txtPath.Text = "" Then
                MsgBox("You need to choose a path for your music folder in order to add any new songs. Otherwise uncheck the option to add new files")
            ElseIf txtPath.Text.Length > 0 Then
                bgFiles.RunWorkerAsync()
            End If
        End If


    End Sub

    Private Sub btnDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDialog.Click
        fbdMain.ShowDialog()
        txtPath.Text = fbdMain.SelectedPath
    End Sub

    Private Sub Timer3_Tick_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer3.Tick
        If (newTemp.Count()) = vbNull Then
            lblStatus.Text = "0 Files"
        Else
            lblStatus.Text = newTemp.Count()
        End If

    End Sub

    Private Sub bgDupes_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgDupes.DoWork
        Dim dumLst
        dumLst = New Collection
        'check for dupes
        SetLB("Removing duplicates.....")
        RemoveDupes(dumLst)
    End Sub

    Private Sub bgFiles_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgFiles.DoWork
        Dim tmpC = 0
        SetLB("Mapping music directory...")
        newTemp = (MapDirectory(VerifyPath2(txtPath.Text)))
        SetLB("***  Found " & CStr(newTemp.Count) & " files.")
        SetLB("***  Removing duplicates...")
        RemoveDupes(newTemp)
    End Sub

    Private Sub bgDupes_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgDupes.RunWorkerCompleted
        'Assign status and enable controls
        chkNewSongs.Enabled = True
        chkOrphans.Enabled = True
        btnRun.Enabled = True
        txtPath.Enabled = True
        btnDialog.Enabled = True
        chkDupilcates.Enabled = True
    End Sub

    Private Sub bgFiles_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgFiles.RunWorkerCompleted
        'Assign status and enable controls
        chkNewSongs.Enabled = True
        chkOrphans.Enabled = True
        btnRun.Enabled = True
        txtPath.Enabled = True
        btnDialog.Enabled = True
        chkDupilcates.Enabled = True
    End Sub
End Class