using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField]
    private KeyCode Up;

    [SerializeField]
    private KeyCode Down;

    [SerializeField]
    private float speed;

    private float _horizontal;
    private float _vertical;

    private Vector2 _movement;

    private Rigidbody2D _rb;

    private bool _isMoving;

    private Vector2 _initialPosition;

    private bool _isGameRunning = false;


    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _initialPosition = transform.position;

        _isGameRunning = true;

        GameManager.Instance.onResetGame += ResetBarPosition;
        GameManager.Instance.onGameOver += SetIsGameRunning;
    }

    void Update()
    {
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");

        _movement = new Vector2(_horizontal, _vertical);

        if (Input.GetKey(Up) || Input.GetKey(Down))
        {
            _isMoving = true;
        }
        else if (Input.GetKeyUp(Up) || Input.GetKeyUp(Down))
        {
            _isMoving = false;
        }
    }

    public void FixedUpdate()
    {
        if(_isMoving && _isGameRunning)
        {
            move();
        }
        else
        {
            _movement = new Vector2(0, 0);

            _rb.velocity = _movement;
        }       
    }

    private void move()
    {
        _rb.velocity += _movement * speed * Time.deltaTime;
    }

    private void ResetBarPosition()
    {
        transform.position = _initialPosition;

        _isGameRunning = true;
    }

    private void SetIsGameRunning()
    {
        _isGameRunning = false;
    }
}
