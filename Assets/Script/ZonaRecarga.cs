using UnityEngine;

public class ZonaRecarga : MonoBehaviour
{
    private OxygenSystem oxygenSystem;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            oxygenSystem = other.GetComponent<OxygenSystem>();
            if (oxygenSystem == null)
                oxygenSystem = other.GetComponentInParent<OxygenSystem>();
            if (oxygenSystem != null)
                oxygenSystem.SetCercaNave(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (oxygenSystem != null)
                oxygenSystem.SetCercaNave(false);
        }
    }
}