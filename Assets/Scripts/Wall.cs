using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public Color Colour;

    private MeshRenderer mr;
    // Start is called before the first frame update
    void Start()
    {
        mr = this.gameObject.GetComponent<MeshRenderer>();
        mr.material.color = Colour;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
