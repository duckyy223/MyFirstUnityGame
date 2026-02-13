using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int vidaMax = 5;
    public int vidaActual;

    void Start()
    {
        vidaActual = vidaMax;
    }

    public void TomarDaño(int cantidad)
    {
        vidaActual -= cantidad;

        if (vidaActual <= 0)
        {
            Muerte();
        }
    }

    void Muerte()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}