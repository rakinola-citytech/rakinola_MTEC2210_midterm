using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadObject_Script : MonoBehaviour
{
    private float yMove = -3;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, yMove * Time.deltaTime, 0);
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("We collided");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Destroy(gameObject);
            Debug.Log("Bad Object");
        }
    }
}
