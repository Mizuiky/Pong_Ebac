using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player enter here");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("Player left here");
    }
}
