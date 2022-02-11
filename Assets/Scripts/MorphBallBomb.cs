using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MorphBallBomb : MonoBehaviour
{
    public GameObject _explosionPrefab;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DelaytoExplode());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator DelaytoExplode()
    {
        yield return new WaitForSeconds(2f);
        Instantiate(_explosionPrefab, transform.position, transform.rotation);
        Destroy(this.gameObject);
           
    }
}
