using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public AudioClip _sound;
    // Start is called before the first frame update
    void Start()
    {
        AudioSource.PlayClipAtPoint(_sound, transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
