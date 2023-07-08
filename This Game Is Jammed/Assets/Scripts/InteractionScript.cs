using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class InteractionScript : MonoBehaviour
{
    public Transform detectionPoint;
    private const float detectionRadius = 0.2f;
    public LayerMask detectionLayer;
    public GameObject detectedObject;
    public GameObject grabbedObject;
    public List<GameObject> pickedItems = new List<GameObject>();
    public bool isGrabbing;
    public float grabbedObjectYValue;
    public Transform grabPoint;

    // Update is called once per frame
    void Update()
    {
        if (DetectObject())
        {
            if (InteractInput())
            {
                //If we are grabbing something don't interact with other items, drop the grabbed item first
                if (isGrabbing)
                {
                    GrabDrop();
                    return;
                }

                detectedObject.GetComponent<Items>().Interact();
            }
        }
    }

    bool InteractInput()
    {
        return Input.GetKeyDown(KeyCode.E);
    }

    bool DetectObject()
    {
        Collider2D obj = Physics2D.OverlapCircle(detectionPoint.position, detectionRadius, detectionLayer);

        if (obj == null)
        {
            detectedObject = null;
            return false;
        }
        else
        {
            detectedObject = obj.gameObject;
            return true;
        }
    }

    public void PickUpItem(GameObject item)
    {
        pickedItems.Add(item);
        item.SetActive(false); // Disable the item when picked up
    }

    public void GrabDrop()
    {
         if(isGrabbing)
        {
            //make isGrabbing false
            isGrabbing=false;
            //unparent the grabbed object
            grabbedObject.transform.parent=null;            
            //set the y position to its origin
            grabbedObject.transform.position = 
                new Vector3(grabbedObject.transform.position.x,grabbedObjectYValue,grabbedObject.transform.position.z);
            //null the grabbed object reference
            grabbedObject=null;
        }
        //Check if we have nothing grabbed grab the detected item
        else
        {
            //Enable the isGrabbing bool
            isGrabbing=true;
            //assign the grabbed object to the object itself
            grabbedObject=detectedObject;
            //Parent the grabbed object to the player
            grabbedObject.transform.parent=transform;
            //Cache the y value of the object
            grabbedObjectYValue=grabbedObject.transform.position.y;
            //Adjust the position of the grabbed object to be closer to hands                        
            grabbedObject.transform.localPosition=grabPoint.localPosition;
        }
    }
}