using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreView : MonoBehaviour
{
    private Text scoreText, percentageText, correctText;
    private Coroutine fadeOut; // used to store a reference to the FadeOut Coroutine

    public Text ScoreText
    {
        get { return scoreText; }
        set { scoreText = value; }
    }

    public Text PercentageText
    {
        get { return percentageText; }
        set { percentageText = value; }
    }

    public Text CorrectText
    {
        get { return correctText; }
        set { correctText = value; }
    }

    public static ScoreView CreateScoreView(Text scoreText, Text percentageText, Text correctText, GameObject gameObject)
    {
        var thisObj = gameObject.AddComponent<ScoreView>();
        thisObj.ScoreText = scoreText;
        thisObj.PercentageText = percentageText;
        thisObj.CorrectText = correctText;
        thisObj.CorrectText.enabled = false;

        return thisObj;
    }

	public ScoreView(Text scoreText, Text percentageText, Text correctText)
	{
		this.scoreText = scoreText;
		this.percentageText = percentageText;
        this.correctText = correctText;
        this.correctText.enabled = false;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void UpdateViews(int score, double percent)
	{
		percentageText.text = "Percent Correct: " + percent + "%";
		scoreText.text = "Score: " + score;
	}

    public void CorrectGuess()
    {
        correctText.enabled = true;
        if (fadeOut != null)
        {
            StopCoroutine(fadeOut);
            correctText.color = Color.white;
        }
        fadeOut = StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(0.5f);
        //correctText.CrossFadeAlpha(0.0f, 0.3f, false);
        float elapsedTime = 0.0f;
        float fadeTime = 0.5f;
        Color transparent = new Color(0, 0, 0, 0);
        Color original = correctText.color;

        while (elapsedTime < fadeTime)
        {
            elapsedTime += Time.deltaTime;
            correctText.color = Color.Lerp(original, transparent, (elapsedTime / fadeTime));
            yield return null;
        }
        //yield return new WaitForSeconds(1.0f);
        correctText.enabled = false;
        correctText.color = original;
    }
}
