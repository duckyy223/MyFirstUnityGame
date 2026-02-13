using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int daño = 5;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth vidaJugador = other.GetComponent<PlayerHealth>();
            if (vidaJugador != null)
            {
                vidaJugador.TomarDaño(daño);
            }
        }
    }
}