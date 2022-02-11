using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleLock : MonoBehaviour
{
    private CircleCollider2D circleCollider2D;
    public bool _hasBeenUnlocked = false;
    // Start is called before the first frame update
    void Start()
    {
        circleCollider2D = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Grapple")
        {
            _hasBeenUnlocked = true;
        }
    }
}
