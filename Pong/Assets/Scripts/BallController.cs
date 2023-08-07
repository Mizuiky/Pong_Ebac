using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float _scalarValue;

    private Rigidbody2D _rb;

    private Vector2 _directionReflected;

    public bool _isGameRunning = false;

    public void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        Init();

        GameManager.Instance.onGameOver += StopBall;
    }

    void Update()
    {

       
    }

    private void FixedUpdate()
    {
        
    }

    public void Init()
    {
        _isGameRunning = true;
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

    public void ResetBall()
    {
        Invoke("ResetPosition", 0.2f);
    }

    public void ResetPosition()
    {
        if(_isGameRunning)
        {
            transform.position = new Vector2(0, 0);

            _rb.velocity = GetRandomDirection();
        }       
    }

    private void StopBall()
    {
        _isGameRunning = false;

        transform.position = new Vector2(0, 0);

        _rb.velocity = Vector2.zero;
    }

    public void ReflectBall(Vector2 normal, Vector2 relativeVelocity)
    {
        Debug.Log("normal " + normal);

        Debug.Log("relative velocity normalized " + relativeVelocity.normalized);

        Debug.Log("relative velocity " + relativeVelocity);

        _directionReflected = Vector2.Reflect(relativeVelocity, normal);

        Debug.Log("reflected " + _directionReflected);

        float currentSpeed = _rb.velocity.magnitude;

        _rb.velocity = _directionReflected.normalized * _scalarValue;

        Debug.Log("reflected normalized" + _directionReflected.normalized);

        Debug.Log("new velocity" + _rb.velocity);   
    }
}
