using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //public variables are controlled in unity's inspector
    private float speed = 5;
  
    //start is called before the first frame update;
    //think pre-game
    void Start()
    {
        //controls

    }

    // Update is called once per frame
    void Update()
    {
        float xMove = Input.GetAxisRaw("Horizontal");
        transform.Translate(speed * xMove * Time.deltaTime, 0, 0);
    }
}
