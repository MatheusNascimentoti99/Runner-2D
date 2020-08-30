using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mola : MonoBehaviour
{
    public float impulseForce;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody2D rigidbody2 = other.GetComponent<Rigidbody2D>();
            rigidbody2.velocity = Vector2.zero;
            rigidbody2.AddForce(Vector2.up * impulseForce, ForceMode2D.Impulse);
        }
    }
}
