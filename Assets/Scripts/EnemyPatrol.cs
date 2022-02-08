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
    private void Awake()
    {
        _player = GameObject.FindWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        patrolSpeed = 8f;
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
        if (_turnAround)
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

    private void OnDestroy()
    {
        Instantiate(_healthDrop, transform.position, Quaternion.identity);
        Instantiate(_missileDrop, transform.position, Quaternion.identity);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _player.GetComponent<PlayerController>().Damage();
        }
    }
}
