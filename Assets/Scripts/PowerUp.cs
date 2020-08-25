using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ataque"))
        {
            gameObject.SetActive(false);
            other.GetComponentInParent<PlayerControll>().shield.SetActive(true);
        }
    }
}
