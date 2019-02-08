﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public int score = 0;

    public bool gameOver = false;
    public bool bonusCheck = false; //Has the UFO ever been killed? If it has, it will never respawn
    public bool bonusAlive = false; //Is the UFO currently alive? If it is, then another cannot be spawned

    public GameObject bonus;

    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!bonusCheck && !bonusAlive) //While we haven't killed the UFO and it isn't on the screen, it might spawn
            UFOSpawn();
    }

    void UFOSpawn()
    {
        if (Random.value <= 0.00083333) //% chance is calculated at % chance/amount of Update() calls; to get a 5% chance of spawn every second, 0.05/60 = 0.00083333
        {
            bonusAlive = true;

            if (Random.value <= .5f) //50% chance to spawn on the left
                Instantiate(bonus, new Vector2(-14, 6.5f), Quaternion.identity);
            else //50% chance to spawn on the right
                Instantiate(bonus, new Vector2(14, 6.5f), Quaternion.identity);
        }
    }
}