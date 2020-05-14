using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pause : MonoBehaviour
{
    private bool active;
    private Canvas canvasMenu;

    void Start()
    {
        canvasMenu = GetComponent<Canvas>();
        canvasMenu.enabled = false;    
    }

    void Update()
    {
        if(Input.GetKeyDown("escape")){
            if(!active){
                pauseGame();
            }else{
                resumeGame();
            }
        }
    }

    private void pauseGame(){
        active = !active;
        canvasMenu.enabled = active;
        Time.timeScale = 0f;
    }
    public void resumeGame(){
        active = !active;
        canvasMenu.enabled = active;
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
