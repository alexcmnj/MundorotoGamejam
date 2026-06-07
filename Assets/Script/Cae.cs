using UnityEngine;

public class Cae : MonoBehaviour
{
    public float distancia = 3f;
    public int danio = 1;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ViewportPointToRay(
                new Vector3(0.5f, 0.5f, 0)
            );

            if (Physics.Raycast(ray, out RaycastHit hit, distancia))
            {
                // Árbol
                Romper arbol = hit.collider.GetComponent<Romper>();

                if (arbol != null)
                {
                    arbol.RecibirDanio(danio);
                    return;
                }

                // Piedra
                Romper_piedra piedra = hit.collider.GetComponent<Romper_piedra>();

                if (piedra != null)
                {
                    piedra.RecibirDanio(danio);
                    return;
                }
            }
        }
    }
}