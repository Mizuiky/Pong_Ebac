using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCollision : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clip;

    public BallController ball;

    public string tagToCompare = "Ball";

    public PlayerType player;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag(tagToCompare))
        {
            ball = collision.gameObject.GetComponent<BallController>();

            if(ball != null)
            {
                GameManager.Instance.scoreController.SetPoints(player);

                if (audioSource != null && clip != null)
                {
                    audioSource.clip = clip;
                    audioSource.Play();

                    audioSource.clip = null;
                }

                ball.ResetPosition();
            }
        }
    }
}
