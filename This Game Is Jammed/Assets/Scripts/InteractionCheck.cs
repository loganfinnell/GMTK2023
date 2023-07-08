using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionChecker : MonoBehaviour
{
    [SerializeField] private float interactionRadius = 1f;
    [SerializeField] private LayerMask interactionLayer;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            CheckInteraction();
        }
    }

    void CheckInteraction()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, interactionRadius, interactionLayer);

        if (colliders.Length > 0)
        {
            foreach (Collider2D collider in colliders)
            {
                Items item = collider.GetComponent<Items>();
                if (item != null)
                {
                    item.Interact();
                }
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, interactionRadius);
    }
}
