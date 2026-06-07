using UnityEngine;

public class GravedadController : MonoBehaviour
{
    // Las 3 fases de gravedad
    [SerializeField] private float Gravedad1Field= -9.81f;
    [SerializeField] private float Gravedad2Field= -3f;
    [SerializeField] private float Gravedad3Field= -0.5f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            
            Physics.gravity = new Vector3(0, Gravedad1Field, 0);

            Debug.Log("Gravedad: " + Gravedad1Field);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Physics.gravity = new Vector3(0, Gravedad2Field, 0);

            Debug.Log("Gravedad: " + Gravedad2Field);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Physics.gravity = new Vector3(0, Gravedad3Field, 0);

            Debug.Log("Gravedad: " + Gravedad3Field);
        }
    }
}
