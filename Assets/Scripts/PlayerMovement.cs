using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //public variables are controlled in unity's inspector
    public float speed = 10;

    //audio controls
    public AudioClip clipGood;
    public AudioClip clipBad;
    AudioSource audioSource;


    //spriterender controls
    SpriteRenderer playerSR;

    //connection to game manager script
    public GameManager gM;

    //start is called before the first frame update;
    //think pre-game
    void Start()
    {
        //controls
        audioSource = GetComponent<AudioSource>();
        playerSR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float xMove = Input.GetAxisRaw("Horizontal");
        transform.Translate(speed * xMove * Time.deltaTime, 0, 0);

        if( xMove < 0)
        {
            playerSR.flipX = true;
        }
        else if (xMove > 0)
        {
            playerSR.flipX = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if ((collision.tag == "textbooks") || (collision.tag == "nametag"))
        {
            //for demo game purpose -5points each
            audioSource.PlayOneShot(clipBad);
            Destroy(collision.gameObject);
            int tempValue = collision.gameObject.GetComponent<Item>().value;
            gM.ScoreCount(tempValue);


        }
        else if(collision.tag == "sleep") 
        {
            //for demo game purpose +10points
            audioSource.PlayOneShot(clipGood);
            Destroy(collision.gameObject);
            int tempValue = collision.gameObject.GetComponent<Item>().value;
            gM.ScoreCount(tempValue);
        }
        else if (collision.tag == "support")
        {
            //gameoverx
            //for demo game purpose +50points
            Debug.Log("Change Theme Icon");
            audioSource.PlayOneShot(clipGood);
            Destroy(collision.gameObject);
            int tempValue = collision.gameObject.GetComponent<Item>().value;
            gM.ScoreCount(tempValue);

        }
    }
    

}
