﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    int counter, frequency;
    Animator anim;
    Rigidbody2D rb;
    bool facingRight;
    public bool isGrounded;

    ParallexScript first;
    ParallexScript second;
    ParallexScript third;
    ParallexScript fourth;
    ParallexScript fifth;

    public GameObject pacman;
    public GameObject gameOver;

    void Start()
    {
        counter = 1;
        frequency = 4;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        facingRight = true;
        isGrounded = true;

        first = GameObject.Find("1").GetComponent<ParallexScript>();
        second = GameObject.Find("2").GetComponent<ParallexScript>();
        third = GameObject.Find("3").GetComponent<ParallexScript>();
        fourth = GameObject.Find("4").GetComponent<ParallexScript>();
        fifth = GameObject.Find("5").GetComponent<ParallexScript>();

        Invoke("MakeEnemy", .01f);

        PlayerPrefs.SetFloat("attackSpeed", .03f);
        PlayerPrefs.SetInt("gameOver", 0);

        gameOver = GameObject.Find("GameOver");
        gameOver.SetActive(false);

        PlayerPrefs.SetInt("score", 0);

    }

    void Update()
    {

        if (PlayerPrefs.GetInt("gameOver", 0) == 0)
        {
            if (Input.GetAxis("Horizontal") != 0)
            {
                anim.SetTrigger("run");
                first.velocity = 0.01f * Input.GetAxis("Horizontal");
                second.velocity = 0.03f * Input.GetAxis("Horizontal");
                third.velocity = 0.06f * Input.GetAxis("Horizontal");
                fourth.velocity = 0.1f * Input.GetAxis("Horizontal");
                fifth.velocity = 0.2f * Input.GetAxis("Horizontal");
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

            if ((Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) && facingRight)
            {
                facingRight = false;
                transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            }

            if ((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) && !facingRight)
            {
                    facingRight = true;
                    transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);

            }

            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                anim.SetTrigger("jump");
                rb.AddForce(new Vector2(0, 1500));
            }

            counter++;
            if (counter % 1200 == 0 && frequency > 1)
            {
                PlayerPrefs.SetFloat("attackSpeed", PlayerPrefs.GetFloat("attackSpeed", .03f) + .03f);
                frequency--;
            }
        }
        else
        {
            first.velocity = 0;
            second.velocity = 0;
            third.velocity = 0;
            fourth.velocity = 0;
            fifth.velocity = 0;
            Destroy(gameObject);
        }

    }

    void MakeEnemy()
    {
        int rand = Random.Range(-10, -5);
        int rand2 = Random.Range(5, 10);
        int rand3 = Random.Range(0, 2);
        if (rand3 == 0)
            Instantiate(pacman, new Vector3(transform.position.x + rand, 3, 0), Quaternion.identity);
        else
            Instantiate(pacman, new Vector3(transform.position.x + rand2, 3, 0), Quaternion.identity);

        Invoke("MakeEnemy", frequency);
    }
}