using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class evrenselSahneGecis : MonoBehaviour
{
    private string hedefSahne;

    public void SahneyeGit(string sahneAdi)
    {
        hedefSahne = sahneAdi;

        GameObject tiklananButon = EventSystem.current.currentSelectedGameObject;

        // Hangi butonu bulduğunu konsola yaz
        if (tiklananButon != null)
        {
            Debug.Log("Tıklanan buton: " + tiklananButon.name);

            ParticleSystem partikul = tiklananButon.GetComponentInChildren<ParticleSystem>();

            if (partikul != null)
            {
                Debug.Log("Partikül bulundu: " + partikul.name);
                partikul.Play();
            }
            else
            {
                Debug.LogWarning("Partikül bulunamadı! Buton: " + tiklananButon.name);
            }
        }
        else
        {
            Debug.LogError("Tıklanan buton NULL!");
        }

        Invoke("SahneDegistir", 1.5f);
    }

    private void SahneDegistir()
    {
        SceneManager.LoadScene(hedefSahne);
    }
}
