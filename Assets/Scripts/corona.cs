using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class corona : MonoBehaviour
{
    public AudioSource som1;
    public AudioSource som2;

    public Text txtVidas;
    private static int vidas = 3;

    void Start() 
    {
        txtVidas.text = "Vidas: " + vidas;

        som1 = GetComponents<AudioSource>()[0];
        som2 = GetComponents<AudioSource>()[1];
    }

    void OnCollisionEnter(Collision collision)
    {
        som1.Play();
    }

    void OnTriggerEnter(Collider outro) 
    {
        if (outro.gameObject.CompareTag("vermelho")) {
            vidas--;
            txtVidas.text = "Vidas: " + vidas;

            som2.Play();
            InvokeRepeating("perder", 0.5f, 1);
        }
    }

    void perder()
    {
        if (vidas == 0)
        {
            SceneManager.LoadScene("gameover");
        }
        else
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
