using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField]
    private float angle;

    private float _speed;

    private Vector3 _reflectedVector;

    private Rigidbody2D rb;

    private Vector2 _lastVelocity;

    public float force;

    private bool _addForce = false;

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
        _lastVelocity = rb.velocity;
    }

    public void Init()
    {
        Quaternion currentRotation = Quaternion.identity;

        currentRotation.eulerAngles = new Vector3(0, 0, angle);

        Vector3 dir = Quaternion.AngleAxis(currentRotation.eulerAngles.z, Vector3.forward) * Vector3.right;

        rb.AddForce(dir * force, ForceMode2D.Impulse);
    }

    public void ReflectBall(Vector3 normal)
    {
        _speed = _lastVelocity.magnitude;

        _reflectedVector = Vector3.Reflect(_lastVelocity.normalized, normal);

        rb.velocity = _reflectedVector * _speed;

    }
}
