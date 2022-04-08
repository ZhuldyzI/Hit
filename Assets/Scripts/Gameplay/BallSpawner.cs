using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject prefabBall;

    CountDownBeforeBallSpawn timer;


    void Start()
    {
        timer = GameObject.FindGameObjectWithTag("ThreeSecondsTimer").GetComponent<CountDownBeforeBallSpawn>();
        timer.Run();
    }
    

    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Ball")==null && timer.ReadyToSpawn == true && LivesCounter.ShowLives > 0)
        {
            Instantiate(prefabBall);
        }
        if(GameObject.FindGameObjectWithTag("Ball") == null && timer.ReadyToSpawn == true && LivesCounter.ShowLives <= 0)
        {
            SceneManager.LoadScene("GameOver");        }
    }
}
