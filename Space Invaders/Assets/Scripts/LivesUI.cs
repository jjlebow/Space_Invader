using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesUI : MonoBehaviour
{
	public GameObject Life3;
	public GameObject Life2;
	public GameObject Life1;

    void Update()
    {
    	int lives = LevelManager.instance.lives;

        if (lives == 2)
        	Destroy(Life3);

        if (lives == 1)
        	Destroy(Life2);

        if (lives == 0)
        	Destroy(Life1);
    }
}
