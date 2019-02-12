using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyMovement : MonoBehaviour
{
	private Transform Enemies;
    private Collider2D enemyCollider2D;

    public float speed = 1.5f;

    public GameObject left_bound;
    public GameObject right_bound;

    private float left_x;
    private float right_x;

    // Start is called before the first frame update
    void Start()
    {
    	Enemies 		  = GetComponent<Transform> ();
        enemyCollider2D = GetComponent<Collider2D>();

        left_x            = left_bound.transform.position.x;
        right_x           = right_bound.transform.position.x;  
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        int enemiesLeft = 0;

        foreach (Transform enemy in Enemies)
    	{
            enemiesLeft++;

    		if ( (enemy.position.x <= left_x) || (enemy.position.x >= right_x) )
    		{
    			speed = -speed;

                Enemies.position += Vector3.down * 0.5f;
                return;
    		}
    	}

        if (enemiesLeft == 0)
            LevelManager.instance.hasWon = true;
    }


    void Move()
    {
        Enemies.transform.Translate(new Vector2(speed * Time.deltaTime, 0));
        //yDirection = 0; //sets back to normal.
    }

    void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.CompareTag("Projectile"))
		{
			Destroy(gameObject);
		}
	}	

}
