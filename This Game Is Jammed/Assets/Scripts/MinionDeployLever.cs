using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionDeployLever : MonoBehaviour
{
    public Sprite GreenLever;
    public Sprite RedLever;
    public bool overlap = false;
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = RedLever;
    }

    // Update is called once per frame
    void Update()
    {

        

        if (overlap == true)
        { 


        if (Input.GetKeyDown(KeyCode.E))
        {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = GreenLever;
            }


    }
        }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            overlap = true;  
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            overlap = false;
        }

    }
}

