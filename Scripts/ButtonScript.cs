using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    public Text note;
    public GameObject gameController;

    /*
    public void OnClickA()
    {
        print("This button has been clicked!");
        note.GetComponent<Note>().setNoteName('A');
        note.GetComponent<Note>().setOctave(4);
        note.GetComponent<Note>().Reposition();
        gameController.GetComponent<GameControllerScript>().UpdateNoteName('A');
    }

    public void OnClickB()
    {
        print("This button has been clicked!");
        note.GetComponent<Note>().setNoteName('B');
        note.GetComponent<Note>().setOctave(4);
        note.GetComponent<Note>().Reposition();
        gameController.GetComponent<GameControllerScript>().UpdateNoteName('B');
    }

    public void OnClickC()
    {
        print("This button has been clicked!");
        note.GetComponent<Note>().setNoteName('C');
        note.GetComponent<Note>().setOctave(4);
        note.GetComponent<Note>().Reposition();
        gameController.GetComponent<GameControllerScript>().UpdateNoteName('C');
    }

    public void OnClickD()
    {
        print("This button has been clicked!");
        note.GetComponent<Note>().setNoteName('D');
        note.GetComponent<Note>().setOctave(4);
        note.GetComponent<Note>().Reposition();
        gameController.GetComponent<GameControllerScript>().UpdateNoteName('D');
    }

    public void OnClickE()
    {
        print("This button has been clicked!");
        note.GetComponent<Note>().setNoteName('E');
        note.GetComponent<Note>().setOctave(4);
        note.GetComponent<Note>().Reposition();
        gameController.GetComponent<GameControllerScript>().UpdateNoteName('E');
    }

    public void OnClickF()
    {
        print("This button has been clicked!");
        note.GetComponent<Note>().setNoteName('F');
        note.GetComponent<Note>().setOctave(4);
        note.GetComponent<Note>().Reposition();
        gameController.GetComponent<GameControllerScript>().UpdateNoteName('F');
    }

    public void OnClickG()
    {
        print("This button has been clicked!");
        note.GetComponent<Note>().setNoteName('G');
        note.GetComponent<Note>().setOctave(4);
        note.GetComponent<Note>().Reposition();
        gameController.GetComponent<GameControllerScript>().UpdateNoteName('G');
    }
    */
    public void OnClickRand()
    {
        gameController.GetComponent<GameControllerScript>().GenerateRandomNote();
    }

    public void GuessA()
    {
        gameController.GetComponent<GameControllerScript>().Guess(Note.NoteName.A);
    }

    public void GuessB()
    {
        gameController.GetComponent<GameControllerScript>().Guess(Note.NoteName.B);
    }

    public void GuessC()
    {
        gameController.GetComponent<GameControllerScript>().Guess(Note.NoteName.C);
    }

    public void GuessD()
    {
        gameController.GetComponent<GameControllerScript>().Guess(Note.NoteName.D);
    }

    public void GuessE()
    {
        gameController.GetComponent<GameControllerScript>().Guess(Note.NoteName.E);
    }

    public void GuessF()
    {
        gameController.GetComponent<GameControllerScript>().Guess(Note.NoteName.F);
    }

    public void GuessG()
    {
        gameController.GetComponent<GameControllerScript>().Guess(Note.NoteName.G);
    }
}
