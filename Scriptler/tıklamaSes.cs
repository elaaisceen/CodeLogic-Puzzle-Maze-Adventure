using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Buton kodlarına erişmek için gerekli
using UnityEngine.SceneManagement; // Sahnelerin yüklendiğini anlamak için gerekli

public class tıklamaSes : MonoBehaviour
{
    public static tıklamaSes instance;
    private AudioSource efektKaynagi;
    
    [Header("Çalınacak Sesler")]
    public AudioClip butonSesi;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            efektKaynagi = GetComponent<AudioSource>(); 
            
            // Yeni bir sahne yüklendiğinde "OnSceneLoaded" fonksiyonunu otomatik çalıştır
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Her sahne değiştiğinde Unity otomatik olarak burayı tetikler
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        ButonlariBulVeSesEkle();
    }

    void ButonlariBulVeSesEkle()
    {
        // Sahnede Tag'i "Buton" olan tüm objeleri bir diziye (array) topla
        GameObject[] butonObjeleri = GameObject.FindGameObjectsWithTag("buton");

        foreach (GameObject obje in butonObjeleri)
        {
            // Objenin üzerindeki Button bileşenini al
            Button btn = obje.GetComponent<Button>();
            
            if (btn != null)
            {
                // Çift tıklama algılanmasın diye önce varsa eski dinleyiciyi temizle
                btn.onClick.RemoveListener(ButonSesiCal);
                
                // Bizim ButonSesiCal fonksiyonumuzu bu butona kod ile otomatik ekle!
                btn.onClick.AddListener(ButonSesiCal);
            }
        }
    }

    // Butona basıldığında çalacak fonksiyon (artık otomatik tetiklenecek)
    public void ButonSesiCal()
    {
        if (efektKaynagi != null && butonSesi != null)
        {
            efektKaynagi.PlayOneShot(butonSesi); 
        }
    }

    // Bu obje herhangi bir sebeple yok olursa, sahne yükleme dinleyicisini iptal et (Hata almamak için)
    void OnDestroy()
    {
        if (instance == this)
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }
}
