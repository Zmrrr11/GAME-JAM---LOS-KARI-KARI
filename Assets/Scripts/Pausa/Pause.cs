using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject menuPausa; 
    private bool juegoPausado = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (juegoPausado)
            {
                ReanudarJuego();
            }
            else
            {
                PausarJuego();
            }
        }
    }
    public void ReanudarJuego()
    {
        menuPausa.SetActive(false);
        Time.timeScale = 1f; 
        juegoPausado = false;
    }
    public void PausarJuego()
    {
        menuPausa.SetActive(true);
        Time.timeScale = 0f; // Pausa el tiempo del juego
        juegoPausado = true;
    }
}
