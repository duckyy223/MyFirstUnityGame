using UnityEngine;

public class sonido : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioClip;

    void Start()
    {
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            audioSource.PlayOneShot(audioClip);
        }
    }
}
