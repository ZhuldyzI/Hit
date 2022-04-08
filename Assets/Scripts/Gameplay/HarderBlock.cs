using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarderBlock : StandardBlock
{
    SpriteRenderer colorChange;
    // Start is called before the first frame update
    public override void Start()
    {
        necessaryHitCount = 2;
        colorChange = gameObject.GetComponent<SpriteRenderer>();
    }

    public override void OnCollisionEnter2D()
    {
        necessaryHitCount--;
        if (necessaryHitCount == 0)
        {
            Destroy(gameObject);
            LivesCounter.IncreaseScores();
        }
        else
        {
            colorChange.color = Color.white;
        }
    }

}
