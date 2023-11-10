using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigid; //get object, slingshot
    [SerializeField] float movement;
    [SerializeField] public const int SPEED = 15;

    // Start is called before the first frame update
    void Start()
    {
        //get object, slingshot
        if (rigid == null)
            rigid = GetComponent<Rigidbody2D>();


    }

    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxis("Horizontal");
    }

    //can be called potentially many times per frame -- best for physics
    void FixedUpdate()
    {
        rigid.velocity = new Vector2(movement * SPEED, rigid.velocity.y);

        
    }
}
