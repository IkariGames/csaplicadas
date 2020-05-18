using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sligshot : MonoBehaviour
{
public GameObject canvasController;
    public GameObject[] cell; //Cantidad de celulas disponibles a lanzar
    public int cellCant;//Cantidad de celulas en el arreglo
    public int timeWait;//Tiempo que se espera antes de instanciar otra cell.
    float time;//Variable que acumula los segundos que pasan antes de instanciar otra cell
    bool startCount = true;//Booleano que controla el momento en que empiezas a contar
    float finalTime; //Variable que acumula los segundos 
    void Update()
    {
        
        if (startCount)//Si empiezas a contar
        {
            time += Time.deltaTime;//Suma la cantidad de segundos que pasan
        }
        if(time >= timeWait && startCount)//Si empezaste a contar y si han pasado los timeWait segundos 
        {//Si ya puedes lanzar
            //Obtiene la cantidad de coronas que hay en juego
            int CoronaCant = GameObject.FindGameObjectsWithTag("Corona").Length;
            //Revisa si te quedan cells
            if(cellCant > 0){//Si quedan cells
                if(CoronaCant > 0){//Si quedan coronas vivos
                    //Recarga, es decir
                    Instantiate(cell[cellCant-1], transform.position, Quaternion.identity);//Instancia nueva celula
                    cellCant--;//Reduces en uno la cantidad de celulas disponibles
                    time = 0;//Reinicia el tiempo de respawn
                }else{//No quedan coronas vivos
                    //Ganaste
                    canvasController.GetComponent<pause>().winGame();
                }
            }else{//Si no te quedan mas cells
                //Espera 4 segundos y luego cuenta los corona 
                finalTime += Time.deltaTime;
                if( finalTime > 4){
                    if(CoronaCant > 0){//Y quedan coronas vivos
                         //Perdiste
                        canvasController.GetComponent<pause>().gameOver();
                    }else{
                         //Ganaste
                        canvasController.GetComponent<pause>().winGame();
                    }
                }
            }
        }
    }

    void Start()
    {
        cellCant = cell.Length;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Cell")//Si detectas que tienes un corona
        {
            time = 0;//El tiempo es 0 
            startCount = false;//Y dejas de contar
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Cuando hayas dejado de colisionar con corona 
        startCount = true;//Empieza a contar
    }
}

