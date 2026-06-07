using UnityEngine;

public class Romper_piedra : MonoBehaviour
{
    [Header("Vida")]
    public int vida = 3;

    [Header("Sonidos")]
    public AudioClip sonidoGolpe;
    public AudioClip sonidoCaida;

    [Header("Drops")]
    public GameObject PiedraPrefab;

    public void RecibirDanio(int cantidad)
    {
        // Sonido de golpe
        if (sonidoGolpe != null)
        {
            AudioSource.PlayClipAtPoint(
                sonidoGolpe,
                transform.position
            );
        }

        vida -= cantidad;

        Debug.Log("Golpe a la piedra. Vida restante: " + vida);

        if (vida <= 0)
        {
            // Sonido de caída
            if (sonidoCaida != null)
            {
                AudioSource.PlayClipAtPoint(
                    sonidoCaida,
                    transform.position
                );
            }

            if (PiedraPrefab != null)
            {
                Vector3 offset = new Vector3(
                    Random.Range(-0.2f, 0.2f),
                    0.5f,
                    Random.Range(-0.2f, 0.2f)
                );

                Instantiate(
                    PiedraPrefab,
                    transform.position + offset,
                    Quaternion.identity
                );
            }

            Destroy(gameObject);
        }
    }
}