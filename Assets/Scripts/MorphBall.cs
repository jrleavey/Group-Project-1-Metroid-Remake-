using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MorphBall : MonoBehaviour
{
    float horizontal;
    float vertical;
    private Rigidbody2D rigidbody2dt;
    private Rigidbody2D rigidbody2d;
    private CircleCollider2D _circleCollider;
    private SpriteRenderer _spriteRenderer;
    public float speed = 5;
    private float _movementDirection;
    private bool _facingright = true;
    public GameObject _player;
    private SpriteRenderer _playerSpriteRenderer;
    private Rigidbody2D _playerRigidBody2d;
    private CapsuleCollider2D _playerCapsuleCollider2d;
    public GameObject _CinemachineCamera1;
    public GameObject _CinemachineCamera2;
    private Transform _playerLocation;




    private void Awake()
    {
        rigidbody2dt = transform.GetComponent<Rigidbody2D>();
        rigidbody2d = GetComponent<Rigidbody2D>();
        _circleCollider = GetComponent<CircleCollider2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _playerSpriteRenderer = _player.GetComponent<SpriteRenderer>();
        _playerRigidBody2d = _player.GetComponent<Rigidbody2D>();
        _playerCapsuleCollider2d = _player.GetComponent<CapsuleCollider2D>();
        _playerLocation = _player.transform;


    }
    void Start()
    {
        rigidbody2d.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        EndMorphBall();
    }
    void Movement()
    {
        _movementDirection = Input.GetAxis("Horizontal");

        rigidbody2dt.velocity = new Vector2(_movementDirection * speed, rigidbody2dt.velocity.y);

        if (_movementDirection > 0 && !_facingright)
        {
            characterDirection();
        }
        else if (_movementDirection < 0 && _facingright)
        {
            characterDirection();
        }
        _playerLocation = this.transform;
    }
    private void characterDirection()
    {
        _facingright = !_facingright;
        transform.Rotate(0f, 180f, 0f);
    }
    void EndMorphBall()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            _spriteRenderer.enabled = false;
            rigidbody2d.isKinematic = true;
            _circleCollider.enabled = false;
            _playerCapsuleCollider2d.enabled = true;
            _playerRigidBody2d.isKinematic = false;
            _playerSpriteRenderer.enabled = true;
            _CinemachineCamera1.SetActive(true);
            _CinemachineCamera2.SetActive(false);
            _player.GetComponent<PlayerController>().enabled = true;
            this.enabled = false;
        }
    }
 
}
