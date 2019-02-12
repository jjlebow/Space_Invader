using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusEnemy : MonoBehaviour
{
    private Rigidbody2D bonusRigidbody2D;

    private int directionCheck; //0 = travels to left, 1 = travels to right

    // Start is called before the first frame update
    void Start()
    {
        bonusRigidbody2D = this.GetComponent<Rigidbody2D>();

        if (this.transform.position.x < -8) //if the UFO's position is on the left, it'll travel right
            directionCheck = 1;
        else if (this.transform.position.x > 8) //if the UFO's position is on the right, it'll travel left
            directionCheck = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (directionCheck == 1) //if it's travelling right or left, we have to account for it in the vector
            bonusRigidbody2D.velocity = new Vector2(2.5f, 0f);
        else if (directionCheck == 0)
            bonusRigidbody2D.velocity = new Vector2(-2.5f, 0f);

        if (this.transform.position.x < -14 || this.transform.position.x > 14) //if it goes off-screen again it will despawn
        {
            LevelManager.instance.bonusAlive = false; //the UFO is currently not alive, so we account for this in the Player script
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.gameObject);
        float percentage = Random.value; //generate a % to determine how many points the UFO will award for killing it
                                         //it should theoretically never collide with anything other than a player projectile
        if (percentage <= .2f)
            LevelManager.instance.score += 100;
        else if (percentage > .2f && percentage <= .4f)
            LevelManager.instance.score += 150;
        else if (percentage > .4f && percentage <= .6f)
            LevelManager.instance.score += 200;
        else if (percentage > .6f && percentage <= .8f)
            LevelManager.instance.score += 250;
        else if (percentage > .8f && percentage <= 1)
            LevelManager.instance.score += 300;

        LevelManager.instance.bonusCheck = true; //the UFO has been killed and will NEVER respawn
        Destroy(this.gameObject);
    }
}
