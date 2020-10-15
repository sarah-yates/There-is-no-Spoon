using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    private Vector2 movementVector;
    private Animator animator;
    private Rigidbody2D rb2d;
    private SpriteRenderer bowl;

    public float movementSpeed;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        bowl = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (movementVector.x > 0) //East
        {
            animator.SetInteger("AnimationState", 2);
        }
        else if (movementVector.x < 0) //West
        {
            animator.SetInteger("AnimationState", 4);
        }
        else if (movementVector.y > 0) //North
        {
            animator.SetInteger("AnimationState", 1);
            bowl.sortingOrder = 0;
        }
        else if (movementVector.y < 0) //South
        {
            animator.SetInteger("AnimationState", 3);
        }
        else //Idle
        {
            animator.SetInteger("AnimationState", 0);
        }
    }
    void OnMove(InputValue movementValue)
    {
        movementVector = movementValue.Get<Vector2>()*movementSpeed;
    }

    private void FixedUpdate()
    {
        rb2d.velocity = movementVector;
    }
}
