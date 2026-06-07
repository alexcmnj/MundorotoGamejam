using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelBriefing : MonoBehaviour
{
    public GameObject panelBriefing;

    void Start()
    {
        panelBriefing.SetActive(true);
        Time.timeScale = 0f;
    }

    public void CerrarBriefing()
    {
        panelBriefing.SetActive(false);
        Time.timeScale = 1f;
    }
}