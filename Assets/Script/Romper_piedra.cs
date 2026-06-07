using UnityEngine;

public class Romper_piedra : MonoBehaviour
{
    [Header("Vida")]
    public int vida = 3;

    [Header("Sonidos")]
    public AudioClip sonidoGolpe;
    public AudioClip sonidoRotura;

    [Header("Drops")]
    public GameObject piedraPrefab;

    public void RecibirDanio(int cantidad)
    {
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
            if (sonidoRotura != null)
            {
                AudioSource.PlayClipAtPoint(
                    sonidoRotura,
                    transform.position
                );
            }

            if (piedraPrefab != null)
            {
                Vector3 offset = new Vector3(
                    Random.Range(-0.2f, 0.2f),
                    0.2f,
                    Random.Range(-0.2f, 0.2f)
                );

                Instantiate(
                    piedraPrefab,
                    transform.position + offset,
                    Quaternion.identity
                );
            }

            Destroy(gameObject);
        }
    }
}