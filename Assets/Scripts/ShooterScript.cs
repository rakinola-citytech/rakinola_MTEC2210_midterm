using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterScript : MonoBehaviour
{
    public GameObject bulletPrefab;

    //public variables are controlled in unity's inspector
    public float speed = 10;

    //spriterender controls
    SpriteRenderer playerSR;

    // Start is called before the first frame update
    void Start()
    {
        playerSR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float xMove = Input.GetAxisRaw("Horizontal");
        transform.Translate(speed * xMove * Time.deltaTime, 0, 0);

        if (xMove < 0)
        {
            playerSR.flipX = true;
        }
        else if (xMove > 0)
        {
            playerSR.flipX = false;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnBullet();
        }
    }
    void SpawnBullet()
    {
        Instantiate(bulletPrefab, transform.position, Quaternion.identity);
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Player")
        {
            Destroy(collision.gameObject);
        }
    }*/
}
