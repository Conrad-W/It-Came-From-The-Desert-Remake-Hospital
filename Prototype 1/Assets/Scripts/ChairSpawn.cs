using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairSpawn : MonoBehaviour
{

    public GameObject chair;
    private int chairCount;
    private int cornerNumber;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnChair());
    }

    private IEnumerator SpawnChair()
    {
        while (chairCount < 1)
        {
            yield return null;
            cornerNumber = Random.Range(1, 5);
            switch (cornerNumber)
            {
                case 1:
                    {
                        Instantiate(chair, new Vector3(-28, 75.5f, 23), Quaternion.identity);
                        chairCount++;
                        break;
                    }
                case 2:
                    {
                        Instantiate(chair, new Vector3(28, 75.5f, 23), Quaternion.identity);
                        chairCount++;
                        break;
                    }
                case 3:
                    {
                        Instantiate(chair, new Vector3(-28, 75.5f, -23), Quaternion.identity);
                        chairCount++;
                        break;
                    }
                default:
                    {
                        Instantiate(chair, new Vector3(28, 75.5f, -23), Quaternion.identity);
                        chairCount++;
                        break;
                    }
            }
        }
    }
}
