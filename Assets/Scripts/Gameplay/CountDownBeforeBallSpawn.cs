using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountDownBeforeBallSpawn : MonoBehaviour
{
    float threeSecondsToCountDown;
    int timeLeftToShow;
    TextMeshProUGUI timeLeft;

    //
    bool readyToSpawn = false;
    bool timerToStart = false;
    

    //show if countdown is ready or not
    public bool ReadyToSpawn
    {
        get { return readyToSpawn; }
    }

    void Start()
    {
        timeLeft = GameObject.FindGameObjectWithTag("ThreeSecondsTimer").GetComponent<TextMeshProUGUI>();
        timeLeft.text = timeLeftToShow.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (timerToStart == true) {
            threeSecondsToCountDown -= Time.deltaTime;
            timeLeftToShow = (int)threeSecondsToCountDown;
            timeLeft.text = timeLeftToShow.ToString();
            if (threeSecondsToCountDown <= 1)
            {
                readyToSpawn = true;
                Destroy(gameObject);
                timerToStart = false;
            }
        }
    }

    public void Run()
    {
        threeSecondsToCountDown = 3.0f;
        timerToStart = true;
    }

}
