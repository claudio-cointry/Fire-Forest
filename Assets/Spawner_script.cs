using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_script : MonoBehaviour
{
     
    //Definiendo los obstáculos
    public GameObject RamaInferior1;
    public GameObject RamaInferior2;
    public GameObject RamaInferior3;
    public GameObject RamaSuperior1;
    public GameObject RamaSuperior2;
    public GameObject RamaSuperior3;
    public GameObject RamaSuperior4;
    public GameObject RamaDoble1;
    public GameObject RamaDoble2;
    public GameObject RamaFuego;

    //Vinculando con el MainScript
    public MainScript mainScript;

    //Definiendo variables públicas del spawner
    public float SpawnDistance = 5;

    //Otras variables necesarias para spawnear los obstáculos
    private int randomInt;
    private GameObject nextObject;
    private float lowest_point = 0;
    private float highest_point = 0;
    private float spawn_offset = 0;
    private GameObject obstaculoCreado;

    void Start()
    {
        SpawnearRandom();
    }

    void Update()
    {   
        if (DistanciaUltimo() >= mainScript.SpawnDistance){
            SpawnearRandom();
        }
    }

// Procedimiento para spawnear un obstáculo, dado un tipo y una distancia de offset en Y
    void SpawnObstacle(GameObject tipo, float offset){
        lowest_point = transform.position.y - offset;
        highest_point = transform.position.y + offset;
        obstaculoCreado = Instantiate(tipo, new Vector3 (transform.position.x, Random.Range(lowest_point,highest_point), 0), transform.rotation);
    }

// Procedimiento para llamar a la funcion SpawnObstacle() con un obstáculo aleatorio y definiendo el offset según el tipo
    void SpawnearRandom(){

        //Generando número entero random
        randomInt = Random.Range(1,11);

        //Asignando el tipo de obstáculo segun el número random
        if (randomInt == 1){
            nextObject = RamaInferior1;
        } else if(randomInt == 2){
            nextObject = RamaInferior2;
        } else if(randomInt == 3){
            nextObject = RamaInferior3;
        } else if(randomInt == 4){
            nextObject = RamaSuperior1;
        } else if(randomInt == 5){
            nextObject = RamaSuperior2;
        } else if(randomInt == 6){
            nextObject = RamaSuperior3;
        } else if(randomInt == 7){
            nextObject = RamaSuperior4;
        } else if(randomInt == 8){
            nextObject = RamaDoble1;
        } else if(randomInt == 9){
            nextObject = RamaDoble2;
        } else if(randomInt == 10){
            nextObject = RamaFuego;
        }

        //Asignando el offset en Y
        if (randomInt == 8 | randomInt == 9){
            spawn_offset = 3;
        } else {
            spawn_offset = 0;
        }

        //Spawneando el objeto a través del procedimiento SpawnObstacle()
        SpawnObstacle(nextObject, spawn_offset);
    }

    //Función que devuelve la distancia entre el último objeto creado y el spawner
    float DistanciaUltimo(){
        float distancia;
        distancia = transform.position.x - obstaculoCreado.transform.position.x;
        return distancia;
    }
}
