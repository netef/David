using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParallexScript : MonoBehaviour
{

    public float velocity;

    // Update is called once per frame
    void Update()
    {
        GetComponent<Image>().materialForRendering.mainTextureOffset = 
            new Vector2(GetComponent<Image>().materialForRendering.mainTextureOffset.x + velocity * Time.deltaTime, 0);
    }
}
