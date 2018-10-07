using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WallGenerator : MonoBehaviour
{
    //private readonly List<GameObject> blockTypes = new List<GameObject>();
    public GameObject WoodCrate;
    public GameObject PlayerCrest;

    public bool Player1Wall;

    private bool playerCrestSet = false; //Set to true for only 1 Crest Block per Player
    //SpriteRenderer crestSprite;

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

                if (y == (wallHeight - 1) && playerCrestSet == false)
                {
                    SetPlayerCrest(x, y);
                    print("SetCrest");
                }
                else
                {
                    SetCrate(x, y);
                }
            } //end for loop y
        } //end for loop x
    }  //end CreateWall

    private void SetCrate(int x, int y) {
        GameObject block = Instantiate(WoodCrate, Vector3.zero, WoodCrate.transform.rotation) as GameObject;
        //block.transform.parent = transform;
        block.transform.SetParent(transform);
        block.transform.localPosition = new Vector3(x, y, 0);

        //print("SetCrate");
    } //end SetCrate

    private void SetPlayerCrest(int x, int y)
    {
        GameObject block = Instantiate(PlayerCrest, Vector3.zero, PlayerCrest.transform.rotation) as GameObject;
        //block.transform.parent = transform;
        block.transform.SetParent(transform);
        block.transform.localPosition = new Vector3(x, y, 0);
    } //end SetCrate

    //References
    //https://answers.unity.com/questions/490542/spawning-a-grid-of-cubes.html
} //end WallGenerator class