using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rb;
    public float velocity;
    bool facingRight;

    ParallexScript first;
    ParallexScript second;
    ParallexScript third;
    ParallexScript fourth;
    ParallexScript fifth;

    SpriteRenderer head;
    SpriteRenderer body;
    SpriteRenderer sword;
    SpriteRenderer shield;
    SpriteRenderer leftLeg;
    SpriteRenderer rightLeg;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        facingRight = true;

        first = GameObject.Find("1").GetComponent<ParallexScript>();
        second = GameObject.Find("2").GetComponent<ParallexScript>();
        third = GameObject.Find("3").GetComponent<ParallexScript>();
        fourth = GameObject.Find("4").GetComponent<ParallexScript>();
        fifth = GameObject.Find("5").GetComponent<ParallexScript>();

        head = GameObject.Find("Head").GetComponent<SpriteRenderer>();
        body = GameObject.Find("Body").GetComponent<SpriteRenderer>();
        sword = GameObject.Find("Sword").GetComponent<SpriteRenderer>();
        shield = GameObject.Find("Shield").GetComponent<SpriteRenderer>();
        leftLeg = GameObject.Find("Left Leg").GetComponent<SpriteRenderer>();
        rightLeg = GameObject.Find("Right Leg").GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            anim.SetTrigger("run");
            if (facingRight)
            {
                first.velocity = 0.01f;
                second.velocity = 0.03f;
                third.velocity = 0.06f;
                fourth.velocity = 0.1f;
                fifth.velocity = 0.2f;
            }
            else
            {
                first.velocity = -0.01f;
                second.velocity = -0.03f;
                third.velocity = -0.06f;
                fourth.velocity = -0.1f;
                fifth.velocity = -0.2f;
            }
        }
        else
        {
            anim.SetTrigger("idle");
            first.velocity = 0;
            second.velocity = 0;
            third.velocity = 0;
            fourth.velocity = 0;
            fifth.velocity = 0;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            if (facingRight)
            {
                facingRight = false;

                head.flipX = true;
                body.flipX = true;
                sword.flipX = true;
                shield.flipX = true;
                leftLeg.flipX = true;
                rightLeg.flipX = true;
            }

        }

        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            if (!facingRight)
            {
                facingRight = true;

                head.flipX = false;
                body.flipX = false;
                sword.flipX = false;
                shield.flipX = false;
                leftLeg.flipX = false;
                rightLeg.flipX = false;
            }

        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("jump");
            rb.AddForce(new Vector2(0, 1500));
        }
    }
}