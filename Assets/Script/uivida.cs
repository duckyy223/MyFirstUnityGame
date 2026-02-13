using UnityEngine;
using UnityEngine.UI;

public class uivida : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public Image[] corazones;
    public Sprite corazonLleno;
    public Sprite corazonVacio;

    void Update()
    {
        for (int i = 0; i < corazones.Length; i++)
        {
            if (i < playerHealth.vidaActual)
                corazones[i].sprite = corazonLleno;
            else
                corazones[i].sprite = corazonVacio;
        }
    }
}