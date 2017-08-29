# NoteNamer
A Unity note naming game designed to help my music students with their sight reading. These are the script files for the project.

# Script Files
**ButtonScript.cs:** Handles sending a student's answer to the GameController.  
**GameControllerScript.cs:** Handles the logic for the GameController object.  
**LetterSpacing.cs:** Gives the option to change spacing between letters in Unity. [Credit to Andrew Pavlovich](https://bitbucket.org/AcornGame/adjustable-character-spacing).  
**Note.cs:** A class modeling a Note object. It holds a note name (A-G) and an octave number.  
**NoteGenerator.cs:** A class responsible for creating all the notes within a given range as well as generating a random note inside that range. This earlier version is set to all the notes a violinist can play in 1st position.  
**NoteView.cs:** Handles displaying the random note created by NoteGenerator.  
**ScoreView.cs:** Handles displaying the student's score and percentage correct.