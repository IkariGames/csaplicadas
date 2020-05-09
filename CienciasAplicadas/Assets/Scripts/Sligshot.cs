using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sligshot : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject cell;
    public GameObject pivot;
    public int timeWait;

    float time;
    bool startCount = true;

   
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

        Debug.Log("Empezaste a contar: " + startCount + " Tiempo: " + time);
        if (startCount)
        {
            time += Time.deltaTime;
        }
        if(time >= timeWait && startCount)
        {
            Instantiate(cell, transform.position, Quaternion.identity);
            time = 0;
        }
    }

    void Start()
    {
       
    }
}
