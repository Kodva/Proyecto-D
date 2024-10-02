
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Menu_Inicio : MonoBehaviour
{
    public CanvasGroup inicio, opciones;
    public Button play_Button, exit_Button, back_Button;
    public AudioClip uiSoundM;
    public AudioSource audioS;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void StartGame()
    {
        audioS.Play();
        SceneManager.LoadScene("Game");
    }
    public void ExitGame()
    {
        audioS.Play();
        Application.Quit();
    }
    public void EnterOptions()
    {
        audioS.Play();
        inicio.alpha = 0;
        inicio.interactable = false;
        inicio.blocksRaycasts = false;
        opciones.alpha = 1;
        opciones.interactable = true;
        opciones.blocksRaycasts = true;
    }
    public void ExitOptions()
    {
        audioS.Play();
        inicio.alpha = 1;
        inicio.interactable = true;
        inicio.blocksRaycasts = true;
        opciones.alpha = 0;
        opciones.interactable = false;
        opciones.blocksRaycasts = false;
    }
}
