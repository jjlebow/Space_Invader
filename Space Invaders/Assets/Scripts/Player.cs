using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D playerRigidbody2D;
    private Collider2D playerCollider2D;

    public int speed = 5;

    public GameObject projectile;

    public GameObject left_bound;
    public GameObject right_bound;

    private float left_x;
    private float right_x;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody2D = this.GetComponent<Rigidbody2D>();
        playerCollider2D  = this.GetComponent<Collider2D>();

        left_x            = left_bound.transform.position.x;
        right_x           = right_bound.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) || Input.GetKey(KeyCode.Space))
        {
            Shoot();
        }

        Move();
    }

    void Move()
    {
        float movementModifier = Input.GetAxisRaw("Horizontal");

        if (this.transform.position.x >= right_x && movementModifier > 0)
        {
            movementModifier = 0;
        }

        if (this.transform.position.x <= left_x && movementModifier < 0)
        {
            movementModifier = 0;
        }

        playerRigidbody2D.velocity = new Vector2(movementModifier * speed * Time.deltaTime, 0);
    
    }

    void Shoot()
    {
        if (!GameObject.Find("PlayerProjectile(Clone)"))
            Instantiate(projectile, this.transform.position, Quaternion.identity);
    }

}
