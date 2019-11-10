using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    //public Color Colour;
    public Splatter.SplatColour Colour;
    private MeshRenderer mr;
    // Start is called before the first frame update
    void Start()
    {
        mr = this.gameObject.GetComponent<MeshRenderer>();
        //mr.material.color = Colour;
        switch (Colour)
        {
            case Splatter.SplatColour.R:
                mr.material.color = Color.red;
                break;
            case Splatter.SplatColour.G:
                mr.material.color = Color.green;
                break;
            case Splatter.SplatColour.B:
                mr.material.color = Color.blue;
                break;
            case Splatter.SplatColour.M:
                mr.material.color = Color.magenta;
                break;
            case Splatter.SplatColour.Y:
                mr.material.color = Color.yellow;
                break;


            default:
                break;

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
