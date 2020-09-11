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
7) Music Sync with visuals

The following specifies the name of the script that handles each task.

| Task  | Script Name |
| ------------- | ------------- |
| Extraction of notes from .txt file and spawning them.  | INSTRUMENT_NAME+analyze.cs  |
| Moving The game objects in space.  |  INSTRUMENT_NAME+notes.cs  |
| Handling Score attempts  | ScoreManager.cs  |
| Handling Score counter and Combo counter  | ScoreHandler.cs  |
| Displaying Score Counters  | UpdateScore.cs  |
| Music Sync with Visuals | SyncMaster.cs  |
