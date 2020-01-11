using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float scrollSpeed = 5f;
    public GameObject[] obstacles;
    public float frequency = 0.5f;
    float counter = 0f;
    public Transform spawnPoint;
    void Start()
    {
        generateObstacles();
    }

    void Update()
    {
        if (counter <= 0f)
        {
            generateObstacles();
        }
        else
        {
            counter -= Time.deltaTime * frequency;
        }
        GameObject obstacle;
        for(int i=0; i < transform.childCount; i++)
        {
            obstacle = transform.GetChild(i).gameObject;
            scroll(obstacle);
            if (obstacle.transform.position.x <= -15f) Destroy(obstacle);
        }
    }

    void scroll(GameObject obstacle)
    {
        obstacle.transform.position -= Vector3.right * (scrollSpeed * Time.deltaTime);
    }
    void generateObstacles()
    {
        GameObject newObstacle = Instantiate(obstacles[Random.Range(0, obstacles.Length)], spawnPoint.position, Quaternion.identity);
        newObstacle.transform.parent = transform;
        newObstacle.transform.localScale = new Vector3(Random.Range(1, 5), Random.Range(1, 5));
        counter = 1f;
    }
}
