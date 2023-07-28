using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float speed;

    private Vector2 _direction;

    [SerializeField]
    private float angle;

    private Rigidbody2D rb;

    void Start()
    {
        
    }

    void Update()
    {
        ChangeAngle();
    }

    public void ChangeAngle()
    {
        Quaternion currentRotation = Quaternion.identity;

        currentRotation.eulerAngles = new Vector3(0, 0, angle);

        transform.rotation = currentRotation;
    }


}
