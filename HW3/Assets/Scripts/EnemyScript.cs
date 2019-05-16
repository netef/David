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


    // Start is called before the first frame update
    void Start()
    {
        David = GameObject.Find("David");
        score = GameObject.Find("Score").GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, David.transform.position, PlayerPrefs.GetFloat("attackSpeed", .03f));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Sword"))
        {
            score.SetText(Int32.Parse(score.text) + 1 + "");
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

        Debug.Log("game over");
        Destroy(gameObject);
    }
}
