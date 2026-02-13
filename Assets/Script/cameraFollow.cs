using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Transform player;
    public float velocidad_suave = 0.125f;

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            Vector3 posicion_jugador = new Vector3(player.position.x, player.position.y, transform.position.z);
            Vector3 posicion_suave = Vector3.Lerp(transform.position, posicion_jugador, velocidad_suave);
            transform.position = posicion_suave;
        }
    }
}
