using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownBellow : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerControll>().Died();
        }
    }
}
