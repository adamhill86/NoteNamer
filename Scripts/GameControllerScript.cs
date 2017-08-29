using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControllerScript : MonoBehaviour
{
    public Text noteText, scoreText, percentageText, correctText, lowerLedgerLine, upperLedgerLine,
        lowerLedgerLine2, clefText, staffText;
    private Note randomNote;
    private int score;
    private int numberOfGuesses;
    private int correctGuesses;
    private float percentCorrect;
	private ScoreView scoreView;
	private NoteView noteView;
    private NoteGenerator noteGenerator;
    private int fontSize = 450;

    // Use this for initialization
    void Start()
    {
        Note g3 = new Note(Note.NoteName.G, 3);
        Note b5 = new Note(Note.NoteName.B, 5);
        noteGenerator = new NoteGenerator(g3, b5); // default range is D below the staff to G above it
        randomNote = noteGenerator.GetRandomNote();
        Debug.Log(randomNote);
        score = 0;
        numberOfGuesses = 0;
        correctGuesses = 0;
        percentCorrect = 0.0f;
        //scoreView = new ScoreView(scoreText, percentageText, correctText);
        scoreView = ScoreView.CreateScoreView(scoreText, percentageText, correctText, gameObject);
        noteView = new NoteView(noteText, randomNote, lowerLedgerLine, lowerLedgerLine2, upperLedgerLine);
        ScaleTextFonts();
		UpdateTextViews();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GenerateRandomNote()
    {
        randomNote = noteGenerator.GetRandomNote();
        noteView.UpdateNoteView(randomNote);
        Debug.Log(randomNote);
    }

    public void Guess(Note.NoteName noteGuess)
    {
        Debug.Log("Note name: " + randomNote.Name + " and guess: " + noteGuess);
        numberOfGuesses++;
        if (randomNote.Name == noteGuess)
        {
            Debug.Log("Correct");
            scoreView.CorrectGuess();
            correctGuesses++;
            score += 10;
            percentCorrect = ((float)correctGuesses) / ((float)numberOfGuesses);
            //UpdateScoreText();
            //UpdatePercentageText();
			UpdateTextViews();
            GenerateRandomNote();
        } else
        {
            percentCorrect = ((float)correctGuesses) / ((float)numberOfGuesses);
			UpdateTextViews();
        }
    }
    /*
    public void UpdateNoteName(char noteName)
    {
        this.noteName = noteName;
    }*/

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }

    private void UpdatePercentageText()
    {
        Debug.Log(percentCorrect);
        double percentage = percentCorrect * 100.0f;
        double rounded = Math.Round(percentage, 2);
        percentageText.text = "Percentage: " + rounded + "%";
    }

	private void UpdateTextViews()
	{
        Debug.Log(percentCorrect);
		double percentage = percentCorrect * 100.0f;
		double rounded = Math.Round(percentage, 2);
		scoreView.UpdateViews(score, rounded);
	}

    private void ScaleTextFonts()
    {
        noteText.fontSize = fontSize;
        clefText.fontSize = fontSize;
        staffText.fontSize = fontSize;
        upperLedgerLine.fontSize = fontSize;
        lowerLedgerLine.fontSize = fontSize;
        lowerLedgerLine2.fontSize = fontSize;
    }
}
