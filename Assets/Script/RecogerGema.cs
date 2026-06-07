using UnityEngine;
using UnityEngine.SceneManagement;

public class RecogerGema : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Inventario.gemas++;

            Debug.Log("Gema obtenida");

            SceneManager.LoadScene(
                SceneManager.GetActiveScene().buildIndex + 1
            );
        }
    }
}