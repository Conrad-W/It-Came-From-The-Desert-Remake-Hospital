using System.Collections;
using UnityEngine;

public class FadeToBlack : MonoBehaviour
{
    public GameObject blackOutSquare;
    public GameObject player;
    private bool fadeToBlack = true;
    //true = Floor 2, false = Floor 1
    private bool topBottomFloor = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 9 || other.gameObject.layer == 13)
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
            player.transform.position = new Vector3(player.transform.position.x, 1.5f, player.transform.position.z);
            topBottomFloor = false;
        }
        else
        {
            player.transform.position = new Vector3(player.transform.position.x, 76.5f, player.transform.position.z);
            topBottomFloor = true;
        }
    }
    
}
