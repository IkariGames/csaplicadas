using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sligshot : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] cell; //Cantidad de celulas disponibles a lanzar
    public GameObject pivot; //No utilizado aun
    public int cellCant;
    public GameObject detector;

    public int timeWait;//Tiempo que se espera antes de instanciar otra cell.

    float time;
    bool startCount = true;
    bool detectorOn = false;
   
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Cell")
        {
            time = 0;
            startCount = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        startCount = true;
    }




    // Update is called once per frame
    void Update()
    {
        
        if (startCount)
        {
            time += Time.deltaTime;
        }
        if(time >= timeWait && startCount)
        {
            if(cellCant > 0)
            {//Si existen celulas disponibles, instancia una 
                Instantiate(cell[cellCant-1], transform.position, Quaternion.identity);
                cellCant--;
                time = 0;//Reinicia el tiempo de respawn
            }
            else
            {
                if (!detectorOn)
                {
                    Instantiate(detector);
                    detectorOn = true;
                }
            }
            
        }
    }

    void Start()
    {
        cellCant = cell.Length;
    }
}
