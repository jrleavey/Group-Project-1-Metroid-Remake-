using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    float horizontal;
    float vertical;
    Animator animator;
    private Rigidbody2D rigidbody2d;
    Vector2 lookDirection = new Vector2(1, 0);
    public float speed = 5;
    private float _movementDirection;
    public GameObject _projectileprefab;
    public Transform projectilePosition;
    private bool _facingright = true;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rigidbody2d = transform.GetComponent<Rigidbody2D>();
    }
    void Start()
    {

    }

    void Update()
    {
        Movement();
        Jump();
        if (Input.GetKeyDown(KeyCode.F))
        {
            shoot();
        }

    }
    void Movement()
    {
        _movementDirection = Input.GetAxis("Horizontal");

        rigidbody2d.velocity = new Vector2(_movementDirection * speed, rigidbody2d.velocity.y);

        if (_movementDirection > 0 && !_facingright)
        {
            characterDirection();
        }
        else if (_movementDirection < 0 && _facingright)
        {
            characterDirection();
        }
    }
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            float jumpVelocity = 10f;
            rigidbody2d.velocity = new Vector2(0, jumpVelocity);
        }
    }
    void shoot()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            Instantiate(_projectileprefab, projectilePosition.position, projectilePosition.rotation);
            //audio source play
        }
    }

    private void characterDirection()
    {
        _facingright = !_facingright;
        transform.Rotate(0f, 180f, 0f);
    }
}
