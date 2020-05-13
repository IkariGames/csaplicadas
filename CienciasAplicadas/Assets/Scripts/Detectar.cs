using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Detectar : MonoBehaviour
{
    // Start is called before the first frame update

    public float secondsLive;
    public float time;

    bool win = false;
    
    void Start()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Corona")
        {
            Debug.Log("Perdiste");
            win = false;
            //Saltar ventana de perdiste

            Destroy(gameObject);
            
        }
        else
        {
            Debug.Log("Ganaste");
            win = true;
            //Saltar ventana de ganaste.

            Destroy(gameObject);
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        secondsLive += Time.deltaTime;
        
    }
}
