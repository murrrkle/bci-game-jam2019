using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class TextColourChange : MonoBehaviour
{
    float elapsed = 0f;
    float timeLeft;
    Color targetColor;

    // Start is called before the first frame update
    void Start()
    {
        targetColor = Color.black;
    }
 
    void Update()
    {

        if (timeLeft <= Time.deltaTime)
        {
            // transition complete
            // assign the target color
            GetComponent<Text>().color = targetColor;
        
            // start a new transition
            targetColor = new Color(Random.value, Random.value, Random.value);
            timeLeft = 1.0f;
        }
        else
        {
            // transition in progress
            // calculate interpolated color
            GetComponent<Text>().color = Color.Lerp(GetComponent<Text>().color, targetColor, Time.deltaTime / timeLeft);
        
            // update the timer
            timeLeft -= Time.deltaTime;
        }

    }
    

}
