using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverScoreScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<TMP_Text>().SetText(int.Parse(PlayerPrefs.GetString("score", "0")) + "");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
