using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour
{
    float horizontal;
    float vertical;
    Animator animator;
    private Rigidbody2D rigidbody2d;
    private Rigidbody2D rigidbody2dt;
    private CapsuleCollider2D capsuleCollider;
    private CircleCollider2D circleCollider;
    Vector2 lookDirection = new Vector2(1, 0);
    public float speed = 5;
    private float _movementDirection;
    public GameObject _projectileprefab;
    public GameObject _missilePrefab;
    public GameObject _grapplePrefab;
    public GameObject _mbBombPrefab;
    public Transform projectilePosition;
    public Transform grapplePosition;
    private bool _facingright = true;
    private bool _canJump = true;
    public bool _canGrapple = true;
    public float _currentHealth = 99f;
    public float _maxHealth = 99f;
    public bool _hasPickedUpGrapple = false;
    public bool _isMissileActive = false;
    public float _missileCount = 10f;
    public GameObject _CinemachineCamera1;
    public GameObject _CinemachineCamera2;
    public Text healthText;
    public Text missileText;
    public bool _isInMorphBall = false;
    public bool _canMorphBall = true;
    public GameObject _defaultCharacter;
    public GameObject _morphBall;
    private SpriteRenderer _defaultRenderer;
    private SpriteRenderer _morphBallRenderer;
    public AudioClip _pickupHealth;
    public AudioClip _pickupMissiles;
    public AudioClip _pickupGrapple;
    public AudioClip _swapMissiles;
    public AudioClip _shootProjectile;
    public AudioClip _shootMissile;
    public GameObject _uiManager;
    public bool _canStandUp = true;
    private BoxCollider2D _ceilingChecker;
    public GameObject _tileMap;
    private TilemapCollider2D _tileMapCollider;
    public LayerMask _ground;




    private void Awake()
    {
        animator = GetComponent<Animator>();
        rigidbody2dt = transform.GetComponent<Rigidbody2D>();
        rigidbody2d = GetComponent<Rigidbody2D>();
        capsuleCollider = GetComponentInChildren<CapsuleCollider2D>();
        circleCollider = GetComponentInChildren<CircleCollider2D>();
        _defaultRenderer = _defaultCharacter.GetComponent<SpriteRenderer>();
        _morphBallRenderer = _morphBall.GetComponent<SpriteRenderer>();
        _ceilingChecker = GetComponentInChildren<BoxCollider2D>();
        _tileMapCollider = GetComponent<TilemapCollider2D>();
        
    }
    void Start()
    {

    }

    void Update()
    { 
        
        healthText.text = "" + _currentHealth;
        missileText.text = "MISSILES " + _missileCount;
        
        Movement();
        Jump();
        if (Input.GetKeyDown(KeyCode.F))
        {
            Shoot();
        }

        MorphBall();
        Swap();
        Grapple();
        if (_currentHealth <= 0)
        {
            GameOverSequence();
        }
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
        if (Input.GetKeyDown(KeyCode.F) && _isMissileActive == false && _isInMorphBall == false)
        {
            AudioSource.PlayClipAtPoint(_shootProjectile, transform.position);
            Instantiate(_projectileprefab, projectilePosition.position, projectilePosition.rotation);

        }
        else if (Input.GetKeyDown(KeyCode.F) && _isMissileActive == true && _missileCount > 0 && _isInMorphBall == false)
        {
            AudioSource.PlayClipAtPoint(_shootMissile, transform.position);
            Instantiate(_missilePrefab, projectilePosition.position, projectilePosition.rotation);
            _missileCount -= 1;
        }
        if (Input.GetKeyDown(KeyCode.F) && _isInMorphBall == true)
        {
            Instantiate(_mbBombPrefab, projectilePosition.position, projectilePosition.rotation);
        }
    }
    void Swap()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && _isMissileActive == false)
        {
            AudioSource.PlayClipAtPoint(_swapMissiles, transform.position);
            _isMissileActive = true;
        }
        else if (Input.GetKeyDown(KeyCode.LeftShift) && _isMissileActive == true)
        {
            AudioSource.PlayClipAtPoint(_swapMissiles, transform.position);
            _isMissileActive = false;
        }
    }
    void Grapple()
    {
        if (Input.GetKeyDown(KeyCode.G) && _canGrapple == true && _hasPickedUpGrapple == true && _isInMorphBall == false)
        {
            Instantiate(_grapplePrefab, grapplePosition.position, Quaternion.identity, this.transform);
            _canGrapple = false;
            StartCoroutine(grappleTimer());
        }
    }
    void MorphBall()
    {
        if (Input.GetKeyDown(KeyCode.V) && _isInMorphBall == false && _canMorphBall == true)
        {
            circleCollider.enabled = true;
            capsuleCollider.enabled = false;
            _ceilingChecker.enabled = true;
            _isInMorphBall = true;
            _canMorphBall = false;
            _defaultRenderer.enabled = false;
            _morphBallRenderer.enabled = true;
            StartCoroutine(MorphBallDelay());

        }
        else if (Input.GetKeyDown(KeyCode.V) && _isInMorphBall == true && _canMorphBall == true && _canStandUp == true)
        {
            capsuleCollider.enabled = true;
            circleCollider.enabled = false;
            _ceilingChecker.enabled = false;
            _isInMorphBall = false;
            _canMorphBall = false;
            _defaultRenderer.enabled = true;
            _morphBallRenderer.enabled = false;
            StartCoroutine(MorphBallDelay());

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
        AudioSource.PlayClipAtPoint(_pickupHealth, transform.position);
        _currentHealth += 10f;

        if (_currentHealth >= _maxHealth)
        {
            _currentHealth = _maxHealth;
        }
    }
    public void ReplenishMissile()
    {
        AudioSource.PlayClipAtPoint(_pickupMissiles, transform.position);
        _missileCount += 10f;
    }    

    public void Damage()
    {
        _currentHealth -= 10f;
    }

    public void pickedUpGrapple()
    {
        AudioSource.PlayClipAtPoint(_pickupGrapple, transform.position);
        _hasPickedUpGrapple = true;
    }
    public void PlayerDeath()
    {
        
    }
    IEnumerator MorphBallDelay()
    {
        yield return new WaitForSeconds(1f);
        _canMorphBall = true;
    }
   public void ceilingcheck()
    {
        {
            Debug.Log("Can't Stand");
            _canStandUp = false;
        }
    }

    public void ceilingcheckdone()
    {
        _canStandUp = true;
    }

    public void GameOverSequence()
    {
        // activate menu
        //destroy this gameobject
    }
}
