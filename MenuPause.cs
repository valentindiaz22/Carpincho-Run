using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPause : MonoBehaviour{

     [SerializeField] private GameObject MenuPausa;
     [SerializeField] private GameObject ContadorMate;
    void Update()
    {
        if (Input.GetKeyDown("escape")){
            Time.timeScale = 0f;
            MenuPausa.SetActive(true);
            ContadorMate.SetActive(false);
        }

        if (Input.GetKeyDown("right ctrl")){
            Reiniciar();
        }
    }
    

    public void Reanudar()
    {
        Time.timeScale = 1f;
        MenuPausa.SetActive(false);
        ContadorMate.SetActive(true);
    } 

    public void Reiniciar()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void SalirMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void SalirMenu2()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }
}   
