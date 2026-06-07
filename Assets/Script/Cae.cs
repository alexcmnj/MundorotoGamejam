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
                Romper arbol = hit.collider.GetComponent<Romper>();

                if (arbol != null)
                {
                    arbol.RecibirDanio(danio);
                }
            }
        }
    }
}