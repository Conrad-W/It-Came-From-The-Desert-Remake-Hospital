using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    private Rigidbody rigidbodyComponent;
    private float speedH;
    private float speedV;
    private bool chairUpgrade;
    private bool bedRadius;
    public Vector3 rigidPos;

    // Start is called before the first frame update
    void Start()
    {
        rigidbodyComponent = GetComponent<Rigidbody>();
        rigidPos = rigidbodyComponent.position;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        speedH = horizontalInput * 5;
        speedV = verticalInput * 5;

        if (chairUpgrade && !bedRadius)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                gameObject.transform.GetChild(1).transform.parent = null;
                rigidbodyComponent.position = new Vector3(rigidbodyComponent.position.x, rigidbodyComponent.position.y, rigidbodyComponent.position.z + 1.5f);
                gameObject.layer = 9;
                chairUpgrade = false;
            }
        }

        if (bedRadius && !chairUpgrade && gameObject.layer == 9)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                rigidbodyComponent.position = new Vector3(rigidbodyComponent.position.x, rigidbodyComponent.position.y + 1, rigidbodyComponent.position.z + 1.5f);
                gameObject.layer = 11;
            }
        }
        else if (bedRadius && !chairUpgrade && gameObject.layer == 11)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                rigidbodyComponent.position = new Vector3(rigidbodyComponent.position.x, rigidbodyComponent.position.y - 1, rigidbodyComponent.position.z - 1.5f);
                gameObject.layer = 9;
            }
        }
    }

    private void FixedUpdate()
    {
        if (gameObject.layer == 9 || gameObject.layer == 13)
        {
            if (chairUpgrade == false)
            {
                rigidbodyComponent.velocity = new Vector3(speedH, 0, rigidbodyComponent.velocity.z);
                rigidbodyComponent.velocity = new Vector3(rigidbodyComponent.velocity.x, 0, speedV);
            }
            else if (chairUpgrade == true)
            {
                rigidbodyComponent.velocity = new Vector3(speedH * 2, 0, rigidbodyComponent.velocity.z);
                rigidbodyComponent.velocity = new Vector3(rigidbodyComponent.velocity.x, 0, speedV * 2);
            }
        }
        else if (gameObject.layer == 11)
        {
            rigidbodyComponent.velocity = new Vector3(0, 0, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            other.gameObject.transform.parent = gameObject.transform;
            other.gameObject.transform.localPosition = new Vector3(0, -1f, 0);
            chairUpgrade = true;
            gameObject.layer = 13;
        }

        if (other.gameObject.layer == 12)
        {
            bedRadius = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                other.gameObject.transform.parent = null;
                rigidbodyComponent.position = new Vector3(rigidbodyComponent.position.x, rigidbodyComponent.position.y, rigidbodyComponent.position.z + 1.5f);
                gameObject.layer = 9;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 12)
        {
            bedRadius = false;
        }
    }
}
