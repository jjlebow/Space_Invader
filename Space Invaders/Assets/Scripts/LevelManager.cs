﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public int score       = 0;
    
    public bool gameOver   = false;
    public bool hasWon     = false;
    public bool bonusCheck = false; //Has the UFO ever been killed? If it has, it will never respawn
    public bool bonusAlive = false; //Is the UFO currently alive? If it is, then another cannot be spawned
    public int lives       = 3;

    public GameObject bonus;
    public GameObject gameOverMenu;

    public GameObject winMenu;

    public GameObject pauseMenu;

    bool paused = false;

    void Awake()
    {
        instance = this;

    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!bonusCheck && !bonusAlive) //While we haven't killed the UFO and it isn't on the screen, it might spawn
            UFOSpawn();
        
        if(gameOver == true || lives <= 0) //if gameover == true for any reason (including the if statement above)...
        {
            gameOverMenu.SetActive(true);    //brings up the gameOverMenu when any condition for gameover has been met
            Time.timeScale = 0f;
        }
        else if (hasWon == true)
        {
            winMenu.SetActive(true);
            Time.timeScale = 0f;
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(paused == false)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        }
    }

    void UFOSpawn()
    {
        //0.00083333
        if (Random.value <= 0.00083333) //% chance is calculated at % chance/amount of Update() calls; to get a 5% chance of spawn every second, 0.05/60 = 0.00083333
        {
            bonusAlive = true;

            if (Random.value <= .5f) //50% chance to spawn on the left
                Instantiate(bonus, new Vector2(-14, 6.5f), Quaternion.identity);
            else //50% chance to spawn on the right
                Instantiate(bonus, new Vector2(14, 6.5f), Quaternion.identity);
        }
    }

    public void AddScore(int addToScore)
    {
        score += addToScore;
    }

    public void PauseGame()
    {
        paused = true;
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
    }
    public void ResumeGame()
    {
        paused = false;
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);

    }
    public void ExitGame()
    {
        Debug.Log("Exiting Game");
        Application.Quit();
    }
}
