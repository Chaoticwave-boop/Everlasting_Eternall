using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;
    private float dirX = 0f;
    [SerializeField] private float MoveSpeed = 7f;
    [SerializeField] private float JumpForce = 14f;


    // Start is called before the first frame update
    private void Start()
    {
        Debug.Log("Game Start :)");
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(dirX * MoveSpeed, rb.velocity.y);  

        if(Input.GetButtonDown("Jump")){
            rb.velocity = new Vector2(rb.velocity.x, JumpForce);
        }

        UpdateAnimationState();
        
    }

    private void UpdateAnimationState() {
        if(dirX > 0f){
            anim.SetBool("Running", true);
            sprite.flipX = false;
        }
        else if (dirX < 0f){
            anim.SetBool("Running", true);
            sprite.flipX = true;
        }else {
            anim.SetBool("Running", false);
        }
    }
}
