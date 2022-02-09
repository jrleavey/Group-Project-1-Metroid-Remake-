using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMap : MonoBehaviour
{

    public GameObject _player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "CeilingChecker")
        {
            Debug.Log("CeilingCheck");
            _player.GetComponent<PlayerController>().ceilingcheck();
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "CeilingChecker")
        {
            Debug.Log("CeilingCheckDone");
            _player.GetComponent<PlayerController>().ceilingcheckdone();
        }
    }
}
