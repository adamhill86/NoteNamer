using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteGenerator : MonoBehaviour
{

    private Note head, tail;
    private List<Note> range;
    private System.Random random;

    public NoteGenerator()
    {
        head = null;
        tail = null;
        range = new List<Note>();
        random = new System.Random();
    }

    public NoteGenerator(Note head, Note tail)
    {
        this.head = head;
        this.tail = tail;
        range = GetNotesInRange(head, tail);
        random = new System.Random();
    }

    public List<Note> GetNotesInRange(Note head, Note tail)
    {
        List<Note> noteList = new List<Note>();
        if (head > tail || head == null || tail == null)
        {
            return noteList;
        }
        noteList.Add(head);
        while (head != tail)
        {
            head++;
            noteList.Add(head);
        }

        return noteList;
    }

    public List<Note> GetNotesInRange()
    {
        return GetNotesInRange(head, tail);
    }

    /// <summary>
    /// Returns a randomly selected Note from the NoteGenerator's range (inclusive)
    /// </summary>
    /// <returns>A random Note or null if range is empty</returns>
    public Note GetRandomNote()
    {
        int min = 0;
        int max = range.Count;

        // Make sure range is not empty before we start trying to get random Notes
        if (max > 0)
        {
            int index = random.Next(min, max);
            return range[index];
        }
        return null;
    }
}
