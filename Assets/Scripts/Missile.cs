using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public float _speed = 6.0f;
    private Rigidbody2D rigidbody;
    public GameObject _enemy;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        rigidbody.velocity = transform.right * _speed;
    }
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            _enemy.GetComponent<EnemyPatrol>().TakeMissileDamage();
            Destroy(this.gameObject);
        }
        if (other.tag == "Ground")
        {
            Destroy(this.gameObject);
        }
    }
}