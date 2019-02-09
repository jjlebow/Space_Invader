using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    protected int speed = 5;
    public int lives = 3;

    public GameObject leftBound;
    public GameObject rightBound;
    public GameObject projectile;
    public GameObject enemyProjectile;

    private Collider2D playerCollider2D;

    private float leftX;
    private float rightX;

    // Start is called before the first frame update
    void Start()
    {
        playerCollider2D = this.GetComponent<Collider2D>();

        leftX = leftBound.transform.position.x;
        rightX = rightBound.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        if (Time.timeScale != 0 && (Input.GetKey(KeyCode.Mouse0) || Input.GetKey(KeyCode.Space)))
            Shoot();
    }

    void Move()
    {
        float movementModifier = Input.GetAxisRaw("Horizontal");

        if (this.transform.position.x >= rightX && movementModifier > 0)
            movementModifier = 0;

        if (this.transform.position.x <= leftX && movementModifier < 0)
            movementModifier = 0;

        this.transform.Translate(new Vector2(movementModifier * speed * Time.deltaTime, 0));
    }

    void Shoot()
    {
        if (!GameObject.Find("PlayerProjectile(Clone)"))
            Instantiate(projectile, this.transform.position, Quaternion.identity);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.collider.CompareTag("Enemy")) //Enemy projectile tagged as "Projectile," player projectile has no tag
        {
            --lives;
            LevelManager.instance.LoseLife();



            Destroy(collision.gameObject);
        }
        else if (collision.collider.CompareTag("Enemy"))
            LevelManager.instance.gameOver = true;
    }
}
