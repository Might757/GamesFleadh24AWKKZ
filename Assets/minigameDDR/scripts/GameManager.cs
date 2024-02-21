using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject Victory;

    public GameObject Failure;
    public GameObject Notes;
    public int NotesMissed;
    public AudioSource Music;

    public bool startMusic;

    public BeatScroller BS;

    public static GameManager instance;

    public int currentScore;

    public int scorePerNote;

    public int scorePerNormalHit = 100;

    public int scorePerGoodNote = 150;

    public int scorePerPerfectNote =200;

    public Text scoreText;
    
    public Text multiText;

    public int currentMultiplier;

    public int multiplierTracker;
    public int[] multiplierTresholds;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        scoreText.text = "Score: 0";
        currentMultiplier =1;
    }

    // Update is called once per frame
    void Update()
    {
        if(!startMusic)
        {
            if(Input.anyKeyDown)
            {
                startMusic = true;
                BS.hasStarted = true;

                Music.Play();
            }
        }
        else if(NotesMissed >= 10)
        {
            Notes.SetActive(false);
            Failure.SetActive(true);
            Music.Stop();
        }
        if(currentScore >= 10000)
        {
            Notes.SetActive(false);
            Victory.SetActive(true);
            Music.Stop();
        }

    }


    public void NoteHit()
    {
        Debug.Log("Hit on time!");
        if(currentMultiplier - 1 < multiplierTresholds.Length)
        {
        multiplierTracker++;
        if(multiplierTresholds[currentMultiplier - 1] <= multiplierTracker)
        {
            multiplierTracker = 0;
            currentMultiplier++;
            multiText.text = "Multiplier: x"+currentMultiplier;
        }
        }
        /*currentScore += (scorePerNote*currentMultiplier);*/
        scoreText.text = "Score: "+currentScore;
    }

    public void NormalHit()
    {
        currentScore += (scorePerNormalHit*currentMultiplier);
        NoteHit();
    }
    public void GoodHit()
    {
        currentScore += (scorePerGoodNote*currentMultiplier);
        NoteHit();
    }

    public void PerfectHit()
    {
        currentScore += (scorePerPerfectNote*currentMultiplier);
        NoteHit();
    }
    public void NoteMissed()
    {
        Debug.Log("Missed note!");
        currentScore -= scorePerNote;
        currentMultiplier = 1;
        multiplierTracker = 0;
        scoreText.text = "Score: "+currentScore;
        multiText.text = "Multiplier: x"+currentMultiplier;
    }
}
