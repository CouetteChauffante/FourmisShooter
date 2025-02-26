using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float fHorizontal;
    [SerializeField] private float fSpeed;
    [SerializeField] private Animator animator;


    public Rigidbody2D rb;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        
    }
    // Update is called once per frame
    void Update()
    {
        fHorizontal =Input.GetAxisRaw("Horizontal") ;
       
    }
    void FixedUpdate()
    {
        rb.velocity = new Vector2(fHorizontal * fSpeed, rb.velocity.y);
        Attack();
    }
    
    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Space)){
            Debug.Log("Attack");
            animator.Play("Attack");
            
            

        }
        

    }
}
