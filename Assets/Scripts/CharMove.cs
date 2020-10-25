using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMove : MonoBehaviour
{
    Animator anim; 
    private Rigidbody2D rb;
    Vector2 motionVector; 
    public Vector2 lastMotionVector;
    public bool moving;
    private bool attack;
    [SerializeField] float speed = 2.0f;

    public int attackDamage =40;
    public float attackRange = 1f;
    public LayerMask enemyLayers;
    public Transform attackPoint;
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        Move();
        Attack();
        ResetValues();
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
        if(Input.GetMouseButtonDown(0))
        {
            attack = true;
        }
    }

        public void ResetValues()
        {
            attack = false;
        }
        public void Attack()
        {
            if(attack) 
            {
                
                anim.SetTrigger("attack");
                rb.velocity = Vector2.zero;

                Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

                foreach(Collider2D enemy in hitEnemies)
                {
                    enemy.GetComponent<EnemHealth>().TakeDamage(attackDamage);
                }
            }
        }

        void OnDrawGizmosSelected() 
        {
            if(attackPoint == null ) return;
            Gizmos.DrawWireSphere(attackPoint.position, attackRange);    
        }
}
