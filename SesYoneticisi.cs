using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SesYoneticisi : MonoBehaviour
{
    // Her sahneden bu objeye kolayca ulaşabilmemiz için "Singleton" yapısı
    public static SesYoneticisi instance;
    
    // Sesi çalan bileşenimiz
    private AudioSource muzikKaynagi;

    void Awake()
    {
        // Eğer sahnede SesYöneticisi yoksa, bunu ana yönetici yap ve korumaya al
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Sahne değişse de yok etme!
            
            // AudioSource bileşenini koda tanıt
            muzikKaynagi = GetComponent<AudioSource>(); 
        }
        else
        {
            // Eğer zaten bir SesYöneticisi varsa (mesela ana menüye geri döndüysek), yenisini yok et.
            Destroy(gameObject);
        }
    }

    // Ayarlar menündeki butonundan bu fonksiyonu çağıracağız
    public void MuzigiAcKapat(bool sesAçikMi)
    {
        if (muzikKaynagi != null)
        {
            if (sesAçikMi == true)
            {
                muzikKaynagi.volume = 1f; // Sesi aç
            }
            else
            {
                muzikKaynagi.volume = 0f; // Sesi kapat
            }
        }
    }
}
