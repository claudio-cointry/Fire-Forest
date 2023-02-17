using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScript : MonoBehaviour
{
    public float Scene_velocity = 1;
    public float Scene_InicialVelocity;
    public float SpawnDistance = 15;

    void Start()
    {
        Scene_InicialVelocity = Scene_velocity;
    }
}
