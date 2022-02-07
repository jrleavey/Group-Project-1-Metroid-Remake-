using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapple : MonoBehaviour
{
    private GameObject _player;
    private void Awake()
    {
        _player = GameObject.FindWithTag("Player");
        _player.GetComponent<PlayerController>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _player.GetComponent<PlayerController>().pickedUpGrapple();
            Destroy(this.gameObject);
        }
    }
}
