using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject _grappleLock1;
    public GameObject _hiddenPlatform1;
    public GameObject _grappleLock2;
    public GameObject _hiddenPlatform2;
    public GameObject _grappleLock3;
    public GameObject _hiddenPlatform3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_grappleLock1.GetComponent<GrappleLock>()._hasBeenUnlocked == true)
        {
            _hiddenPlatform1.SetActive(true);
        }

        if (_grappleLock2.GetComponent<GrappleLock>()._hasBeenUnlocked == true)
        {
            _hiddenPlatform2.SetActive(true);
        }
        if (_grappleLock3.GetComponent<GrappleLock>()._hasBeenUnlocked == true)
        {
            _hiddenPlatform3.SetActive(false);
        }
    }
}
