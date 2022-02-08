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
    private Rigidbody2D rigidbody2dt;
    private CapsuleCollider2D capsuleCollider;
    private SpriteRenderer spriteRenderer;
    Vector2 lookDirection = new Vector2(1, 0);
    public float speed = 5;
    private float _movementDirection;
    public GameObject _projectileprefab;
    public GameObject _missilePrefab;
    public Transform projectilePosition;
    private bool _facingright = true;
    private bool _canJump = true;
    private bool _canGrapple = true;
    public float _currentHealth = 99f;
    public float _maxHealth = 99f;
    public bool _hasPickedUpGrapple = false;
    public bool _isMissileActive = false;
    public float _missileCount = 10f;
    public GameObject _morphBall;
    private GameObject _playerController;
    public GameObject _CinemachineCamera1;
    public GameObject _CinemachineCamera2;
    private SpriteRenderer _mbSpriteRenderer;
    private Rigidbody2D _mbRigidBody2d;
    private CircleCollider2D _mbCircleCollider2d;


    private void Awake()
    {
        animator = GetComponent<Animator>();
        rigidbody2dt = transform.GetComponent<Rigidbody2D>();
        rigidbody2d = GetComponent<Rigidbody2D>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        _mbSpriteRenderer = _morphBall.GetComponent<SpriteRenderer>();
        _mbRigidBody2d = _morphBall.GetComponent<Rigidbody2D>();
        _mbCircleCollider2d = _morphBall.GetComponent<CircleCollider2D>();
        

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
            Shoot();
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && _isMissileActive == false)
        {
            _isMissileActive = true;
        }
        else if (Input.GetKeyDown(KeyCode.LeftShift) && _isMissileActive == true)
        {
            _isMissileActive = false;
        }
        MorphBall();
        _morphBall.transform.position = this.transform.position;

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
    }
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _canJump == true)
        {
            float jumpVelocity = 15f;
            rigidbody2d.velocity = new Vector2(0, jumpVelocity);
            _canJump = false;
            StartCoroutine(jumpTimer());
        }
    }
    void Shoot()
    {
        if(Input.GetKeyDown(KeyCode.F) && _isMissileActive == false)
        {
            Instantiate(_projectileprefab, projectilePosition.position, projectilePosition.rotation);
            
        }
        else if (Input.GetKeyDown(KeyCode.F) && _isMissileActive == true && _missileCount > 0)
        {
            Instantiate(_missilePrefab, projectilePosition.position, projectilePosition.rotation);
            _missileCount -= 1;

        }
    }
    void Grapple()
    {
        if (Input.GetKeyDown(KeyCode.G) && _canGrapple == true && _hasPickedUpGrapple == true)
        {
            // fire grapple thing
            _canGrapple = false;
            StartCoroutine(grappleTimer());

        }
    }
    void MorphBall()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            spriteRenderer.enabled = false;
            rigidbody2d.isKinematic = true;
            capsuleCollider.enabled = false;
            _mbSpriteRenderer.enabled = true;
            _mbRigidBody2d.isKinematic = false;
            _mbCircleCollider2d.enabled = true;
            _CinemachineCamera1.SetActive(false);
            _CinemachineCamera2.SetActive(true);
            _morphBall.GetComponent<MorphBall>().enabled = true;
            this.enabled = false;
        }
    }

    private void characterDirection()
    {
        _facingright = !_facingright;
        transform.Rotate(0f, 180f, 0f);
    }
    IEnumerator jumpTimer()
    {
        yield return new WaitForSeconds(1f);
        _canJump = true;
    }
    IEnumerator grappleTimer()
    {
        yield return new WaitForSeconds(1.5f);
        _canGrapple = true;
    }

    public void Healing()
    {
        
        _currentHealth += 10f;

        if (_currentHealth >= _maxHealth)
        {
            _currentHealth = _maxHealth;
        }
    }

    public void Damage()
    {
        _currentHealth -= 10f;
    }

    public void pickedUpGrapple()
    {
        _hasPickedUpGrapple = true;
    }
}
