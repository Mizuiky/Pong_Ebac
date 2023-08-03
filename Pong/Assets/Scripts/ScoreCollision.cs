using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCollision : MonoBehaviour
{
    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            BallController ball = collision.gameObject.GetComponent<BallController>();

            if(ball != null)
            {
                ball.ResetPosition();

            }
        }
    }
}
