using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Items : MonoBehaviour
{
    public enum InteractionType { NONE, PickUp, Examine, GrabDrop }
    public InteractionType InteractType;

    private void Reset()
    {
        GetComponent<Collider2D>().isTrigger = true;
        gameObject.layer = 11;
    }

    public void Interact()
    {
        switch (InteractType)
        {
            case InteractionType.PickUp:
                FindObjectOfType<InteractionScript>().PickUpItem(gameObject);
                gameObject.SetActive(false);
                Debug.Log("PICK UP");
                break;
            case InteractionType.Examine:
                Debug.Log("EXAMINE");
                // Grab interaction
                break;
            case InteractionType.GrabDrop:
                FindObjectOfType<InteractionScript>().GrabDrop();
                break;
            default:
                Debug.Log("NULL ITEM");
                break;
        }
    }
}
