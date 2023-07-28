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

    private Rigidbody2D rb;

    private bool _isMoving;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
        if(_isMoving)
        {
            move();
        }
        else
        {
            _movement = new Vector2(0, 0);

            rb.velocity = _movement;
        }       
    }

    private void move()
    {
        rb.velocity += _movement * speed * Time.deltaTime;
    }
}
