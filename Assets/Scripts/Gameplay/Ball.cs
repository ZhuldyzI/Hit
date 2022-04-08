using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    GameObject Paddle;
    public int lives;

    void Start()
    {
        lives = 5;
        float angle = 20 * Mathf.PI / 180;
        Rigidbody2D rdBall = gameObject.GetComponent<Rigidbody2D>();
        Vector2 ballMove = new Vector2(ConfigurationUtils.BallImpulseForce*Mathf.Cos(angle), ConfigurationUtils.BallImpulseForce * Mathf.Sin(angle));
        rdBall.AddForce(ballMove, ForceMode2D.Impulse);
    }


    public void SetDirection(Vector2 direction)
    {
        Rigidbody2D rd = gameObject.GetComponent<Rigidbody2D>();
        direction.Normalize();
        rd.velocity = direction*rd.velocity.magnitude;

    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
        LivesCounter.LoseOneLife();
    }

}
