using UnityEngine;
using UnityEngine.UI;

public class OxygenSystem : MonoBehaviour
{
    public Slider sliderOxigeno;
    public float oxigenoMaximo = 100f;
    public float oxigenoActual = 100f;
    public float consumoQuieto = 0.5f;
    public float consumoNormal = 1f;
    public float consumoCorriendo = 2f;
    public float velocidadRecarga = 20f;
    public GameOverManager gameOverManager;

    private bool estaCorriendo = false;
    private bool estaMoviendo = false;
    private bool cercaDeLaNave = false;

    void Update()
    {
        if (cercaDeLaNave)
        {
            oxigenoActual += velocidadRecarga * Time.deltaTime;
        }
        else
        {
            float consumo;
            if (estaCorriendo)
                consumo = consumoCorriendo;
            else if (estaMoviendo)
                consumo = consumoNormal;
            else
                consumo = consumoQuieto;

            oxigenoActual -= consumo * Time.deltaTime;
        }

        oxigenoActual = Mathf.Clamp(oxigenoActual, 0, oxigenoMaximo);
        sliderOxigeno.value = oxigenoActual / oxigenoMaximo;

        if (oxigenoActual <= 0)
        {
            gameOverManager.MostrarGameOver();
        }
    }

    public void SetMoviendo(bool moviendo)
    {
        estaMoviendo = moviendo;
    }

    public void SetCorriendo(bool corriendo)
    {
        estaCorriendo = corriendo;
    }

    public void SetCercaNave(bool cerca)
    {
        cercaDeLaNave = cerca;
    }
}