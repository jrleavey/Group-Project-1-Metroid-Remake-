using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public GameObject _healthDrop;
    public GameObject _missileDrop;
    private GameObject _player;
    private bool _onPatrol = true;
    private Rigidbody2D rb;
    public float patrolSpeed;
    public Transform _checkGround;
    public bool _turnAround;
    public LayerMask _ground;
    public Collider2D _wallChecker;
    public float _health = 30;
    public AudioClip _enemyDamage;
    public GameObject enemyparticle;
    
    private void Awake()
    {
        _player = GameObject.FindWithTag("PlayerCore");
        rb = GetComponent<Rigidbody2D>();
        patrolSpeed = 3f;
    }
    void Start()
    {
        
    }
    void Update()
    {
        if (_onPatrol == true)
        {
            patrol();
        }

    }
    private void FixedUpdate()
    {
        if (_onPatrol)
        {
            _turnAround = !Physics2D.OverlapCircle(_checkGround.position, 0.1f, _ground);
        }
    }
    void patrol()
    {
        if (_turnAround || _wallChecker.IsTouchingLayers(_ground))
        {
            reverse();
        }
        rb.velocity = new Vector2(patrolSpeed, rb.velocity.y);
    }
    void reverse()
    {
        _onPatrol = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        patrolSpeed *= -1;
        _onPatrol = true;
    }

   public void TakeDamage()
    {
        _health -= 5;
    } public void TakeMissileDamage()
    {
        _health -= 30;
    }
    private void Death()
    {
        Instantiate(_healthDrop, transform.position, Quaternion.identity);
        Instantiate(_missileDrop, transform.position, Quaternion.identity);
        Instantiate(enemyparticle, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _player.GetComponent<PlayerController>().Damage();
        }
        if (other.tag == "Attack")
        {
            TakeDamage();
            AudioSource.PlayClipAtPoint(_enemyDamage, transform.position);

            if (_health <= 0)
            {
                Death();
            }
        }
    }
}
