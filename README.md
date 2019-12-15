# spotify-info
 Get information about the currently playing track, requires the desktop version of spotify and a working internet connection

# Requirements
- Windows machine
- [Spotify desktop](https://www.spotify.com/de/download/windows/)
- [MongoDB installed on your computer](https://www.mongodb.com/download-center/community) (Optional, but required to create playlists)
- [ffmpeg.exe in C:\ folder](https://ffmpeg.zeranoe.com/builds/)

## How to use
### Do this once
[Get a spotify client id and secret id.](https://developer.spotify.com/documentation/general/guides/app-settings/)
Enter these in the corresponding fields in the application.
Click on "get access token" and confirm.

### Do this everytime you want to record
Click on "select folder" and select the folder you want your songs to be saved in.
Click on record and start playing songs in your spotify desktop application.
Once your done, click the same button again and wait for the current song to finsish.

## How to save a playlist
Make sure you have mongodb installed and running throughout the recording proccess.
Click on "Load Playlists", this will load all of your spotify playlists. Now select the one you want to save from the dropdown menu. Now click on "Select File" and choose a file to save to (.m3u). Now click on "Create Playlist".


## Todo/Known Bugs/Issues

#### Playlist limited to 50
#### Songs per playlist limited to 100