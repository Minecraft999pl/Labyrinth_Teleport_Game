using System.Collections;
using System.Collections.Generic;
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

    // Start is called before the first frame update
    void Start()
    {
        if (gameManager == null)
        {
            gameManager = this;
        }

        InvokeRepeating("Stopper", 2, 1);

        if (timeToEnd <= 0)
        {
            timeToEnd = 100;
        }
    }

    // Update is called once per frame
    void Update()
    {
        PauseCheck();
        PickUpCheck();
    }

    void Stopper()
    {
        timeToEnd --;
        Debug.Log("Time: " + timeToEnd + "s");

        if (timeToEnd <= 0)
        {
            timeToEnd = 0;
            endGame = true;
        }
        if (endGame){
            EndGame();
        }
    }

    public void PauseGame()
    {
        Debug.Log("Pause Game");
        Time.timeScale = 0f;
        gamePaused = true;
    }

    void ResumeGame()
    {
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
    public void EndGame(){
        CancelInvoke("Stopper");
        if (win)
        {
            Debug.Log("You win! Reload?");
            //Time.timeScale = 0f;
        }
        else
        {
            Debug.Log("You lose! Reload?");
            //Time.timeScale = 0f;
        }
    }

    public void AddPoints(int point)
    {
        points += point;
    }

    public void AddTime(int AddTime)
    {
        timeToEnd += AddTime;
    }

    public void FreezeTime(int freeze)
    {
        CancelInvoke("Stopper");
        InvokeRepeating("Stopper", freeze, 1);
    }

    public void AddKey(KeyColor color)
    {
        if (color == KeyColor.Gold)
        {
            goldKey++;
        }
        else if (color == KeyColor.Green)
        {
            greenKey++;
        }
        else if (color == KeyColor.Red)
        {
            redKey++;
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
}
