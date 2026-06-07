using UnityEngine;

public class Caminar : MonoBehaviour
{
    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip caminar;
    public AudioClip correr;
    public AudioClip salto;
    public AudioClip caer;

    [Header("Configuracion")]
    public float intervaloCaminar = 0.5f;
    public float intervaloCorrer = 0.3f;
    public float velocidadMinima = 0.1f;
    public float velocidadCorrer = 4f;

    private float timer;
    private Rigidbody rb;

    private bool estabaEnSuelo;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 velocidad = new Vector3(rb.linearVelocity.x, 0, rb.linearVelocity.z);
        bool enSuelo = Physics.Raycast(transform.position, Vector3.down, 1.1f);

        if (estabaEnSuelo && !enSuelo)
        {
            audioSource.PlayOneShot(salto);
        }

        if (!estabaEnSuelo && enSuelo)
        {
            audioSource.PlayOneShot(caer);
        }

        if (velocidad.magnitude > velocidadMinima && enSuelo)
        {
            timer += Time.deltaTime;

            bool corriendo = velocidad.magnitude > velocidadCorrer;

            float intervalo = corriendo ? intervaloCorrer : intervaloCaminar;
            AudioClip sonido = corriendo ? correr : caminar;

            if (timer >= intervalo)
            {
                audioSource.PlayOneShot(sonido);
                timer = 0f;
            }
        }
        else
        {
            timer = 0f;
        }

        estabaEnSuelo = enSuelo;
    }
}