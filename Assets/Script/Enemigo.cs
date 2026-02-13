using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    // Start is called before the first frame updat

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bala"))
        {
            Destroy(gameObject);    
        }
    }
}
