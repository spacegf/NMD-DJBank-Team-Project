Offline Leaderboards / High Scores Unity Asset Store Package by PsychicParrot
Version updates

v1.8
Bug fixes for joystick input (cases where the last letter was not added and when the max name length was ignored)
Added checkboxes for Fire2 enable/disable and auto submit on max length
Moved name used for auto re-naming of empty names to a public variable so that it's editable in the Inspector
Added public static max name length variable so that the max name length can be accessed from input controller script (or any other script) easily
Updated to 5.6.1p3

v1.7
Added LowestFirst variable to LB_Leaderboard.cs to allow reverse ranked leaderboards (choose between lowest score top rank or highest score top rank)
Moved GetHighScoreRank code out into new function, GetRank but made a GetHighScoreRank function for backwards compatibility
Documentation update

v1.6
Changed all classes and files related to this pack to have the prefix LB_ to avoid clashing with similarly named files in your own games(!)

v1.5
Added support to the joystick input field so that you can add, delete and submit through code.
Updated the documentation.
Tidied up the Update() function in joystick input.

v1.4
Fixed float support broken in 1.3 (!)

v1.3
Added checkboxes to StandardHighScores.cs for joystick input and for switching between floats or ints on the displayed scoreboard example.
Added controller-based text input example to the leaderboard example UI.
Fixed scoreboard index bug in Leaderboard.cs SetUpScores() function that stopped multiple scoreboards from working right by forcing the index to 0 each time.

*Please backup your work before updating if you are importing into a project that uses a previous version of the package. The UI example will not be fully backward compatible with the old UI example. However, the main leaderboard script is unchanged so if you're not using the UI examples the leaderboard code will remain compatible.*

v1.2 - Extended examples
v1.1 - Added more functions to leaderboard.cs
v1.0 - Initial release