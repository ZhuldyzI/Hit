using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static class LivesCounter 
{
    static int livesLeft = 5;

    static int scores = 0;

    //decrease one life if ball falls
    public static void LoseOneLife()
    {
        livesLeft -= 1;
    }
    public static int ShowLives
    {
        get { return livesLeft; }
    }

    public static int ShowScores
    {
        get { return scores; }
    }
    public static void IncreaseScores()
    {

        scores+=1*LivesCounter.ShowLives;
    }
}
