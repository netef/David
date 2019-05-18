using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyScript : MonoBehaviour
{
    public GameObject explosion;
    GameObject David;
    TMP_Text score;
    GameObject gameOver;

    void Start()
    {
        David = GameObject.Find("David");
        score = GameObject.Find("Score").GetComponent<TMP_Text>();
        gameOver = GameObject.Find("David").GetComponent<PlayerScript>().gameOver;
    }

    void Update()
    {
        if (PlayerPrefs.GetInt("gameOver", 0) == 0)
            transform.position = Vector3.MoveTowards(transform.position, David.transform.position, PlayerPrefs.GetFloat("attackSpeed", .03f));
        else
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Sword"))
        {
            score.SetText(Int32.Parse(score.text) + 1 + "");
            PlayerPrefs.SetString("score", score.text);
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        else if (collision.gameObject.name.Equals("David"))
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        PlayerPrefs.SetInt("gameOver", 1);
        gameOver.SetActive(true);
        Destroy(gameObject);
    }
}