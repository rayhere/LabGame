using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] float horizontalMove;
    [SerializeField] float verticalMove;
    [SerializeField] public const int hSPEED = 2;
    [SerializeField] public const int vSPEED = 1;

    // Start is called before the first frame update
    void Start()
    {
        if (rigid == null)
            rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");
    }

    //can be called potentially many times per frame -- best for physics
    void FixedUpdate()
    {
        //border limit (background)
        if (horizontalMove < 0 && transform.position.x > 3) 
            horizontalMove = 0;
        else if (horizontalMove > 0 && transform.position.x < -3)
            horizontalMove = 0;
        if (verticalMove < 0 && transform.position.y > 1)
            verticalMove = 0;
        else if (verticalMove > 0 && transform.position.y < -1)
            verticalMove = 0;

        //movement (background)
        rigid.velocity = new Vector2(horizontalMove * hSPEED * -1, verticalMove * vSPEED * -1);
    }
}
