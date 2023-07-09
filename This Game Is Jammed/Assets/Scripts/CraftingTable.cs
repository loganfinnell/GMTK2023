using System.Collections.Generic;
using UnityEngine;

public class CraftingTable : MonoBehaviour
{
    public List<GameObject> requiredBodyParts;
    private List<GameObject> placedBodyParts = new List<GameObject>();

    // Check if all required body parts are placed on the table
    bool CheckCraftingConditions()
    {
        if (placedBodyParts.Count != requiredBodyParts.Count)
            return false;

        foreach (GameObject requiredBodyPart in requiredBodyParts)
        {
            bool foundPart = false;
            foreach (GameObject placedBodyPart in placedBodyParts)
            {
                if (placedBodyPart.CompareTag(requiredBodyPart.tag))
                {
                    foundPart = true;
                    break;
                }
            }

            if (!foundPart)
                return false;
        }

        return true;
    }

    // Craft the scientist if the conditions are met
    void CraftScientist()
    {
        if (CheckCraftingConditions())
        {
            // Instantiate the scientist prefab or trigger the desired crafting logic
            Debug.Log("Scientist Crafted!");
        }
        else
        {
            Debug.Log("Missing Required Body Parts!");
        }
    }

    // Detect when a body part is placed on the table
    private void OnTriggerEnter(Collider other)
    {
        GameObject bodyPart = other.gameObject;
        placedBodyParts.Add(bodyPart);

        CraftScientist();
    }

    // Detect when a body part is removed from the table
    private void OnTriggerExit(Collider other)
    {
        GameObject bodyPart = other.gameObject;
        placedBodyParts.Remove(bodyPart);
    }
}
