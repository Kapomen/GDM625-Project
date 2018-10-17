using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerElementManager : MonoBehaviour {

    private string fire = "fire";
    private string earth = "earth";
    private string water = "water";

    private string slot1;
    private bool slot1Set;

    private string slot2;
    private bool slot2Set;

    SpellManager spellManager;

    //public GameObject Spell1Icon;
    //public GameObject Spell2Icon;
    //public GameObject Spell3Icon;
    public GameObject IgniteBallIcon;
    public GameObject FortifyWallIcon;
    public GameObject FreezeFloorIcon;

    // Use this for initialization
    void Start () {
        spellManager = GetComponent<SpellManager>();
        ClearElementSlots();
    } //end Start
	
	// Update is called once per frame
	void Update () {
	}

    public void PickupElement (string tag)
    {
        string element = string.Empty;

        if (tag == "Element_Fire")
        {
            element = fire;
        } else if (tag == "Element_Earth")
        {
            element = earth;
        } else if (tag == "Element_Water")
        {
            element = water;
        }

        if (!slot1Set)
        {
            slot1 = element;
            slot1Set = true;
        } else
        {
            slot2 = element;
            slot2Set = true;
        }

        if (slot1Set & slot2Set)
        {
            CastSpell();
        }
    } //end PickupElement

    IEnumerator LateCall()
    {
        yield return new WaitForSeconds(1);
        //Spell1Icon.SetActive(true);
        //Spell2Icon.SetActive(true);
        //Spell3Icon.SetActive(true);
        IgniteBallIcon.SetActive(true);
        FortifyWallIcon.SetActive(true);
        FreezeFloorIcon.SetActive(true);
    }

    private void CastSpell ()
    {
        if ((slot1 == "fire" && slot2 == "earth") || (slot1 == "earth" && slot2 == "fire"))
        {
            //Spell1Icon.SetActive(true);
            print("Spell 1");
            StartCoroutine(LateCall());
        }
        else if ((slot1 == "fire" && slot2 == "water") || (slot1 == "water" && slot2 == "fire"))
        {
            //Spell2Icon.SetActive(true);
            print("Spell 2");
            StartCoroutine(LateCall());
        }
        else if ((slot1 == "earth" && slot2 == "water") || (slot1 == "water" && slot2 == "earth"))
        {
            //Spell3Icon.SetActive(true);
            print("Spell 3");
            StartCoroutine(LateCall());
        }
        else if (slot1 == "fire" && slot2 == "fire")
        {
            IgniteBallIcon.SetActive(false);
            print("Spell 4 - IgniteBall");
            spellManager.IgniteBall();
            StartCoroutine(LateCall());
        }
        else if (slot1 == "earth" && slot2 == "earth")
        {
            FortifyWallIcon.SetActive(false);
            print("Spell 5 - FortifyWall");
            spellManager.FortifyWall();
            StartCoroutine(LateCall());
        }
        else if (slot1 == "water" && slot2 == "water")
        {
            FreezeFloorIcon.SetActive(false);
            print("Spell 6 - FreezeFloor");
            spellManager.FreezeFloor();
            StartCoroutine(LateCall());
        }

        print("SPELL CASTED - Slot 1: " + slot1 + ", Slot 2: " + slot2);
        ClearElementSlots();
    } //end CastSpell

    private void ClearElementSlots ()
    {
        slot1 = string.Empty;
        slot2 = string.Empty;
        slot1Set = false;
        slot2Set = false;
        //print("SLOTS CLEARED - Slot 1: " + slot1 + ", Slot 2: " + slot2);
    } //end ClearElementSlots

    private void OnTriggerEnter(Collider col)
    {
        string otherTag = col.GetComponent<Collider>().tag;

        if (otherTag == "Element_Fire" || otherTag == "Element_Earth" || otherTag == "Element_Water")
        {
            PickupElement(otherTag);
            //print(otherTag);
        }
    } //end OnTriggerEnter

} //end PlayerElementManager
