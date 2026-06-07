using UnityEngine;

public class Cofre : MonoBehaviour
{
    [Header("Requisitos")]
    public int maderaNecesaria = 8;
    public int piedraNecesaria = 8;

    [Header("Drop")]
    public GameObject gemaPrefab;

    [Header("Posicion de spawn (opcional)")]
    public Transform spawnGema;

    [Header("Distancia de interacción")]
    public float rango = 5f; // 👈 AUMENTAMOS rango

    private bool completado = false;
    private Transform jugador;

    void Start()
    {
        Debug.Log("Script del cofre activo");

        // Buscar jugador automáticamente
        GameObject obj = GameObject.FindGameObjectWithTag("Player");

        if (obj != null)
        {
            jugador = obj.transform;
        }
        else
        {
            Debug.LogError("No se encontró el Player");
        }
    }

    void Update()
    {
        if (jugador == null) return;

        float distancia = Vector3.Distance(transform.position, jugador.position);

        // Click derecho (como romper)
        if (distancia <= rango && Input.GetMouseButtonDown(1) && !completado)
        {
            Debug.Log("Click derecho en rango");
            IntentarAbrir();
        }
    }

    void IntentarAbrir()
    {
        Debug.Log("Intentando abrir cofre...");

        if (Inventario.madera >= maderaNecesaria && Inventario.piedra >= piedraNecesaria)
        {
            Debug.Log("Materiales entregados");

            Inventario.madera -= maderaNecesaria;
            Inventario.piedra -= piedraNecesaria;

            GenerarGema();

            completado = true;
        }
        else
        {
            Debug.Log("Faltan materiales");
        }
    }

    void GenerarGema()
    {
        if (gemaPrefab == null)
        {
            Debug.LogWarning("No hay gema asignada");
            return;
        }

        Vector3 posicion;

        if (spawnGema != null)
        {
            posicion = spawnGema.position;
        }
        else
        {
            posicion = transform.position + new Vector3(1.5f, 0.5f, 0);
        }

        Instantiate(gemaPrefab, posicion, Quaternion.identity);

        Debug.Log("Gema generada");
    }
}