using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
<<<<<<< HEAD
    //private Animator thisAnim;
=======
   // private Animator thisAnim;
>>>>>>> 0f51d7277489c108c125d807fe0898860abf5dcf
    private Rigidbody2D rigid;
    public Vector2 speed = new Vector2 (50,50);
    // Use this for initialization
    void Start()
    {
<<<<<<< HEAD
        //thisAnim = GetComponent<Animator>();
=======
       // thisAnim = GetComponent<Animator>();
>>>>>>> 0f51d7277489c108c125d807fe0898860abf5dcf
        rigid = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        var h = Input.GetAxis("Horizontal");
<<<<<<< HEAD
        //thisAnim.SetFloat("Speed", Mathf.Abs(h));
=======
       // thisAnim.SetFloat("Speed", Mathf.Abs(h));
>>>>>>> 0f51d7277489c108c125d807fe0898860abf5dcf
        if (h < 0.0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (h > 0.0)
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
