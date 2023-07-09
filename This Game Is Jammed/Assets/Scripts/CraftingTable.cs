using System.Collections.Generic;
using UnityEngine;

public class CraftingTable : MonoBehaviour

{
    public List<GameObject> requiredItems;
    public GameObject craftedItemPrefab;

    private List<GameObject> placedItems = new List<GameObject>();

    // Check if all required items are present on the table
    bool CheckCraftingConditions()
    {
        if (placedItems.Count != requiredItems.Count)
            return false;

        foreach (GameObject requiredItem in requiredItems)
        {
            bool foundItem = false;
            foreach (GameObject placedItem in placedItems)
            {
                if (placedItem.CompareTag(requiredItem.tag))
                {
                    foundItem = true;
                    break;
                }
            }

            if (!foundItem)
                return false;
        }

        return true;
    }

    // Craft the item if the conditions are met
    void CraftItem()
    {
        if (CheckCraftingConditions())
        {
            // Create the crafted item object
            GameObject craftedItem = Instantiate(craftedItemPrefab, transform.position, Quaternion.identity);

            // Remove the required items from the table
            foreach (GameObject requiredItem in requiredItems)
            {
                foreach (GameObject placedItem in placedItems)
                {
                    if (placedItem.CompareTag(requiredItem.tag))
                    {
                        Destroy(placedItem);
                        break;
                    }
                }
            }

            // Clear the placed items list
            placedItems.Clear();

            Debug.Log("Item crafted!");
        }
        else
        {
            Debug.Log("Missing required items!");
        }
    }

    // Detect when an item is dropped onto the table
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject item = collision.gameObject;

        // Check if the item is one of the required items
        if (requiredItems.Contains(item))
        {
            // Check if the slot is empty
            if (!placedItems.Contains(item))
            {
                // Add the item to the placed items list
                placedItems.Add(item);

                // Craft the item
                CraftItem();
            }
            else
            {
                Debug.Log("Slot is already occupied!");
            }
        }
        placedItems.Add(item);
    //debug
        CraftItem();
        {
    
    }
    
}

