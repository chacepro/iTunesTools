Imports Microsoft.VisualBasic
Imports System.Net.NetworkCredential
Imports System.Threading

    Public Class ToolsClass
        '  iTunesSongSync 
        '  By: Chace Prochazka
        '  November 2008
        '-----|  Define Variables
        '-----|  Constants for the Search Capabilities...
        '-----|   Flags for the options parameter
        'Const ITPlaylistSearchFieldAll = 0 ' Search all fields of each track.
        'Const ITPlaylistSearchFieldVisible = 1 ' Search only the fields with columns that are currently visible in the display for the playlist. Note that song name, artist, album, and composer will always be searched, even if these columns are not visible.
        'Const ITPlaylistSearchFieldArtists = 2 ' Search only the artist field of each track.
        'Const ITPlaylistSearchFieldAlbums = 3 ' Search only the album field of each track.
        'Const ITPlaylistSearchFieldComposers = 4 ' Search only the composer field of each track.
        'Const BIF_returnonlyfsdirs = &H1
        'Const BIF_dontgobelowdomain = &H2
        'Const BIF_statustext = &H4
        'Const BIF_returnfsancestors = &H8
        'Const BIF_editbox = &H10
        'Const BIF_validate = &H20
        'Const BIF_browseforcomputer = &H1000
        'Const BIF_browseforprinter = &H2000
    'Const BIF_browseincludefiles = &H4000
    Dim lst As New Collection

    Public Delegate Sub SetTextCallback(ByVal [text] As String)

    Public Sub SetLB(ByVal [text] As String)
        Dim ctrl = frmClean.lstOutput
        If ctrl.InvokeRequired Then
            ' It's on a different thread, so use Invoke.
            Dim d As New SetTextCallback(AddressOf SetLB)
            ctrl.Invoke(d, New Object() {[text]})
        Else
            ' It's on the same thread, no need for Invoke.
            Try
                ctrl.Items.Insert(0, [text])
                ctrl.Refresh()
            Catch ex As Exception
                MsgBox("Error: " & ex.ToString)
            End Try
        End If

    End Sub

        Function CheckFileInList(ByVal cpath)
            CheckFileInList = False
            ' Loop through all the tracks..
            If cpath = Nothing Then
                CheckFileInList = False
            Else
            If lst.Contains(cpath.ToString) Then
                CheckFileInList = True
            End If
            End If
        End Function

    Sub AddLeftOvers(ByVal lstTemp)
        Dim objApp, objLibrary, objlog
        objApp = CreateObject("iTunes.Application")
        objLibrary = objApp.LibraryPlaylist
        objlog = frmClean.lstOutput
        'frmClean.prgBar.Value = frmClean.prgBar.Value - lst.Count
        MsgBox(lstTemp.count)
        For Each file As Object In lstTemp
            'frmClean.SetStatus("*** Adding File: " & file & " ***")
        Next
        lstTemp.Clear()
        'frmClean.lblLstCount.Text = frmClean.lstTemp.Items.Count
    End Sub

    Sub RemoveDupes(ByVal lstTemp As Collection)
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
        objlog = frmClean.lstOutput
        intCount = colTracks.Count
        frmClean.prgBar.Maximum = intCount
        frmClean.prgBar.Value = 0
        'frmClean.SetStatus("Running: Searching file " & intCurrent & " of " & intCount.ToString & " files...")
        fso = CreateObject("Scripting.FileSystemObject")
        ' Loop through all the tracks..
        SetLB("Firing up!!")
        For Each objTrack In colTracks
            'frmClean.SetStatus("Running: Searching file " & intCurrent & " of " & intCount.ToString & " files...")
            If frmClean.chkNewSongs.Checked = True Then
                If CheckFileInList(objTrack.Location) = True Then
                    lstTemp.Remove(objTrack.Location)
                End If
            End If
            If objTrack.Kind = ITTrackKindFile Then
                'objlog.Items.Insert(0, objTrack.Name & " (" & objTrack.location & ")")
                'check to see if it is an orpan entry
                If objTrack.Location = "" Then
                    If frmClean.chkOrphans.Checked = True Then
                        frmClean.SetLB("*** Orphan file found and deleted: " & objTrack.Name & " ***")
                        'objlog.Items.Insert(0, "*** Orphan file found and deleted: " & objTrack.Name & " ***")
                        Try
                            objTrack.delete()
                        Catch ex2 As Exception
                            frmClean.SetLB("*** Error Caught: " & ex2.Message & " -- Playlist SKIPPED!! ***")
                        End Try
                        intOrphans = intOrphans + 1
                    Else
                        frmClean.SetLB("*** Orphan file found: " & objTrack.Name & " ***")
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
                                    ' Check to make sure the Name and Albums are the same..
                                    If (objTrack.Name = objTrackSrch.Name) And (objTrack.Album = objTrackSrch.Album) Then
                                        ' the size and/or qualitly of the original file is smaller delete it and exit loop
                                        'objlog.Items.Insert(0, "*** Match Made *****")
                                        'objlog.Items.Insert(0, "    Track: " & objTrack.SampleRate & " - " & objTrack.Size & " - " & objTrack.Location)

                                        If (objTrack.SampleRate < objTrackSrch.SampleRate) Or (objTrack.Size < objTrackSrch.Size) Then
                                            frmClean.SetLB("*** Deleted " & objTrack.Name & " because the other file was better quality ***")
                                            If (objTrack.location = Nothing) Then
                                                'frmClean.prgBar.Value = intCount
                                                'frmClean.btnRun.Enabled = False
                                                'Exit For
                                            Else
                                                If fso.fileexists(objTrack.Location) Then
                                                    If frmClean.chkDupilcates.Checked = True Then
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
                                            frmClean.SetLB("*** Deleted " & objTrackSrch.name & " because it is a duplicate ***")
                                            If objTrackSrch.Location = Nothing Then
                                                frmClean.SetLB("*** Skipped without location ***")
                                            Else
                                                If frmClean.chkDupilcates.Checked = True Then
                                                    My.Computer.FileSystem.DeleteFile(objTrack.Location)
                                                    intDups = intDups + 1
                                                End If
                                            End If
                                            objTrackSrch.delete()
                                        End If
                                    End If
                                Else
                                    frmClean.SetLB("*** " & objTrack.Name & " is not a track")
                                End If
                            Next
                        End If
                    Catch ex As Exception
                        frmClean.SetLB("*** Error Caught: " & ex.Message & " -- SKIPPED!! ***")
                    End Try

                    'Destroy the search objects
                    objTrackSrch = Nothing
                    colTracksSrch = Nothing
                End If
            End If
            intCurrent = intCurrent + 1
            frmClean.prgBar.PerformStep()
        Next


        AddLeftOvers(lstTemp)
        intCountDone = colTracks.Count

        'Destroy the objects 
        objApp = Nothing
        objTrack = Nothing
        objLibrary = Nothing
        colTracks = Nothing
        objlog = Nothing
        fso = Nothing

        intAdded = (intCountDone - intCount)
        'frmClean.SetStatus("Done searching all " + intCount.ToString + " files!")
        MsgBox(lstTemp.Count)
        MsgBox("Done!" & vbCrLf & "Duplicates found and removed: " & intDups & vbCrLf & "Orphaned files found and removed: " & intOrphans & vbCrLf & "New files added: " & intAdded)

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
            'set prog bar scale
            'frmClean.prgBar.PerformStep()
            extString = Right(file, 4)
            If extString = ".ini" Or extString = ".jpg" Or extString = ".itc" Or extString = ".txt" Or extString = "bite" Or extString = ".xml" Or extString = ".itl" Or Right(extString, 3) = ".db" Then

            Else
                lst.Add(file)
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

        MapDirectory = lst
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
        If Not Right(strPathName, 1) = "\" Then
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
        If Not Right(strPathName, 1) = "\" Then
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

End Class
