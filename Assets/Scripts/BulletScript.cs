using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    int speed = 10;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, speed * Time.deltaTime, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
  
        /*else if (collision.tag == "Ground")
        {
            Destroy(gameObject);
        }*/

        if (collision.tag == "Ground")
        {
            Destroy(gameObject);
        }
    }
}
