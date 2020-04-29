using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class changeScene : MonoBehaviour
{
    // Start is called before the first frame update

     public void ChangeScene(int lvl)
    {
        SceneManager.LoadScene(lvl);//Carga la escena de numero lvl respecto al scene manager 
    }

    public void CloseGame()
    {
        Application.Quit();//Cierra Unity
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
