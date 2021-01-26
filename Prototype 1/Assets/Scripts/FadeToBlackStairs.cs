using System.Collections;
using UnityEngine;

public class FadeToBlackStairs : MonoBehaviour
{
    public GameObject blackOutSquare;
    public GameObject player;
    private bool fadeToBlack = true;
    //true = Floor 2, false = Floor 1
    private bool topBottomFloor = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (player.layer == 13)
        {
            gameObject.GetComponent<BoxCollider>().isTrigger = false;
        }
        else if (player.layer == 9)
        {
            gameObject.GetComponent<BoxCollider>().isTrigger = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 9)
        {
            StartCoroutine(FadeBlackOutSquare());
            StartCoroutine(FadeBlackOutSquare());
            StartCoroutine(Teleport());
        }
    }
    public IEnumerator FadeBlackOutSquare(int fadeSpeed = 5)
    {
        Color objectColor = blackOutSquare.GetComponent<MeshRenderer>().material.color;
        float fadeAmount;

        if (fadeToBlack == true)
        {
            while (blackOutSquare.GetComponent<MeshRenderer>().material.color.a < 1)
            {
                fadeAmount = objectColor.a + (fadeSpeed * Time.deltaTime);

                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
                blackOutSquare.GetComponent<MeshRenderer>().material.color = objectColor;
                yield return null;
            }
            fadeToBlack = false;
        }
        else
        {
            while (blackOutSquare.GetComponent<MeshRenderer>().material.color.a >= 0)
            {
                fadeAmount = objectColor.a - (fadeSpeed * Time.deltaTime);

                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
                blackOutSquare.GetComponent<MeshRenderer>().material.color = objectColor;
                yield return null;
            }
            fadeToBlack = true;
        }
    }

    public IEnumerator Teleport()
    {
        yield return new WaitForSeconds(1);
        if (topBottomFloor == true)
        {
            player.transform.position = new Vector3(3.0f, 1.5f, player.transform.position.z);
            topBottomFloor = false;
        }
        else
        {
            player.transform.position = new Vector3(7.5f, 76.5f, player.transform.position.z);
            topBottomFloor = true;
        }
    }
    
}
