using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialKontrol : MonoBehaviour
{
    public CanvasGroup panelGrup;

    void Start()
    {
        // Oyun başlangıcında panel kapalı olsun
        if (panelGrup != null)
        {
            panelGrup.alpha = 0f;
            panelGrup.interactable = false;
            panelGrup.blocksRaycasts = false;
        }
    }

    public void OpenSettings()
    {
        if (panelGrup != null)
        {
            panelGrup.alpha = 1f;
            panelGrup.interactable = true;
            panelGrup.blocksRaycasts = true;
            Time.timeScale = 0f;
            Debug.Log("Panel açıldı!");
        }
        else
        {
            Debug.LogError("panelGrup atanmamış!"); // Boşsa bunu görürsün
        }
    }

    public void CloseSettings()
    {
        if (panelGrup != null)
        {
            panelGrup.alpha = 0f;
            panelGrup.interactable = false;
            panelGrup.blocksRaycasts = false;
            Time.timeScale = 1f;
            Debug.Log("Panel kapandı!");
        }
    }
}

