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

    private void CastSpell ()
    {
        if ((slot1 == "fire" && slot2 == "earth") || (slot1 == "earth" && slot2 == "fire"))
        {
            print("Spell 1");
        }
        else if ((slot1 == "fire" && slot2 == "water") || (slot1 == "water" && slot2 == "fire"))
        {
            print("Spell 2");
        }
        else if ((slot1 == "earth" && slot2 == "water") || (slot1 == "water" && slot2 == "earth"))
        {
            print("Spell 3");
        }
        else if (slot1 == "fire" && slot2 == "fire")
        {
            print("Spell 4 - IgniteBall");
        }
        else if (slot1 == "earth" && slot2 == "earth")
        {
            print("Spell 5 - FortifyWall");
            spellManager.FortifyWall();
        }
        else if (slot1 == "water" && slot2 == "water")
        {
            print("Spell 6 - FreezeFloor");
            spellManager.FreezeFloor();
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
