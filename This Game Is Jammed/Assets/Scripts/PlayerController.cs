using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
   private Animator thisAnim;
    private Rigidbody2D rigid;
    public Vector2 speed = new Vector2(50, 50);

    // Use this for initialization
    void Start()
    {
        //thisAnim = GetComponent<Animator>();
       thisAnim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var h = Input.GetAxis("Horizontal");
        thisAnim.SetFloat("Speed", Mathf.Abs(h));

        
        if (h < 0.0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (h > 0.0f)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(speed.x * inputX, speed.y * inputY, 0);
        movement *= Time.deltaTime;
        transform.Translate(movement);
    }
}
