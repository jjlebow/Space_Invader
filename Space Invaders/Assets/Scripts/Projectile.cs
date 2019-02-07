using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 12.5f;

    private Collider2D projectileCollider2D;

    private float upperY;

    // Start is called before the first frame update
    void Start()
    {
        projectileCollider2D = this.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(new Vector3(0f, speed * Time.deltaTime));

        if (this.transform.position.y >= 5) //Projectile destroyed when leaving screen
            Destroy(this.gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.collider.CompareTag("Player"))
            Destroy(this.gameObject); //Projectile destroyed when hitting an enemy
    }
}
