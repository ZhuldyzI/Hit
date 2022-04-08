using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField]
    GameObject LivesLeftUI;
    TextMeshProUGUI LivesToDisplay;


    [SerializeField]
    GameObject ScoresToDisplay;
    TextMeshProUGUI ScoresText;


    void Start()
    {
        LivesToDisplay = LivesLeftUI.GetComponent<TextMeshProUGUI>();

        //add values to lives
        LivesToDisplay.text = "Lives left: "+LivesCounter.ShowLives.ToString();

        //add values to score
        ScoresText = ScoresToDisplay.GetComponent<TextMeshProUGUI>();
    }


    // Update is called once per frame
    void Update()
    {
        // update lives
        LivesToDisplay.text = "Lives left: " + LivesCounter.ShowLives.ToString();

        //update scores

        ScoresText.text = "Score: " + LivesCounter.ShowScores.ToString();

    }
}
