
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChallengeScroll : MonoBehaviour
{ public float scrollSpeed = 5.0f;
    public GameObject[] challenges;
    public float frequency = 0.5f;
    float counter = 0.0f;
    public Transform challengesSpawnPoint;
    bool isGameOver = false;
    //Chinmay Pagey 20MIA1112
    // Start is called before the first frame update
    void Start()
    {
        GenerateRandomObstacle();
    }

    // Update is called once per frame
    void Update()
    {   if (isGameOver)
        {
            return;
        }
        if (counter <= 0.0f)
        {
            GenerateRandomObstacle();
        }
        else
        {
            counter -= Time.deltaTime * frequency;
        }
        GameObject currentChild;
        for(int i=0; i < transform.childCount; i++)
        {
            currentChild = transform.GetChild(i).gameObject;
            ScrollChallenge(currentChild);
            if(currentChild.transform.position.x<= -20.0f)
            {
                Destroy(currentChild);
            }
        }
    }

    void ScrollChallenge(GameObject currentChallenge)
    {
        currentChallenge.transform.position -= Vector3.right * (scrollSpeed * Time.deltaTime);
    }

    void GenerateRandomObstacle()
    {
        
        GameObject newChallenge = Instantiate(challenges[Random.Range(0, challenges.Length)], challengesSpawnPoint.position,Quaternion.identity) as GameObject;
        newChallenge.transform.parent = transform;
        counter = 1.0f;
    }
    public void GameOver()
    {
        isGameOver = true;
        transform.GetComponent<GameController>().GameOver();
    }
}
