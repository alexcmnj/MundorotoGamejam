using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenuManager : MonoBehaviour
{
    public GameObject panelMenu;
    public GameObject panelConfig;
    public GameObject panelInstrucciones;
    public Slider sliderMusica;
    public Slider sliderSFX;
    public Toggle toggleFullscreen;

    void Start()
    {
        panelMenu.SetActive(true);
        panelConfig.SetActive(false);
        panelInstrucciones.SetActive(false);
        toggleFullscreen.isOn = Screen.fullScreen;
    }

    public void EmpezarAventura()
    {
        SceneManager.LoadScene("Cutscene");
    }

    public void AbrirConfig()
    {
        panelMenu.SetActive(false);
        panelConfig.SetActive(true);
    }

    public void Volver()
    {
        panelConfig.SetActive(false);
        panelInstrucciones.SetActive(false);
        panelMenu.SetActive(true);
    }

    public void AbrirInstrucciones()
    {
        panelMenu.SetActive(false);
        panelInstrucciones.SetActive(true);
    }

    public void CambiarFullscreen(bool isOn)
    {
        Screen.fullScreen = isOn;
    }

    public void Salir()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
}