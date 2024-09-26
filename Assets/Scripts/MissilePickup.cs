using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissilePickup : MonoBehaviour
{
    private GameObject _player;
    void Start()
    {
        _player = GameObject.FindWithTag("PlayerCore");
        StartCoroutine(healthDecayTime());
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
