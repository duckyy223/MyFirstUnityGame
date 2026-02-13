using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoEnemigo : MonoBehaviour
{
    public Transform puntoA;
    public Transform puntoB;
    public float speed = 2f;
    public float pos1 = 5f;
    public float pos2 = 5f;
    public float pos3 = 5f;

    public float menospos1 = -5f;


    private Vector3 destino;
    private Animator animator;

    void Start()
    {
        destino = puntoA.position;
        animator = GetComponent<Animator>();

    }

    void Update()
    {
        
        // Dirección hacia donde va
        Vector3 direccion = destino - transform.position;

         // Girar (2D: flip horizontal)
         if (direccion.x < 0.01f)
            transform.localScale = new Vector3(pos1, pos2, pos3);     // mira derecha
        else if (direccion.x > -0.01f)
            transform.localScale = new Vector3(menospos1, pos2, pos3);    // mira izquierda

        // Movimiento automático hacia el destino
        transform.position = Vector3.MoveTowards(transform.position, destino, speed * Time.deltaTime);


        // Cuando llega al destino, cambia al otro
        if (Vector3.Distance(transform.position, destino) < 0.1f)
        {
            if (destino == puntoA.position)
                destino = puntoB.position;
            else
                destino = puntoA.position;
        }
    }

}
