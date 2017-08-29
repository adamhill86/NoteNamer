using System;
using UnityEngine;

public class Note : MonoBehaviour, IComparable, ICloneable
{
    /// <summary>
    /// The set of possible note names.
    /// The list starts at C because the standard octave number system starts with C.
    /// This allows for easier comparisons between notes.
    /// </summary>
    public enum NoteName
    {
        C, D, E, F, G, A, B
    };

    private NoteName noteName;
    private int octaveNumber;

    public NoteName Name
    {
        get
        {
            return noteName;
        }

        set
        {
            noteName = value;
        }
    }

    public int OctaveNumber
    {
        get
        {
            return octaveNumber;
        }

        set
        {
            octaveNumber = value;
        }
    }

    public Note(NoteName noteName, int octaveNumber)
    {
        this.noteName = noteName;
        this.octaveNumber = octaveNumber;
    }

    public Note(Note other)
    {
        noteName = other.Name;
        octaveNumber = other.OctaveNumber;
    }

    /// <summary>
    /// The default constructor will create a C4 note
    /// </summary>
    public Note()
    {
        noteName = NoteName.C;
        octaveNumber = 4;
    }

    /// <summary>
    /// Returns a 0-based interval between 2 notes.
    /// In music theory, if two notes are the same, the interval is said to be a unison (or a 1st).
    /// This method is used to help determine positioning on the staff and needs to be 0-based.
    /// The NoteView class will use the interval and multiply that by the spacing constant to determine
    /// where on the screen the note needs to be displayed.
    /// </summary>
    /// <param name="otherNote">The Note we're comparing to.</param>
    /// <returns>The 0-based interval between the notes.</returns>
    public int IntervalBetween(Note otherNote)
    {
        // Check to see if this and otherNote are equal
        if (this == otherNote)
        {
            return 0;
        }

        Note temp = (Note)Clone();
        int interval = 0;

        while (temp != otherNote)
        {
            if (this < otherNote)
            {
                temp++;
                interval++;
            }
            else
            {
                temp--;
                interval--;
            }
        }

        return interval;
    }

    public override string ToString()
    {
        return noteName.ToString() + octaveNumber.ToString();
    }

    public override int GetHashCode()
    {
        int hash = 13;
        hash = (hash * 397) ^ noteName.GetHashCode();
        hash = (hash * 397) ^ octaveNumber.GetHashCode();
        return hash;
    }

    public override bool Equals(System.Object obj)
    {
        // Check for null values and compare run-time types.
        if (System.Object.ReferenceEquals(obj, null) || GetType() != obj.GetType())
            return false;

        Note other = (Note)obj;
        // Optimization for a common success case.
        if (System.Object.ReferenceEquals(this, other))
        {
            return true;
        }
        return (noteName == other.Name && octaveNumber == other.OctaveNumber);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="obj"></param>
    /// <returns>-1 if this precedes other, 0 if they are equal, and 1 if this proceded other</returns>
    public int CompareTo(System.Object obj)
    {
        // Check for null values and compare run-time types.
        if (System.Object.ReferenceEquals(obj, null) || GetType() != obj.GetType())
            return 1;

        Note other = (Note)obj;

        if (ReferenceEquals(this, other) || noteName == other.Name && octaveNumber == other.OctaveNumber)
        {
            return 0;
        }

        if (noteName == other.Name)
        {
            return (octaveNumber > other.OctaveNumber) ? 1 : -1;
        }
        else if (octaveNumber == other.OctaveNumber)
        {
            return (noteName > other.Name) ? 1 : -1;
        }
        // if the notes don't share the same name or the same octave, we can simply compare the octave numbers
        // For example, B2 will be lower than any other note in the 3rd, 4th, etc. octaves regardless of the other note's name
        return (octaveNumber > other.OctaveNumber) ? 1 : -1;
    }

    public object Clone()
    {
        return new Note(this);
    }

    public static bool operator <(Note lhs, Note rhs)
    {
        return lhs.CompareTo(rhs) < 0;
    }

    public static bool operator >(Note lhs, Note rhs)
    {
        return lhs.CompareTo(rhs) > 0;
    }

    public static bool operator ==(Note lhs, Note rhs)
    {
        // If left hand side is null...
        if (System.Object.ReferenceEquals(lhs, null))
        {
            // ...and right hand side is null...
            if (System.Object.ReferenceEquals(rhs, null))
            {
                //...both are null and are Equal.
                return true;
            }

            // ...right hand side is not null, therefore not Equal.
            return false;
        }

        // Return true if the fields match:
        return lhs.Equals(rhs);
    }

    public static bool operator !=(Note lhs, Note rhs)
    {
        return !(lhs == rhs);
    }

    public static Note operator ++(Note note)
    {
        Note newNote = (Note)note.Clone();
        if (newNote.Name == NoteName.B)
        {
            newNote.Name = NoteName.C;
            newNote.OctaveNumber++;
            return newNote;
        }
        else
        {
            newNote.Name++;
            return newNote;
        }
    }

    public static Note operator --(Note note)
    {
        Note newNote = (Note)note.Clone();
        if (newNote.Name == NoteName.C)
        {
            newNote.Name = NoteName.B;
            newNote.OctaveNumber--;
            return newNote;
        }
        else
        {
            newNote.Name--;
            return newNote;
        }
    }
}
