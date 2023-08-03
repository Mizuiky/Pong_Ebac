using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField]
    private float angle;

    public float minAngleBetweenCollisions;

    public float _scalarValue;

    private Rigidbody2D rb;

    private Vector2 _directionReflected;

    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        Init();
    }

    void Update()
    {

       
    }

    private void FixedUpdate()
    {
        
    }

    public void Init()
    {
        ResetPosition();
    }

    private Vector2 GetRandomDirection()
    {
        float x = Random.Range(-1, 2);
        float y = Random.Range(-1, 2);

        while(x == 0 || y == 0)
        {
            if(x == 0)
            {
                x = Random.Range(-1, 2);
            }
            else if(y == 0)
            {
                 y = Random.Range(-1, 2);
            }
        }

        Debug.Log("x" + x + "y" + y);
        return new Vector2(x * _scalarValue, y * _scalarValue);
    }

    public void ResetPosition()
    {
        transform.position = new Vector2(0, 0);

        rb.velocity = GetRandomDirection();
    }

    public void ReflectBall(Vector2 normal, Vector2 relativeVelocity)
    {
        Debug.Log("normal " + normal);

        Debug.Log("relative velocity normalized " + relativeVelocity.normalized);

        Debug.Log("relative velocity " + relativeVelocity);

        _directionReflected = Vector2.Reflect(relativeVelocity, normal);

        Debug.Log("reflected " + _directionReflected);

        float currentSpeed = rb.velocity.magnitude;

        rb.velocity = _directionReflected.normalized * _scalarValue;

        Debug.Log("reflected normalized" + _directionReflected.normalized);

        Debug.Log("new velocity" + rb.velocity);   
    }
}
