using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Bu satır sahne değiştirmek için ŞART!


public class sahneGecis : MonoBehaviour
{

    // Butonun görebilmesi için başına 'public' yazdık
    public void SahneDegistir(string levelSahnesi)
    {
        // Yazdığımız isimli sahneye ışınlanmamızı sağlar
        SceneManager.LoadScene(levelSahnesi);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
