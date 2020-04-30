using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragNShoot : MonoBehaviour
{

    public float power = 10f;//Poder incial que tendra
    Rigidbody2D rbd;
    public Vector2 minPower;
    public Vector2 maxPower;


    Vector2 positionSpawn;

    Camera cam;
    Vector2 force;
    Vector3 startPoint;
    Vector3 endPoint;

    // Start is called before the first frame update
    void Start()
    {
        rbd = GetComponent<Rigidbody2D>();
        cam = Camera.main;

        positionSpawn = new Vector2(transform.position.x, transform.position.y);

    }

    // Update is called once per frame
    void Update()
    {
        //Input para Mouse y Teclado por ahora

        if (Input.GetMouseButtonDown(0))//Captura el click izquierdo al presionarse
        {
            startPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            startPoint.z = 5;//Arreglo a capa 5 en z
        }
        if (Input.GetMouseButtonUp(0)) //Captura el clickizquierdo al levantarse
        {
            endPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            endPoint.z = 5;//Arreglo a capa 5 en z 

            force = new Vector2(Mathf.Clamp(startPoint.x-endPoint.x, minPower.x, maxPower.x),Mathf.Clamp(startPoint.y - endPoint.y, minPower.y, maxPower.y));
            rbd.AddForce(force * power, ForceMode2D.Impulse);
        }   
        
        if(transform.position.x < -10000 || transform.position.x > 10000)
        {
            transform.position = positionSpawn;
        }
        if(transform.position.y < -1000 || transform.position.y > 10000)
        {
            transform.position = positionSpawn;
        }
    }
}
