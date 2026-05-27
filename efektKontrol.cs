using UnityEngine;

public class efektKontrol : MonoBehaviour
{
    // [SerializeField] sayesinde Inspector'da kutucuk kesin çıkar
    public ParticleSystem patlamaObjesi; 

    public void Patlat()
    {
        // Tıklandığında konsolda bu yazıyı görmeliyiz
        Debug.Log("Butona tıklandı ve Patlat fonksiyonu çalıştı!"); 

        if (patlamaObjesi != null)
        {
            patlamaObjesi.Play();
        }
        else
        {
            Debug.LogError("Hata: Patlama objesi Inspector'da sürüklenmemiş!");
        }
    }
}