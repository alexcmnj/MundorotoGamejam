using UnityEngine;

public class RecogerPiedra : MonoBehaviour
{
    public int cantidad = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Inventario.piedra += cantidad;

            Debug.Log("Piedra: " + Inventario.piedra);

            Destroy(gameObject);
        }
    }
}