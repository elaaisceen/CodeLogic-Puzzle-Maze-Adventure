using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Image ve Alpha işlemleri için
using UnityEngine.SceneManagement;

public class ayarlarKontrol : MonoBehaviour
{
public CanvasGroup ayarlarCanvasGroup;

    public void OpenSettings()
    {
        if (ayarlarCanvasGroup != null)
        {
            ayarlarCanvasGroup.alpha = 1f;          // Görünür yapar
            ayarlarCanvasGroup.interactable = true;   // Butonları tıklanabilir yapar
            ayarlarCanvasGroup.blocksRaycasts = true; // Tıklamaları yakalar
            
            Time.timeScale = 0f; 
            Debug.Log("Panel şu an görünür ve aktif!");
        }
    }

    public void CloseSettings()
    {
        if (ayarlarCanvasGroup != null)
        {
            ayarlarCanvasGroup.alpha = 0f;           // Görünmez yapar
            ayarlarCanvasGroup.interactable = false;  // Butonları devre dışı bırakır
            ayarlarCanvasGroup.blocksRaycasts = false; // Tıklamaların arkaya geçmesine izin verir
            
            Time.timeScale = 1f;
            Debug.Log("Panel gizlendi.");
        }
    }

    [Header("Ses ve Titreşim Ayarları")]
    public UnityEngine.UI.Image sesbtn;
    public UnityEngine.UI.Image titresimButonImage;
    private bool sesAcik = true;
    private bool titresimAcik = true;

   // --- SES KONTROLÜ ---
public void ToggleSes()
{
    sesAcik = !sesAcik; 
    
    // EĞER BUTON RESMİ UNITY'DEN ATANMIŞSA RENGİ DEĞİŞTİR (ATANMAMIŞSA ÇÖKME, ATLA)
    if (sesbtn != null)
    {
        float yeniAlpha = sesAcik ? 1.0f : 0.4f;
        sesbtn.color = new Color(sesbtn.color.r, sesbtn.color.g, sesbtn.color.b, yeniAlpha);
    }

    // --- SESİ AÇMA / KAPATMA İŞLEMİ (Burası artık kesin çalışacak) ---
    if (sesAcik)
    {
        AudioListener.volume = 1f; 
    }
    else
    {
        AudioListener.volume = 0f; 
    }

    Debug.Log(sesAcik ? "Ses Açıldı" : "Ses Kapatıldı");
}

    // --- TİTREŞİM KONTROLÜ ---
    public void ToggleTitresim()
    {
        titresimAcik = !titresimAcik;
        
        float yeniAlpha = titresimAcik ? 1.0f : 0.4f;
        titresimButonImage.color = new Color(titresimButonImage.color.r, titresimButonImage.color.g, titresimButonImage.color.b, yeniAlpha);

        Debug.Log(titresimAcik ? "Titreşim Aktif" : "Titreşim Pasif");
    }

    // --- NAVİGASYON (SAHNE GEÇİŞLERİ) ---
    public void AnaMenuyeDon()
    {
        Time.timeScale = 1f; // ÇOK ÖNEMLİ: Zamanı durdurmuşsak sahne değişmeden açmalıyız!
        UnityEngine.SceneManagement.SceneManager.LoadScene(0); 
    }

    public void CikisYap()
    {
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene(1); 
    }
}
    
