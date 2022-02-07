using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public GameObject _healthDrop;
    private GameObject _player;
    private void Awake()
    {
        _player = GameObject.FindWithTag("Player");
    }
    void Start()
    {
        
    }
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        Instantiate(_healthDrop, transform.position, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _player.GetComponent<PlayerController>().Damage();
        }
    }
}
