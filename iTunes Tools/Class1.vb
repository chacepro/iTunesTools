Imports Microsoft.VisualBasic

Public Class ToolsClass
    '  iTunesSongSync 
    '  By: Chace Prochazka
    '  November 2008
    '-----|  Define Variables
    Dim ArgObj
    Dim gSourcePath, gobjFso, gobjShell
    Dim newPath, cobjFso, cobjShell
    Dim dPath, dobjFso, dobjShell
    Dim objSubFolder, objFolder, objFileCol, objFolderCol
    Dim cobjSubFolder, cobjFolder, cobjFileCol, cobjFolderCol
    Dim dobjSubFolder, dobjFolder, dobjFileCol, dobjFolderCol
    Dim zobjFolder, zobjFileCol
    Dim zobjFso
    Dim intFileCount, intFolderCount
    Dim t1, t2, t3, t4, t5
    Dim file, objApp
    '-----|  Constants for the Search Capabilities...
    Const ITPlaylistSearchFieldAll = 0 ' Search all fields of each track.
    Const ITPlaylistSearchFieldVisible = 1 ' Search only the fields with columns that are currently visible in the display for the playlist. Note that song name, artist, album, and composer will always be searched, even if these columns are not visible.
    Const ITPlaylistSearchFieldArtists = 2 ' Search only the artist field of each track.
    Const ITPlaylistSearchFieldAlbums = 3 ' Search only the album field of each track.
    Const ITPlaylistSearchFieldComposers = 4 ' Search only the composer field of each track.
    Const ITPlaylistSearchFieldSongNames = 5 ' Search only the song name field of each track.
    Const ITTrackKindFile = 1
    '-----|   Flags for the options parameter
    Const BIF_returnonlyfsdirs = &H1
    Const BIF_dontgobelowdomain = &H2
    Const BIF_statustext = &H4
    Const BIF_returnfsancestors = &H8
    Const BIF_editbox = &H10
    Const BIF_validate = &H20
    Const BIF_browseforcomputer = &H1000
    Const BIF_browseforprinter = &H2000
    Const BIF_browseincludefiles = &H4000


    Function sds()

        'Do a search for songs with the same name
        colTracksSrch = objLibrary.Search(objTrack.Name, ITPlaylistSearchFieldSongNames)
        objlog.WriteLine("     (Matches: " & colTracksSrch.count & ")")
        ' If more than one song by the same name is found in the search
        If colTracksSrch.count > 1 Then
            ' Loop through all the search results
            For Each objTrackSrch In colTracksSrch
                If objTrackSrch.Kind = ITTrackKindFile Then
                    objlog.WriteLine("     Track:    " & objTrack.Name & "       " & objTrack.Album)
                    objlog.WriteLine("     TrackSrch:" & objTrackSrch.Name & "       " & objTrackSrch.Album)
                    ' Check to make sure the Name and Albums are the same..
                    If (objTrack.Name = objTrackSrch.Name) And (objTrack.Album = objTrackSrch.Album) Then
                        ' the size and/or qualitly of the original file is smaller delete it and exit loop
                        objlog.WriteLine("     ***** Match Made *****")
                        objlog.WriteLine("         objTrack:     " & objTrack.SampleRate & "     " & objTrack.Size & "     " & objTrack.Location)
                        objlog.WriteLine("         objTrackSrch: " & objTrackSrch.SampleRate & "     " & objTrackSrch.Size & "     " & objTrackSrch.Location)
                        If (objTrack.SampleRate < objTrackSrch.SampleRate) Or (objTrack.Size < objTrackSrch.Size) Then
                            objlog.WriteLine("         ***** Deleted objTrack because the objTrackSrch file was better quality *****")
                            If fso.fileexists(objTrack.Location) Then
                                fso.deletefile(objTrack.Location, True)
                            End If
                            objtrack.delete()
                            Exit For
                        End If
                        ' if this is a duplicate file with all the same atributes with the exception of location.
                        If (objTrack.SampleRate = objTrackSrch.SampleRate) And (objTrack.Size = objTrackSrch.Size) And (objTrack.Location <> objTrackSrch.Location) Then
                            objlog.WriteLine("         ***** Deleted objTrackSrch because it is a duplicate of the objTrack *****")
                            If fso.fileexists(objTrackSrch.Location) Then
                                fso.deletefile(objTrackSrch.Location, True)
                            End If
                            objtrackSrch.delete()
                        End If
                    End If
                Else
                    objlog.WriteLine("     " & objTrack.Name & " is not a track")
                End If
            Next
        End If
        'Destroy the search objects
        objTrackSrch = Nothing
        colTracksSrch = Nothing
    End Function

    '-----|  Check iTunes: Returns true if iTunes object is found
    Function CheckiTunes()
        objApp = CreateObject("iTunes.Application")
        If isObject(objApp) Then
            CheckiTunes = True
        Else
            WScript.echo("Cannot create iTunes object. Either iTunes isn't updated or you don't have it installed.")
        End If
    End Function

    '-----|  Make iTunes list: List all iTunes song titles in a list
    Function MakeList()
        Dim fso, objLog, objApp, objLibrary, colTracks, objTrack
        fso = CreateObject("Scripting.FileSystemObject")
        objLog = fso.OpenTextFile("c:\iTunesSync.log", 8, True)
        'Check to make sure iTunes is available
        If CheckiTunes = True Then
            objApp = CreateObject("iTunes.Application")
            objLibrary = objApp.LibraryPlaylist
            colTracks = objLibrary.Tracks

            Wscript.echo("Script is starting... Creating list.")

            ' Loop through all the tracks..
            For Each objTrack In colTracks
                If objTrack.Kind = ITTrackKindFile Then
                    objlog.WriteLine(objtrack.location)
                End If
            Next

            Wscript.echo("List was made.")
        Else

        End If

    End Function

    '-----|  Browse for a directory: Prompts user for a directory. Returns a path chosen
    Function BrowseForFolder(ByVal title, ByVal flag, ByVal dir)
        On Error Resume Next
        Dim oShell, oItem, tmp
        '-----|   Create WshShell object.
        oShell = WScript.CreateObject("Shell.Application")
        '-----|   Invoke Browse For Folder dialog box.
        oItem = oShell.BrowseForFolder(&H0, title, flag, dir)
        If Err.Number <> 0 Then
            If Err.Number = 5 Then
                BrowseForFolder = "-5"
                Err.Clear()
                oShell = Nothing
                oItem = Nothing
                Exit Function
            End If
        End If
        '-----|   Now we try to retrieve the full path.
        BrowseForFolder = oItem.ParentFolder.ParseName(oItem.Title).Path
        '-----|   Handling: Cancel button and selecting a drive
        If Err <> 0 Then
            If Err.Number = 424 Then           '-----|   Handle Cancel button.
                BrowseForFolder = "-1"
            Else
                Err.Clear()
                '-----|   Handle situation in which user selects a drive.
                '-----|   Extract drive letter from the title--first search
                '-----|   for a colon (:).
                tmp = InStr(1, oItem.Title, ":")
                If tmp > 0 Then           '-----|   A : is found; use two 
                    '-----|   characters and add \.
                    BrowseForFolder = _
                        Mid(oItem.Title, (tmp - 1), 2) & "\"
                End If
            End If
        End If
        oShell = Nothing
        oItem = Nothing
        On Error GoTo 0
    End Function

    '-----|  Check for children directories: Checks to see if there are children folders in another folder, returns true if there are
    Function CheckForChildren(ByVal gpath)
        cobjShell = WScript.CreateObject("WScript.Shell")
        cobjFso = WScript.CreateObject("Scripting.FileSystemObject")
        '-----|  Verify path variables
        newPath = VerifyPath(gpath)
        '-----|  Check for children
        cobjFolder = cobjFso.GetFolder(newPath)
        cobjFolderCol = cobjFolder.SubFolders
        If cobjFolderCol.count > 0 Then
            CheckForChildren = True
        Else
            CheckForChildren = False
        End If
        'Set cobjFileCol = cobjFolder.Files
    End Function

    '-----|  Get next level: Counts files and folders in the given path
    Function GetNextLevel(ByVal cpath)
        '-----|  Create objects to access file system
        dobjShell = WScript.CreateObject("WScript.Shell")
        dobjFso = WScript.CreateObject("Scripting.FileSystemObject")
        '-----|  Verify path variables
        dPath = VerifyPath(cpath)
        '-----|  Get counts
        dobjFolder = dobjFso.GetFolder(dPath)
        dobjFolderCol = dobjFolder.SubFolders
        dobjFileCol = dobjFolder.Files
        '-----|   Count files in root folder
        For Each t3 In dobjFileCol
            If Not Err.Number = 0 Then
                Call ErrHandler(t3.Name, Err.Number, Err.Description)
            Else
                intFileCount = intFileCount + 1
            End If
        Next
        '-----|    Count folders in root folder
        For Each t4 In dobjFolderCol
            If Not Err.Number = 0 Then
                Call ErrHandler(t4.Name, Err.Number, Err.Description)
            Else
                intFolderCount = intFolderCount + 1
                If CheckForChildren(t4.path) = True Then
                    GetNextLevel(t4.path)
                Else
                    CountSingleDir(t4.path)
                End If
            End If
        Next
        '-----|  Clean up and exit
        dobjShell = Nothing
        dobjFso = Nothing
        dobjFolder = Nothing
        dobjFolderCol = Nothing
        dobjFileCol = Nothing
        t3 = Nothing
        t4 = Nothing
    End Function

    '-----|  Count single folder files: Counts the files in the given path
    Function CountSingleDir(ByVal myPath)
        zobjFso = WScript.CreateObject("Scripting.FileSystemObject")
        zobjFolder = zobjFso.GetFolder(myPath)
        zobjFileCol = zobjFolder.Files
        For Each t5 In zobjFileCol
            If Not Err.Number = 0 Then
                Call ErrHandler(t5.Name, Err.Number, Err.Description)
            Else
                intFileCount = intFileCount + 1
            End If
        Next
        zobjFso = Nothing
        zobjFolder = Nothing
        zobjFileCol = Nothing
        zobjFolder = Nothing
        zobjFileCol = Nothing
    End Function

    '-----|  Loop through all files and directories: Loops through all folders and subfolders counting all files
    Function LoopThroughFiles(ByVal mpath)
        '-----|  Create objects to access file system
        gobjShell = WScript.CreateObject("WScript.Shell")
        gobjFso = WScript.CreateObject("Scripting.FileSystemObject")
        '-----|  Verify path variables
        gSourcePath = VerifyPath(mpath)
        '-----|  Count Section
        objFolder = gobjFso.GetFolder(gSourcePath)
        objFolderCol = objFolder.SubFolders
        objFileCol = objFolder.Files
        '-----|   Count files in root folder
        For Each t1 In objFileCol
            If Not Err.Number = 0 Then
                Call ErrHandler(t1.Name, Err.Number, Err.Description)
            Else
                intFileCount = intFileCount + 1
            End If
        Next
        '-----|    Count folders in root folder
        For Each t2 In objFolderCol
            If Not Err.Number = 0 Then
                Call ErrHandler(t2.Name, Err.Number, Err.Description)
            Else
                intFolderCount = intFolderCount + 1
                If CheckForChildren(t2.path) = True Then
                    GetNextLevel(t2.path)
                Else
                    CountSingleDir(t2.path)
                End If
            End If
        Next
        '-----|  Issue outcome
        MsgBox("File Count: " & CStr(intFileCount) & vbCrLf & "Folder Count: " & CStr(intFolderCount))
        '-----|  Clean up and exit
        gobjFso = Nothing
        gobjShell = Nothing
        ArgObj = Nothing
        objFileCol = Nothing
    End Function

    '-----|  Handle any errors
    Function ErrHandler(ByVal pstrObjName, ByVal pintErrNo, ByVal pstrErrDesc)
        msgbox("An error occurred in Archiver.vbs on " & pstrObjName & ": " & pintErrNo & " Desc: " & pstrErrDesc)
        Err.Clear()
    End Function

    '-----|  Verify that a path exists: Checks the given path
    Function VerifyPath(ByVal strPathName)
        '-----|  Verify that a \ is at the end of the path variables
        If Not Right(strPathName, 1) = "\" Then
            strPathName = strPathName & "\"
        End If
        '-----|  Verify paths exist
        If Not gobjFso.FolderExists(strPathName) Then
            msgbox("Source Path " & strPathName & " does not exist.")
            WScript.Quit(12)     '-----|  Critical error for job.  Exit the script.
        End If
        '-----|  Return verified pathname
        VerifyPath = strPathName
    End Function

End Class
