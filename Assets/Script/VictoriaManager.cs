using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoriaManager : MonoBehaviour
{
    public void JugarDeNuevo()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void IrAlMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}