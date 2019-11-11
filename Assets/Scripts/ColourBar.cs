using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColourBar : MonoBehaviour
{
    private double[] colourArray; // = {0,0,0,0,0}; // Get current colour proportions
    private double yellowCount;
    private double redCount;
    private double blueCount;
    private double greenCount;
    private double magentaCount;
    private double totalCount;

    public Image colorBar;

    public LevelController level_controller;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Update value of currentColorArea
        colourArray = level_controller.GetRelativeColourPercentage();

        redCount = colourArray[0];
        greenCount = colourArray[1];
        blueCount = colourArray[2];
        magentaCount = colourArray[3];
        yellowCount = colourArray[4];
        totalCount = redCount + greenCount + blueCount + magentaCount + yellowCount + 1;

        // Calculate colour bar fill amount
        if(gameObject.tag.Contains("Red"))
        {
            colorBar.fillAmount = (float)redCount/(float)totalCount;
        }
        else if(gameObject.tag.Contains("Green"))
        {
            colorBar.fillAmount = (float)greenCount/(float)totalCount;
        }
        else if(gameObject.tag.Contains("Blue"))
        {
            colorBar.fillAmount = (float)blueCount/(float)totalCount;
        }
        else if(gameObject.tag.Contains("Yellow"))
        {
            colorBar.fillAmount = (float)yellowCount/(float)totalCount;
        }
        else if(gameObject.tag.Contains("Magenta"))
        {
            colorBar.fillAmount = (float)magentaCount/(float)totalCount;
        }
    }
}
