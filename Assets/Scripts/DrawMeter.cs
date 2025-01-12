﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawMeter : MonoBehaviour
{
    public int segments;
    public Shapes2D.Shape largeArc;
    public Shapes2D.Shape mediumArc;
    public Shapes2D.Shape smallArc;

    private List<Shapes2D.Shape> arcs;

    public List<Shapes2D.Shape> CreateArcList()
    {
        arcs = new List<Shapes2D.Shape>();
        arcs.Add(largeArc);
        arcs.Add(mediumArc);
        arcs.Add(smallArc);

        int zRotation = 18;
        for (int i = 1; i < segments; i++) {
            Shapes2D.Shape newLarge = Instantiate(largeArc);
            newLarge.transform.rotation = largeArc.transform.rotation;
            newLarge.transform.Rotate(0, 0, zRotation);
            newLarge.transform.position = largeArc.transform.position;
            newLarge.transform.parent = largeArc.transform.parent;
            arcs.Add(newLarge);

            Shapes2D.Shape newMed = Instantiate(mediumArc);
            newMed.transform.rotation = largeArc.transform.rotation;
            newMed.transform.Rotate(0, 0, zRotation);
            newMed.transform.position = largeArc.transform.position;
            newMed.transform.parent = largeArc.transform.parent;
            arcs.Add(newMed);

            Shapes2D.Shape newSmall = Instantiate(smallArc);
            newSmall.transform.rotation = largeArc.transform.rotation;
            newSmall.transform.Rotate(0, 0, zRotation);
            newSmall.transform.position = largeArc.transform.position;
            newSmall.transform.parent = largeArc.transform.parent;
            arcs.Add(newSmall);
        
            zRotation += 18;
        }

        return arcs;
    }
}
