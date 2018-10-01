using UnityEngine;
using System.Collections;

public class BlockGenerator: MonoBehaviour
{

    public GameObject block1;

    public int wallWidth = 10;
    public int wallHeight = 10;

    public float spawnSpeed = 0;

    void Start()
    {
        StartCoroutine(CreateWall());
    }

    IEnumerator CreateWall()
    {
        for (int x = 0; x < wallWidth; x++)
        {
            yield return new WaitForSeconds(spawnSpeed);

            for (int y = 0; y < wallHeight; y++)
            {
                yield return new WaitForSeconds(spawnSpeed);

                GameObject block = Instantiate(block1, Vector3.zero, block1.transform.rotation) as GameObject;
                //block.transform.parent = transform;
                block.transform.SetParent(transform);
                block.transform.localPosition = new Vector3(x, y, 0);
            }
        }
    }  //end CreateWall

    //References
    //https://answers.unity.com/questions/490542/spawning-a-grid-of-cubes.html
} //end BlockGenerator class