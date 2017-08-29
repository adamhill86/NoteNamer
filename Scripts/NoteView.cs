using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteView : MonoBehaviour
{
	private Text noteText, lowerLedgerLine, lowerLedgerLine2, upperLedgerLine;
    private Note note;
    private float scaleFactor = 1.5f;
	private float magicNumber = 37.0f * 1.5f; // the number of units to move notes in the y direction
	private float xPos = 0.0f;
	private Vector2 origin = new Vector2(0.0f, 0.0f);
    private Note b4 = new Note(Note.NoteName.B, 4); // note in the origin position

	public NoteView(Text noteText, Note note, Text lowerLedgerLine, Text lowerLedgerLine2, Text upperLedgerLine)
	{
		this.noteText = noteText;
        this.note = note;
        this.upperLedgerLine = upperLedgerLine;
        this.lowerLedgerLine = lowerLedgerLine;
        this.lowerLedgerLine2 = lowerLedgerLine2;
        UpdateNoteView(this.note);
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void UpdateNoteView(Note newNote)
    {
        note = newNote;
        int interval = b4.IntervalBetween(note);
        Debug.Log(interval);
        noteText.transform.localPosition = new Vector2(xPos, interval * magicNumber);
        DisplayLedgerLines();
    }

    private void DisplayLedgerLines()
    {
        // Disable the ledger line views by default
        lowerLedgerLine.enabled = false;
        lowerLedgerLine2.enabled = false;
        upperLedgerLine.enabled = false;

        Note d4 = new Note(Note.NoteName.D, 4); // lowest note before ledger lines start below
        Note b3 = new Note(Note.NoteName.B, 3); // lowest note before second ledger line starts below
        Note g5 = new Note(Note.NoteName.G, 5); // highest note before ledger lines start above
        if (note < d4)
        {
            lowerLedgerLine.enabled = true;
        } else if (note > g5)
        {
            upperLedgerLine.enabled = true;
        }

        if (note < b3)
        {
            lowerLedgerLine2.enabled = true;
        }
    }
}
