using UnityEngine;

public class Romper : MonoBehaviour
{
    [Header("Vida")]
    public int vida = 3;

    [Header("Sonidos")]
    public AudioClip sonidoGolpe;
    public AudioClip sonidoCaida;

    [Header("Drops")]
    public GameObject maderaPrefab;

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

        Debug.Log("Golpe al árbol. Vida restante: " + vida);

        // Árbol destruido
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

            // Crear madera
            if (maderaPrefab != null)
            {
                Vector3 offset = new Vector3(
                    Random.Range(-0.2f, 0.2f),
                    0.5f,
                    Random.Range(-0.2f, 0.2f)
                );

                Instantiate(
                    maderaPrefab,
                    transform.position + offset,
                    Quaternion.identity
                );
            }

            // Destruir árbol
            Destroy(gameObject);
        }
    }
}