using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{  //Chinmay Pagey 20MIA1112
    public GameObject gameOverPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GameOver()
    {
        Invoke("ShowOverPanel", 2.0f);
    }
    void ShowOverPanel()
    {
        gameOverPanel.SetActive(true);
    }
    public void Restart()
    {
        Application.LoadLevel(Application.loadedLevelName);
    }
}
