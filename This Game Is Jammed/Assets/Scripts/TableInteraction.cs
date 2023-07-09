using UnityEngine;

public class TableInteraction : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the colliding object is the player character
        if (collision.CompareTag("Player"))
        {
            // Perform table interaction logic here
            Debug.Log("Player entered the table interaction zone");
            // You can trigger actions like displaying a prompt, starting crafting, etc.
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Check if the colliding object is the player character
        if (collision.CompareTag("Player"))
        {
            // Perform any necessary cleanup or reset here
            Debug.Log("Player exited the table interaction zone");
            // You can reset any active interactions or states if needed
        }
    }
}
