using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject _grappleLock1;
    public GameObject _hiddenPlatform1;
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
    }
}
