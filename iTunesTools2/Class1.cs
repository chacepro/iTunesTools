using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


 public class ToolsClass
 {
     // iTunesSongSync
     // By: Chace Prochazka
     // November 2008
     //-----| Define Variables
     //-----| Constants for the Search Capabilities...
     //-----| Flags for the options parameter
     //Const ITPlaylistSearchFieldAll = 0 ' Search all fields of each track.
     //Const ITPlaylistSearchFieldVisible = 1 ' Search only the fields with columns that are currently visible in the display for the playlist. Note that song name, artist, album, and composer will always be searched, even if these columns are not visible.
     //Const ITPlaylistSearchFieldArtists = 2 ' Search only the artist field of each track.
     //Const ITPlaylistSearchFieldAlbums = 3 ' Search only the album field of each track.
     //Const ITPlaylistSearchFieldComposers = 4 ' Search only the composer field of each track.
     //Const BIF_returnonlyfsdirs = &H1
     //Const BIF_dontgobelowdomain = &H2
     //Const BIF_statustext = &H4
     //Const BIF_returnfsancestors = &H8
     //Const BIF_editbox = &H10
     //Const BIF_validate = &H20
     //Const BIF_browseforcomputer = &H1000
     //Const BIF_browseforprinter = &H2000
     //Const BIF_browseincludefiles = &H4000
    
     public object CheckFileInList(object cpath)
     {
         object functionReturnValue = null;
         functionReturnValue = false;
         // Loop through all the tracks..
         if (cpath == null) {
             functionReturnValue = false;
         }
         else {
             if (frmMain.lstTemp.Items.Contains(cpath.ToString)) {
                 functionReturnValue = true;
             }
         }
         return functionReturnValue;
     }
    
     public void AddLeftOvers()
     {
         var objApp = null, objLibrary = null, objlog = null;
         objApp = Interaction.CreateObject("iTunes.Application");
         objLibrary = objApp.LibraryPlaylist;
         objlog = frmMain.lstCommand;
         frmMain.prgBar.Value = frmMain.prgBar.Value - frmMain.lstTemp.Items.Count;
         for (int m = 0; m <= frmMain.lstTemp.Items.Count - 1; m++) {
             frmMain.lstCommand.Items.Insert(0, "*** Adding File: " + frmMain.lstTemp.Items.Item(m) + " ***");
             frmMain.prgBar.PerformStep();
             objLibrary.AddFile(frmMain.lstTemp.Items.Item(m));
         }
         frmMain.lstTemp.Items.Clear();
         frmMain.lblLstCount.Text = frmMain.lstTemp.Items.Count;
     }
    
     public void RemoveDupes()
     {
         var objApp = null, objLibrary = null, colTracks = null, colTracksSrch = null, fso = null, objlog = null, objTrackSrch = null, objTrack = null, intCount = null;
         var intOrphans = null, intDups = null, intAdded = null, intCurrent = null, intCountDone = null;
         const var ITTrackKindFile = 1;
         const var ITPlaylistSearchFieldSongNames = 5;
         // Create the iTunes Objects and get all the tracks.
         intOrphans = 0;
         intDups = 0;
         intAdded = 0;
         intCurrent = 0;
         objApp = Interaction.CreateObject("iTunes.Application");
         objLibrary = objApp.LibraryPlaylist;
         //MsgBox(objLibrary.GetType.ToString)
         //Check to make sure library is an object before proceding
         if (objLibrary.GetType.ToString != "System.__ComObject") {
             Interaction.MsgBox("iTunes Library not found!!");
             return;
         }
         colTracks = objLibrary.Tracks;
         objlog = frmMain.lstCommand;
         intCount = colTracks.Count;
         frmMain.lblStatus.Text = "Running: Searching file " + intCurrent + " of " + intCount.ToString + " files...";
         frmMain.prgBar.Maximum = intCount;
         frmMain.prgBar.Value = 0;
         frmMain.prgBar.Step = 1;
         fso = Interaction.CreateObject("Scripting.FileSystemObject");
         // Loop through all the tracks..
         foreach (var objTrack in colTracks) {
             intCurrent = intCurrent + 1;
             frmMain.lblPerc.Text = Strings.Left((intCurrent / intCount) * 100, 5) + "%";
             frmMain.lblStatus.Text = "Running: Searching file " + intCurrent + " of " + intCount.ToString + " files...";
             frmMain.prgBar.PerformStep();
             if (frmMain.chkNewSongs.Checked == true) {
                 //objlog.Items.Insert(0, "*** Matching " & objTrack.Name & " ***")
                 if (CheckFileInList(objTrack.Location) == true) {
                     frmMain.lstTemp.Items.Remove(objTrack.Location);
                     frmMain.lblLstCount.Text = frmMain.lstTemp.Items.Count;
                 }
             }
             if (objTrack.Kind == ITTrackKindFile) {
                 objlog.Items.Insert(0, objTrack.Name + " (" + objTrack.location + ")");
                 //Do a check to see if it is an orpan entry
                 if (string.IsNullOrEmpty(objTrack.Location)) {
                     // ignore this track and move to the next.. it is an orpan file.
                     if (frmMain.chkOrphans.Checked == true) {
                         objlog.Items.Insert(0, "*** Orphan file found and deleted: " + objTrack.Name + " ***");
                         objTrack.delete();
                         intOrphans = intOrphans + 1;
                     }
                     else {
                         objlog.Items.Insert(0, "*** Orphan file found: " + objTrack.Name + " ***");
                     }
                 }
                
                 else {
                     //Do a search for songs with the same name
                     colTracksSrch = objLibrary.Search(objTrack.Name, ITPlaylistSearchFieldSongNames);
                     //objlog.Items.Insert(0, " (Matches: " & colTracksSrch.count & ")")
                     // If more than one song by the same name is found in the search
                     if (colTracksSrch.count > 1) {
                         // Loop through all the search results
                         foreach (var objTrackSrch in colTracksSrch) {
                             if (objTrackSrch.Kind == ITTrackKindFile) {
                                 //objlog.Items.Insert(0, " Track: " & objTrack.Name & " " & objTrack.Album)
                                 //objlog.Items.Insert(0, " TrackSrch:" & objTrackSrch.Name & " " & objTrackSrch.Album)
                                 // Check to make sure the Name and Albums are the same..
                                 if ((objTrack.Name == objTrackSrch.Name) & (objTrack.Album == objTrackSrch.Album)) {
                                     // the size and/or qualitly of the original file is smaller delete it and exit loop
                                     objlog.Items.Insert(0, "*** Match Made *****");
                                     objlog.Items.Insert(0, " Track: " + objTrack.SampleRate + " - " + objTrack.Size + " - " + objTrack.Location);
                                     if ((objTrack.SampleRate < objTrackSrch.SampleRate) | (objTrack.Size < objTrackSrch.Size)) {
                                         objlog.Items.Insert(0, " *** Deleted " + objTrack.Name + " because the other file was better quality ***");
                                         if ((objTrack.location == null)) {
                                         }
                                         //frmMain.prgBar.Value = intCount
                                         //frmMain.btnRun.Enabled = False
                                         //Exit For
                                         else {
                                             if (fso.fileexists(objTrack.Location)) {
                                                 if (frmMain.chkDupilcates.Checked == true) {
                                                     My.Computer.FileSystem.DeleteFile(objTrack.Location);
                                                     intDups = intDups + 1;
                                                 }
                                             }
                                             objTrack.delete();
                                             break; // TODO: might not be correct. Was : Exit For
                                         }
                                     }
                                     // if this is a duplicate file with all the same atributes with the exception of location.
                                     if ((objTrack.SampleRate == objTrackSrch.SampleRate) & (objTrack.Size == objTrackSrch.Size) & (objTrack.Location != objTrackSrch.Location)) {
                                         objlog.Items.Insert(0, "*** Deleted " + objTrackSrch.name + " because it is a duplicate ***");
                                         if (objTrackSrch.Location == null) {
                                             objlog.Items.Insert(0, "*** Skipped without location ***");
                                         }
                                         else {
                                             if (frmMain.chkDupilcates.Checked == true) {
                                                 My.Computer.FileSystem.DeleteFile(objTrack.Location);
                                                 intDups = intDups + 1;
                                             }
                                         }
                                         objTrackSrch.delete();
                                     }
                                 }
                             }
                             else {
                                 objlog.Items.Insert(0, "*** " + objTrack.Name + " is not a track");
                             }
                         }
                     }
                     //Destroy the search objects
                     objTrackSrch = null;
                     colTracksSrch = null;
                 }
             }
         }
        
        
         AddLeftOvers();
         intCountDone = colTracks.Count;
        
         //Destroy the objects
         objApp = null;
         objTrack = null;
         objLibrary = null;
         colTracks = null;
         objlog = null;
         fso = null;
        
         intAdded = (intCountDone - intCount);
         frmMain.lblStatus.Text = "Done searching all " + intCount.ToString + " files!";
         Interaction.MsgBox("Done!" + Constants.vbCrLf + "Duplicates found and removed: " + intDups + Constants.vbCrLf + "Orphaned files found and removed: " + intOrphans + Constants.vbCrLf + "New files added: " + intAdded);
        
     }
    
     //-----| Check iTunes: Returns true if iTunes object is found
     public object CheckiTunes()
     {
         object functionReturnValue = null;
         object objApp = null;
         objApp = Interaction.CreateObject("iTunes.Application");
         if ((objApp.GetType.Name == "__ComObject")) {
             functionReturnValue = true;
         }
         else {
             Interaction.MsgBox("Cannot create iTunes object. Either iTunes isn't updated or you don't have it installed.");
             Interaction.MsgBox(objApp.GetType.Name);
             functionReturnValue = false;
         }
         return functionReturnValue;
     }
    
    
     public void MapDirectory(object dir, object lst)
     {
         var extString = null;
         frmMain.lblStatus.Text = "Creating temp list: " + dir;
         foreach (var file in My.Computer.FileSystem.GetFiles(dir)) {
             frmMain.prgBar.PerformStep();
             extString = Strings.Right(file, 4);
             if (extString == ".ini" | extString == ".jpg" | extString == ".itc" | extString == ".txt" | extString == "bite" | extString == ".wma" | extString == ".m4r" | extString == ".m4p" | extString == ".m4a" | extString == ".m4v" | extString == ".xml" | extString == ".itl" | Strings.Right(extString, 3) == ".db") {
             }
            
             else {
                 lst.Items.Insert(0, file);
             }
         }
        
         // Search child directories.
         foreach (var folder in My.Computer.FileSystem.GetDirectories(dir)) {
             MapDirectory(folder, lst);
         }
     }
    
     //-----| Handle any errors
     public void ErrHandler(object pstrObjName, object pintErrNo, object pstrErrDesc)
     {
         Interaction.MsgBox("An error occurred in Archiver.vbs on " + pstrObjName + ": " + pintErrNo + " Desc: " + pstrErrDesc);
         Err.Clear();
     }
    
     //-----| Verify that a path exists: Checks the given path
     public object VerifyPath(object strPathName)
     {
         object functionReturnValue = null;
         var gobjFso = null;
         gobjFso = Interaction.CreateObject("Scripting.FileSystemObject");
         //-----| Verify that a \ is at the end of the path variables
         if (!(Strings.Right(strPathName, 1) == "\\")) {
             strPathName = strPathName + "\\";
         }
         //-----| Verify paths exist
         if (!gobjFso.FolderExists(strPathName)) {
             Interaction.MsgBox("Source Path " + strPathName + " does not exist.");
             functionReturnValue = false;
         }
         else {
             functionReturnValue = true;
         }
         return functionReturnValue;
        
     }
    
     //-----| Verify that a path exists: Checks the given path
     public object VerifyPath2(object strPathName)
     {
         object functionReturnValue = null;
         var gobjFso = null;
         gobjFso = Interaction.CreateObject("Scripting.FileSystemObject");
         //-----| Verify that a \ is at the end of the path variables
         if (!(Strings.Right(strPathName, 1) == "\\")) {
             strPathName = strPathName + "\\";
         }
         //-----| Verify paths exist
         if (!gobjFso.FolderExists(strPathName)) {
             Interaction.MsgBox("Source Path " + strPathName + " does not exist.");
             functionReturnValue = strPathName;
         }
         else {
             functionReturnValue = strPathName;
         }
         return functionReturnValue;
        
     }
 }
