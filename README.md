# DrummerVR
Game Dev Project - Tu Ilmenau

# Game Mode Scripts

In game mode, every level requires: (A level being a song)

1) Extraction of the number of musical notes and their time of occurrence during the song.
2) Spawning a group of game objects, where each corresponds to a musical note
3) Moving the game objects in space towards their respective instruments in such a
way that they arrive according to their specified time of occurrence which was
extracted in task 1.
4) Handling Score attempts
5) Handling Score counter and Combo counter
6) Displaying Score counters.
7) Music Sync with visuals, music will not play and virtual notes will not move until the player hits the stick 3 times to signal the begining and give the player time to be ready to play.

The following specifies the name of the script that handles each task.

| Task  | Script Name |
| ------------- | ------------- |
| Extraction of notes from .txt file and spawning them.  | Instrument + analyze.cs  |
| Moving The game objects in 3D space.  |  Instrument + Notes.cs ex: HiHatsNotes |
| Handling Score attempts  | ScoreManager.cs  |
| Handling Score counter and Combo counter  | ScoreHandler.cs  |
| Displaying Score Counters  | UpdateScoreDisp.cs  |
| Music Sync with Visuals | SyncMaster.cs  |


# Submitted Version - Unity Project -
https://we.tl/t-FsfIJ0fBAa
