using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCollision : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clip;

    public string tagToCompare = "Ball";

    public PlayerType player;

    private BallController _ball;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag(tagToCompare))
        {
            _ball = collision.gameObject.GetComponent<BallController>();

            if(_ball != null)
            {
                GameManager.Instance.scoreController.SetPoints(player);

                _ball.ResetBall();

                if (audioSource != null && clip != null)
                {
                    audioSource.clip = clip;
                    audioSource.Play();
                }                
            }
        }
    }
}
