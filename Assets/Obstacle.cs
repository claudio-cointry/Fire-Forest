using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    public MainScript mainScript;

    // Start is called before the first frame update
    void Start()
    {
        mainScript = GameObject.FindGameObjectWithTag("MainScript").GetComponent<MainScript>();

    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += Vector3.left * mainScript.Scene_velocity * Time.deltaTime;
        
    }
}
