using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D rd;
    BoxCollider2D collHalf;
    float paddleWidthHalf;
    const float BounceAngleHalfRange = 60 * Mathf.PI / 180;

    AudioSource hitSound;


    // Start is called before the first frame update
    void Start()
    {
        rd = gameObject.GetComponent<Rigidbody2D>();
        collHalf = gameObject.GetComponent<BoxCollider2D>();
        paddleWidthHalf = collHalf.size.x/2*0.2f;

        hitSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {   
    }
    private void FixedUpdate()
    {
        Vector2 position = gameObject.transform.position;
        float input = Input.GetAxis("Horizontal");

        if (input!= 0)
        {
            position.x += ConfigurationUtils.PaddleMoveUnitsPerSecond*input*Time.deltaTime;
            position.x=CalculateClampedX(position.x);
            rd.MovePosition(position);               
        }
    }
    //make it so that paddle does not go outside the screen on x axis
    float CalculateClampedX(float x)
    {
        if ((x-paddleWidthHalf) < ScreenUtils.ScreenLeft)
        {
            x = ScreenUtils.ScreenLeft + paddleWidthHalf+0.1f;
        }
        else if ((x+paddleWidthHalf) > ScreenUtils.ScreenRight)
        {
            x = ScreenUtils.ScreenRight - paddleWidthHalf - 0.1f;
        }
        return x;
    }
    /// <summary>
    /// Detects collision with a ball to aim the ball
    /// </summary>
    /// <param name="coll">collision info</param>
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Ball"))
        {
            // calculate new ball direction
            float ballOffsetFromPaddleCenter = transform.position.x -
                coll.transform.position.x;
            float normalizedBallOffset = ballOffsetFromPaddleCenter /
                paddleWidthHalf;
            float angleOffset = normalizedBallOffset * BounceAngleHalfRange;
            float angle = Mathf.PI / 2 + angleOffset;
            Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

            // tell ball to set direction to new direction
            Ball ballScript = coll.gameObject.GetComponent<Ball>();
            ballScript.SetDirection(direction);

            //make a hit sound
            hitSound.Play();
        }
    }
    bool topCollisionDetection(Collider2D coll)
    {
        const float tolerance = 0.05f;

        // on top collisions, both contact points are at the same y location
        ContactPoint2D[] contacts = new ContactPoint2D[2];
        coll.GetContacts(contacts);
        return Mathf.Abs(contacts[0].point.y - contacts[1].point.y) < tolerance;
    }


}
