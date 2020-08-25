using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D  other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerControll>().HadShot();
        }
        else if (other.CompareTag("Ataque"))
        {
            other.GetComponentInParent<PlayerControll>().shield.SetActive(false);
            gameObject.SetActive(false);
        }
    }

}
