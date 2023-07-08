using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
                if (detectedObject != null)
                {
                    Items item = detectedObject.GetComponent<Items>();
                    if (item != null)
                    {
                        item.Interact();
                    }
                }
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
        item.SetActive(false); 
    }

    public void GrabDrop(GameObject item)
    {
        if (isGrabbing)
        {
            isGrabbing = false;
            if (grabbedObject != null)
            {
                grabbedObject.transform.parent = null;
                grabbedObject.transform.position = new Vector3(grabbedObject.transform.position.x, grabbedObjectYValue, grabbedObject.transform.position.z);
                grabbedObject = null;
            }
        }
        else
        {
            isGrabbing = true;
            if (item != null)
            {
                grabbedObject = item;
                grabbedObject.transform.parent = transform; 
                grabbedObjectYValue = grabbedObject.transform.position.y;
                grabbedObject.transform.localPosition = grabPoint.localPosition;
            }
        }
    }
}
