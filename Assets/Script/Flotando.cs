using UnityEngine;

public class Flotando : MonoBehaviour
{
    public float amplitud = 0.5f;
    public float velocidad = 1f;
    public float rotacion = 20f;

    private Vector3 posicionInicial;

    void Start()
    {
        posicionInicial = transform.position;
    }

    void Update()
    {
        transform.position =
            posicionInicial +
            Vector3.up * Mathf.Sin(Time.time * velocidad) * amplitud;

        transform.Rotate(Vector3.up * rotacion * Time.deltaTime);
    }
}