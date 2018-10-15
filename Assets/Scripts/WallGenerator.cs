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

    private List<GameObject> BlocksInWallIndex = new List<GameObject>();
    private int CurrentBlockIndexPos;
    private int BlocksInWall;

    private List<GameObject> CrestsOnWallIndex = new List<GameObject>();
    private int CurrentCrestIndexPos;
    private int CrestsOnWall;

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

        if (!Player1Wall)
        {
            GameManager.Instance.BlocksInWall_P2 = BlocksInWallIndex.Count;
            GameManager.Instance.CrestsOnWall_P2 = CrestsOnWallIndex.Count;
        } else
        {
            GameManager.Instance.BlocksInWall_P1 = BlocksInWallIndex.Count;
            GameManager.Instance.CrestsOnWall_P1 = CrestsOnWallIndex.Count;
        }

        //print("Player1Wall: " + Player1Wall + ",  Blocks: " + BlocksInWallIndex.Count + ", Crests: " + CrestsOnWallIndex.Count);
        //print("Blocks In Wall: " + BlocksInWall + ",  Crests On Wall: " + CrestsOnWall);
    }  //end CreateWall

    public IEnumerator CreateRow()
    {
        print("CREATE WALL");
        for (int x = 0; x < wallWidth; x++)
        {
            yield return new WaitForSeconds(spawnSpeed);

            for (int y = 0; y < 1; y++)
            {
                yield return new WaitForSeconds(spawnSpeed);
                    SetCrate(x, y);
            } //end for loop y
        } //end for loop x

        if (!Player1Wall)
        {
            GameManager.Instance.BlocksInWall_P2 = BlocksInWallIndex.Count;
            //GameManager.Instance.CrestsOnWall_P2 = CrestsOnWallIndex.Count;
        }
        else
        {
            GameManager.Instance.BlocksInWall_P1 = BlocksInWallIndex.Count;
            //GameManager.Instance.CrestsOnWall_P1 = CrestsOnWallIndex.Count;
        }

        print("Player1Wall: " + Player1Wall + ",  Blocks: " + BlocksInWallIndex.Count + ", Crests: " + CrestsOnWallIndex.Count);
        print("Blocks In Wall: " + BlocksInWall + ",  Crests On Wall: " + CrestsOnWall);
    }  //end CreateRow

    private void SetCrate(int x, int y) {
        GameObject block = Instantiate(WoodCrate, Vector3.zero, WoodCrate.transform.rotation) as GameObject;
        AddBlockToWall(block);

        //block.transform.parent = transform;
        block.transform.SetParent(transform);
        block.transform.localPosition = new Vector3(x, y, 0);

        //print("SetCrate");
    } //end SetCrate

    private void SetPlayerCrest(int x, int y)
    {
        GameObject block = Instantiate(PlayerCrest, Vector3.zero, PlayerCrest.transform.rotation) as GameObject;
        AddBlockToWall(block);
        AddCrestToWall(block);

        //block.transform.parent = transform;
        block.transform.SetParent(transform);
        block.transform.localPosition = new Vector3(x, y, 0);
    } //end SetCrate

    public void AddBlockToWall(GameObject block)
    {
        CurrentBlockIndexPos = BlocksInWallIndex.Count;
        BlocksInWallIndex.Add(block);
        BlocksInWall = BlocksInWallIndex.Count;

        //print(BlocksInPlayIndex.Count);
        //print("Placed BlockIndex: " + CurrentBlockIndex);
        //print("Blocks In Play: " + BlocksInPlay);
    } //end AddBlockToWall

    public void RemoveBlockFromWall(GameObject block)
    {
        BlocksInWallIndex.Remove(block);
        BlocksInWall = BlocksInWallIndex.Count;
        //CurrentBlockIndexPos = BlocksInPlayIndex.Count;
    } //end RemoveBlockFromWall

    public void AddCrestToWall(GameObject block)
    {
        CurrentCrestIndexPos = CrestsOnWallIndex.Count;
        CrestsOnWallIndex.Add(block);
        CrestsOnWall = CrestsOnWallIndex.Count;

        //print(BlocksInPlayIndex.Count);
        //print("Placed BlockIndex: " + CurrentBlockIndex);
        //print("Blocks In Play: " + BlocksInPlay);
    } //end AddCrestToWall

    public void RemoveCrestFromWall(GameObject block)
    {
        CrestsOnWallIndex.Remove(block);
        CrestsOnWall = CrestsOnWallIndex.Count;
        //CurrentBlockIndexPos = BlocksInPlayIndex.Count;
    } //end RemoveCrestFromWall

    public void ResetBlocks()
    {
        BlocksInWallIndex.Clear();
        CrestsOnWallIndex.Clear();
        CurrentBlockIndexPos = BlocksInWallIndex.Count;
        CurrentCrestIndexPos = CrestsOnWallIndex.Count;
        BlocksInWall = BlocksInWallIndex.Count;
        CrestsOnWall = CrestsOnWallIndex.Count;
    } //end ResetBlocks

    //References
    //https://answers.unity.com/questions/490542/spawning-a-grid-of-cubes.html
} //end WallGenerator class