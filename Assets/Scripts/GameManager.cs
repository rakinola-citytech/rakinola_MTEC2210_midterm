using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GameManager : MonoBehaviour
{
    //player interaction items
    public GameObject[] items;

    //spawn boundaries
    public Transform northPoint;
    public Transform southPoint;

    //spawn speed
    float spawnDelay = 0.5f;
    float timeElapsed = 0;

    //score count
    public int score;
    public TextMeshPro scoreText;

    //spawnCount & making transistion icon rare
    int spawnCount = 0;

    void Start()
    {
        //SpawnGoodObject();
        //InvokeRepeating("SpawnGoodObject", 2, 2);

    }

    void Update()
    {
        //Timer
        if (timeElapsed < spawnDelay)
        {
            timeElapsed += Time.deltaTime;
        }
        else
        {
            //attempting to make transistion icon rare
            SpawnObject();
            timeElapsed = 0;
            spawnCount += 2;
            //Debug.Log(spawnCount);
            if(spawnCount >= 50)
            {
                Debug.Log(spawnCount);
                Instantiate(items[3], SpawnPos(), Quaternion.identity);
                spawnCount = 0;
                Debug.Log(spawnCount);
            }
            
            
        }

        //score update
        scoreText.text = "SCORE:" + score.ToString();

    }

    public void SpawnObject() 
    {
        //spawnCode
        int rnd = Random.Range(0, items.Length-1);
        GameObject clone1 = Instantiate(items[rnd], SpawnPos(), Quaternion.identity);
        GameObject clone2 = Instantiate(items[rnd], SpawnPos(), Quaternion.identity);
        clone1.GetComponent<Item>().itemSpeed = Random.Range(-5, -2);
        clone2.GetComponent<Item>().itemSpeed = Random.Range(-4, -1);

        
    }

    private Vector2 SpawnPos()
    {
        float xValue = Random.Range(northPoint.position.x, southPoint.position.x);
        float yValue = northPoint.position.y;
        Vector2 temp = new Vector2(xValue, yValue);
        return (temp);
    }

    public void ScoreCount(int value)
    {
        score += value;
    }
   
    
}