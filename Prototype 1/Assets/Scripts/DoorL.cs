using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorL : MonoBehaviour
{
    private Animation animL;

    // Start is called before the first frame update
    void Start()
    {
        animL = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        animL["SceneL"].speed = 2.0f;
        animL.Play();
    }

    private void OnTriggerExit(Collider other)
    {
        animL["SceneL"].time = 1.0f;
        animL["SceneL"].speed = -2.0f;
        animL.Play();
    }
}
