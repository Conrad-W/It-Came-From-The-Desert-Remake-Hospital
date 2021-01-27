using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorE : MonoBehaviour
{
    private Animation animE;

    // Start is called before the first frame update
    void Start()
    {
        animE = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        animE["SceneE"].speed = 2.0f;
        animE.Play();
    }

    private void OnTriggerExit(Collider other)
    {
        animE["SceneE"].time = 1.0f;
        animE["SceneE"].speed = -2.0f;
        animE.Play();
    }
}