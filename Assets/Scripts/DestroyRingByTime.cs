using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyRingByTime : MonoBehaviour
{
    public float destroyTimer = 3;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, destroyTimer);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
