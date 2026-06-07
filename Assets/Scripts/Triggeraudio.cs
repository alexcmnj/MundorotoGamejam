using UnityEngine;

public class Triggeraudio : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        // Verifica que sea el jugador quien pisa
        if (other.CompareTag("Player"))
        {
            audioSource.Play();
        }
    }
}
