using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    [SerializeField] int timeToEnd;
    bool gamePaused = false;
    bool endGame = false;
    bool win = false;
    public int points = 0;

    public int redKey = 0;
    public int greenKey = 0;
    public int goldKey = 0;

   /* AudioSource audioSource;
    public AudioClip resumeClip;
    public AudioClip pauseClip;
    public AudioClip loseClip;
    public AudioClip winClip;
    public AudioClip pickClip;

    public MusicScript musicScript;
    bool lessTime = false;*/

    public Text timeText;
    public Text redKeyText;
    public Text greenKeyText;
    public Text goldKeyText;
    public Text crystalText;
    public Image snowFlake;

    public GameObject infoPanel;
    public Text pauseEnd;
    public Text reloadInfo;
    public Text useInfo;
    public GameObject ErrorPanel;

    // Start is called before the first frame update
    void Start()
    {
        if (gameManager == null)
        {
            gameManager = this;
        }

        if (timeToEnd <= 0)
        {
            timeToEnd = 100;
        }

        //audioSource = GetComponent<AudioSource>();
        InvokeRepeating("Stopper", 2, 1);
        snowFlake.enabled = false;
        timeText.text = timeToEnd.ToString();
        infoPanel.SetActive(true);
        pauseEnd.text = "Pause";
        reloadInfo.text = "";
        SetUseInfo("");
    }

    // Update is called once per frame
    void Update()
    {
        PauseCheck();
        PickUpCheck();
    }

    /*public void PlayClip(AudioClip playClip)
    {
        audioSource.clip = playClip;
        audioSource.Play();
    }*/

    void Stopper()
    {
        timeToEnd --;
        Debug.Log("Time: " + timeToEnd + "s");
        timeText.text = timeToEnd.ToString();
        snowFlake.enabled = false;

        if (timeToEnd <= 0)
        {
            timeToEnd = 0;
            endGame = true;
        }
        if (endGame){
            EndGame();
        }/*
        if(timeToEnd < 20 && !lessTime)
        {
            LessTimeOn();
            lessTime = true;
        }
        if(timeToEnd > 20 && lessTime)
        {
            LessTimeOff();
            lessTime = false;
        }*/
    }

    public void PauseGame()
    {
        //PlayClip(pauseClip);
        //musicScript.OnPauseGame();
        infoPanel.SetActive(true);
        Debug.Log("Pause Game");
        Time.timeScale = 0f;
        gamePaused = true;
    }

    void ResumeGame()
    {
        // PlayClip(resumeClip);
        //musicScript.OnResumeGame();
        infoPanel.SetActive(false);
        Debug.Log("Resume Game");
        Time.timeScale = 1f;
        gamePaused = false;
    }

    void PauseCheck()
    {
        if (Input.GetKeyDown(KeyCode.P)){
            if (gamePaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }
    public void EndGame()
    {
        CancelInvoke("Stopper");
        infoPanel.SetActive(true);
        if (win)
        {
            //PlayClip(winClip);
            Debug.Log("You win! Reload?");
            pauseEnd.text = "You win!";
            reloadInfo.text = "Reload?";
            //Time.timeScale = 0f;
        }
        else
        {
            //PlayClip(loseClip);
            Debug.Log("You lose! Reload?");
            pauseEnd.text = "You lose!";
            reloadInfo.text = "Reload?";
            //Time.timeScale = 0f;
        }
    }

    public void SetUseInfo(string info)
    {
        useInfo.text = info;
    }

    public void AddPoints(int point)
    {
        points += point;
        crystalText.text = points.ToString();
    }

    public void AddTime(int AddTime)
    {
        timeToEnd += AddTime;
        timeText.text = timeToEnd.ToString();
    }

    public void FreezeTime(int freeze)
    {
        CancelInvoke("Stopper");
        InvokeRepeating("Stopper", freeze, 1);
        snowFlake.enabled = true;
    }

    public void AddKey(KeyColor color)
    {
        if (color == KeyColor.Red)
        {
            redKey++;
            redKeyText.text = redKey.ToString();
        }
        else if (color == KeyColor.Green)
        {
            greenKey++;
            greenKeyText.text = greenKey.ToString();
        }
        else if (color == KeyColor.Gold)
        {
            goldKey++;
            goldKeyText.text = goldKey.ToString();
        }
    }

    void PickUpCheck()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            Debug.Log("Actual Time: " + timeToEnd);
            Debug.Log("Red keys: " + redKey + " Green keys: " + greenKey + " Gold keys: " + goldKey);
            Debug.Log("Points: " + points);
        }
    }
    /*
    public void LessTimeOn()
    {
        musicScript.PitchThis(1.58f);
    }

    public void LessTimeOff()
    {
        musicScript.PitchThis(1f);
    }*/
}
