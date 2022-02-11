using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplosion : MonoBehaviour
{
    private GameObject _enemy;
    public void Awake()
    {
        _enemy = GameObject.FindWithTag("Enemy");
    }
    void Start()
    {
        Destroy(this.gameObject, 1f);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            _enemy.GetComponent<EnemyPatrol>().TakeDamage();
        }
    }
}