using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private Vector3 freezePosition;
    public Animator barraAnim;

    void Start()
    {
        freezePosition = transform.position;
    }

    void LateUpdate()
    {
        transform.position = freezePosition;
    }

    public void nextMenu(string menu){
        barraAnim.SetBool(menu,true);
    } 
    public void previousMenu(string menu){
        barraAnim.SetBool(menu,false);
    }    
    public void exitGame(){
        Application.Quit();
    }
    public void changeScene(int scene){
        SceneManager.LoadScene(scene);
    }    
}
