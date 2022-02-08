using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissilePickup : MonoBehaviour
{
    private GameObject _player;
    private void Awake()
    {
        _player = GameObject.FindWithTag("Player");
    }
    void Start()
    {
        StartCoroutine(healthDecayTime());
    }


    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _player.GetComponent<PlayerController>().ReplenishMissile();
            Destroy(this.gameObject);
        }
    }
    IEnumerator healthDecayTime()
    {
        yield return new WaitForSeconds(5f);
        Destroy(this.gameObject);
    }
}
