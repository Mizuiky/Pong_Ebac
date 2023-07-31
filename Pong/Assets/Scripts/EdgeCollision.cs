using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeCollision : MonoBehaviour
{
    public string tagToCompare = "Ball";

    private ContactPoint2D _contactPoint;
    private BallController _ball;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag(tagToCompare))
        {
            _contactPoint = collision.GetContact(0);

            _ball = collision.gameObject.GetComponent<BallController>();

            _ball.ReflectBall(_contactPoint.normal);
        }
    }
}
