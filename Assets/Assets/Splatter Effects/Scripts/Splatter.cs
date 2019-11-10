using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Splatter : MonoBehaviour
{
    public enum SplatColour
    {
        R = 0,
        G = 1,
        B = 2,
        M = 3,
        Y = 4,
        N = -1
    }

    public SplatColour splatColour;

    public List<Sprite> sprites; //ref to the sprites which will be used by sprites renderer
    [HideInInspector]
    public bool randomColor = true; //set to false when the target gives the color
    [HideInInspector]
    public Color32 splatColor; //color values which can be assigned by another script
    private SpriteRenderer spriteRenderer;//ref to sprite renderer component

    private LevelController lc;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        //at start we randomly select the sprites
        spriteRenderer.sprite = sprites[Random.Range(0, sprites.Count)];
        //checks if randomColor is true and then randomly apply the colors
        if (randomColor)
        {
            ApplyStyle();
        }

        lc = GameObject.Find("LevelController").GetComponent<LevelController>();
     }


    //this methode assign the color to the splatter
    public void ApplyStyle()
    {
        if (randomColor == true)
        {
            spriteRenderer.color = new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f));
        }
        else
        {//when the other script has power to assign the color , this code is used
            switch (splatColour)
            {
                case SplatColour.R:
                    spriteRenderer.color = Color.red;
                    break;
                case SplatColour.G:
                    spriteRenderer.color = Color.green;
                    break;
                case SplatColour.B:
                    spriteRenderer.color = Color.blue;
                    break;
                case SplatColour.M:
                    spriteRenderer.color = Color.magenta;
                    break;
                case SplatColour.Y:
                    spriteRenderer.color = Color.yellow;
                    break;


                default:
                    break;

            }
        }
        transform.rotation = Quaternion.Euler(90, 0, Random.Range(0, 360));
    }
    private void OnBecameVisible()
    {
        lc.AddCount(splatColour);
    }
}
