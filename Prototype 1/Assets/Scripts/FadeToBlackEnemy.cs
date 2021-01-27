using System.Collections;
using UnityEngine;

public class FadeToBlackEnemy : MonoBehaviour
{
    public GameObject blackOutSquare;
    public GameObject player;
    private bool fadeToBlack = true;
    //true = Floor 2, false = Floor 1
    private bool topBottomFloor = true;

    private void OnCollisionEnter(Collision collision)
    {
        StartCoroutine(FadeBlackOutSquare());
        StartCoroutine(Teleport());
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
            player.transform.position = new Vector3(-3, 73, 0);
            topBottomFloor = false;
        }
        else
        {
            player.transform.position = new Vector3(-3, 73, 0);
            topBottomFloor = true;
        }
    }
    
}
