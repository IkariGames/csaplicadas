using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pause : MonoBehaviour
{
    private bool active;
    public Canvas canvasMenu;
    public Canvas canvasWin;
    public Canvas canvasGameOver;
    public Canvas canvasInterfaz;

    void Start()
    {
        //Al inicio desactiva todos los paneles menos el de interfaz e inicia el tiempo
        canvasMenu.enabled = false;  
        canvasWin.enabled = false;
        canvasGameOver.enabled = false;
        canvasInterfaz.enabled = true;
        Time.timeScale = 1f;  
    }

    void Update()
    {
        
    }

    public void pauseGame(){
        //al pausar el juego desactiva la interfaz y activa el menu
        canvasMenu.enabled = true;
        canvasGameOver.enabled = false;
        canvasWin.enabled = false;
        Time.timeScale = 0f;
    }

    public void winGame(){
        //Al ganar solo muestra el menu de WIN
        canvasWin.enabled = true;
        canvasMenu.enabled = false;
        canvasGameOver.enabled = false;
        canvasInterfaz.enabled = false;
        Time.timeScale = 0f;
    }

    public void gameOver(){
        //Al perder solo muestra el menu de Perder
        canvasGameOver.enabled = true;
        canvasWin.enabled = false;
        canvasMenu.enabled = false;
        canvasInterfaz.enabled = false;
    }

    public void resumeGame(){
        //Al volver siempre tienes que activar la interfaz
        canvasMenu.enabled = false;
        canvasWin.enabled = false;
        canvasGameOver.enabled = false;
        canvasInterfaz.enabled = true;
        Time.timeScale = 1f;
    }
    public void restartGame(string name){
        SceneManager.LoadScene(name);
        Time.timeScale = 1f;
    }

    public void quitGame(){
        SceneManager.LoadScene("MenuPrincipal");
        Time.timeScale = 1f;
    }
}
