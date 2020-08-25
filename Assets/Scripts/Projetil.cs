using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projetil : MonoBehaviour
{
    public float DestroyTime = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, DestroyTime);
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if(other.GetComponentInParent<PlayerControll>().shield.activeInHierarchy)
            {
                other.GetComponentInParent<PlayerControll>().shield.SetActive(false);
            }
            else{
                other.GetComponent<PlayerControll>().HadShot();
            }

            
            Destroy(gameObject);
        }   
    }
}
