using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))] // Bu scripti butonu olmayan birine atmanı engeller, güvenlidir.
public class ButtonEffect : MonoBehaviour
{

    [Header("Efekt Ayarları")]
    [SerializeField] private ParticleSystem clickParticle;

    private Button _button;

    void Awake()
    {
        _button = GetComponent<Button>();
        
        if (_button != null && clickParticle != null)
        {
            // Tıklama olayını koda bağlıyoruz
            _button.onClick.AddListener(PlayEffect);
        }
    }

    private void PlayEffect()
    {
        // Eğer partikül o an oynuyorsa durdur ve en baştan başlat
        clickParticle.Stop(); 
        clickParticle.Play();
        
        // İstersen buraya butonun tıklandığına dair küçük bir log ekleyebilirsin
        // Debug.Log($"{gameObject.name} butonuna basıldı, partikül oynatılıyor.");
    }
}