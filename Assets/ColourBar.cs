using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColourBar : MonoBehaviour
{
    public int maxColorArea = 100; // Change to total area of map
    public int currentColorArea = 0;
    public Image colorBar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Update value of currentColorArea
        // currentColor = calculated area of colour on screen

        // Calculate colour bar fill amount
        colorBar.fillAmount = (float)currentColorArea / (float)maxColorArea;        
    }
}
