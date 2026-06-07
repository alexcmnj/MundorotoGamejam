using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;// Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void Triggersiguientenivel()
    {
        Debug.Log("¡Victoria! Código correcto");
        SceneManager.LoadScene("Gamejam");
    }
}
