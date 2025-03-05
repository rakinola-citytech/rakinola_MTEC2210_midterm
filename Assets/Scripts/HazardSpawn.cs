using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardSpawn : MonoBehaviour
{
    public GameObject HarzardPrefab;

    //spawn boundaries
    public Transform northPoint;
    public Transform southPoint;

    //spawn speed
    float spawnDelay = 5;
    float timeElapsed = 0;

    // Start is called before the first frame update
    void Start()
    {

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
            SpawnObject();
        }
    }

    public void SpawnObject()
    {
        GameObject clone = Instantiate(HarzardPrefab, SpawnPos(), HarzardPrefab.transform.rotation);
        clone.GetComponent<Item>().itemSpeed = Random.Range(-5, -2);
        //Debug.Log(gameObject.name);
    }

    private Vector2 SpawnPos()
    {
        float xValue = Random.Range(northPoint.position.x, southPoint.position.x);
        float yValue = northPoint.position.y;
        Vector2 temp = new Vector2(xValue, yValue);
        return (temp);
    }

}
