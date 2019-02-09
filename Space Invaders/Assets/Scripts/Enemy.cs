using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject enemyProjectile;
    private Collider2D enemyCollider2D;

    // Start is called before the first frame update
    void Start()
    {
        enemyCollider2D = this.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 bottomPosition = new Vector2(this.transform.position.x, enemyCollider2D.bounds.min.y);
        RaycastHit2D detection = Physics2D.Raycast(bottomPosition, Vector2.down, 0.5f);

        if (!detection.collider)
            Shoot();
    }

    void Shoot()
    {
        if (Random.value <= .003f) //20% chance it'll fire a projectile during a second
            Instantiate(enemyProjectile, this.transform.position, Quaternion.identity);
    }

    void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.CompareTag("Projectile"))
		{	
			Destroy(collider.gameObject);
			Destroy(gameObject);

            if (gameObject.tag == "Enemy Top")
                LevelManager.instance.AddScore(40);

            if (gameObject.tag == "Enemy Middle")
                LevelManager.instance.AddScore(20);

            if (gameObject.tag == "Enemy Bottom")
                LevelManager.instance.AddScore(10);
		}
	}
}
