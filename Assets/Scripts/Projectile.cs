using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float _speed = 8.0f;
    private Rigidbody2D rigidbody;
    private GameObject _enemy;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        _enemy = GameObject.FindWithTag("Enemy");
    }
    private void Start()
    {
        rigidbody.velocity = transform.right * _speed;
        StartCoroutine(projectileTimeOut());
    }
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            _enemy.GetComponent<EnemyPatrol>().TakeDamage();
            Destroy(this.gameObject);
        }
        if (other.tag == "Ground")
        {
            Destroy(this.gameObject);
        }
    }

    IEnumerator projectileTimeOut()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(this.gameObject);
    }
}
