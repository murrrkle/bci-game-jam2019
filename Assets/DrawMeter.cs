using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawMeter : MonoBehaviour
{
    public int segments;
    public Shapes2D.Shape largeArc;
    public Shapes2D.Shape mediumArc;
    public Shapes2D.Shape smallArc;

    private List<Shapes2D.Shape> arcs;

    void Start()
    {
        arcs = new List<Shapes2D.Shape>();
        arcs.Add(largeArc);
        arcs.Add(mediumArc);
        arcs.Add(smallArc);

        int zRotation = 18;
        for (int i = 1; i < segments; i++) {
            Shapes2D.Shape newLarge = Instantiate(largeArc);
            newLarge.transform.Rotate(0, 0, zRotation);
            arcs.Add(newLarge);
            Shapes2D.Shape newMed = Instantiate(mediumArc);
            newMed.transform.Rotate(0, 0, zRotation);
            arcs.Add(newMed);
            Shapes2D.Shape newSmall = Instantiate(smallArc);
            newSmall.transform.Rotate(0, 0, zRotation);
            arcs.Add(newSmall);

            zRotation += 18;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
