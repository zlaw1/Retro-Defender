using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMove : MonoBehaviour
{
    Animator anim; 
    [SerializeField] float speed = 2.0f;
    Vector2 motionVector; 
    public Vector2 lastMotionVector;
    private Rigidbody2D rb;
    public bool moving;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        rb.velocity = motionVector * speed;
    }

    // Update is called once per frame
    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        motionVector = new Vector2(
            horizontal,
            vertical
            );

        anim.SetFloat("Horizontal", horizontal);
        anim.SetFloat("Vertical", vertical);

        moving = horizontal != 0 || vertical != 0;
        anim.SetBool("Moving", moving);


        if (horizontal != 0 || vertical != 0)
        {
            lastMotionVector = new Vector2(
            horizontal,
            vertical
            ).normalized;

            anim.SetFloat("lastHorizontal", horizontal);
            anim.SetFloat("lastVertical", vertical);


        }

    }
    
}
