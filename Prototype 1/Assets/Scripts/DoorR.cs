using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorR : MonoBehaviour
{
    private Animation animR;

    // Start is called before the first frame update
    void Start()
    {
        animR = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        animR["SceneR"].speed = 2.0f;
        animR.Play();
    }

    private void OnTriggerExit(Collider other)
    {
        animR["SceneR"].time = 1.0f;
        animR["SceneR"].speed = -2.0f;
        animR.Play();
    }
}
