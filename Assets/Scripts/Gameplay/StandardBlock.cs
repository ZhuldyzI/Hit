using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardBlock : MonoBehaviour
{
    public int necessaryHitCount;
    public virtual void Start()
    {
        necessaryHitCount = 1;
    }

    public virtual void OnCollisionEnter2D()
    {
        necessaryHitCount--;
        if (necessaryHitCount == 0)
        {
            Destroy(gameObject);
            LivesCounter.IncreaseScores();

        }
    }
}
