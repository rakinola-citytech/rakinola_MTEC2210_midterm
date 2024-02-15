using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //public variables are controlled in unity's inspector
    public float speed = 5;
    float turboSpeed = 10;
    float currentSpeed;
    SpriteRenderer sr;
    public Color turboColor;

    //start is called before the first frame update;
    //think pre-game
    void Start()
    {
        //controls
        sr = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space)){
            currentSpeed = turboSpeed;
            sr.color = turboColor;
        }
        else {
            currentSpeed = speed;
            sr.color = Color.white;
        }

        float xMove = Input.GetAxis("Horizontal");
        float yMove = Input.GetAxis("Vertical");
        transform.Translate(currentSpeed * xMove * Time.deltaTime, currentSpeed * yMove * Time.deltaTime, 0);

    }
}
