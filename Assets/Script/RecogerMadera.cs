
using UnityEngine;

public class RecogerMadera : MonoBehaviour
{
    public int cantidad = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Inventario.madera += cantidad;

            Debug.Log("Madera: " + Inventario.madera);

            Destroy(gameObject);
        }
    }
}