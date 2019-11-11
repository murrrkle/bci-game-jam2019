using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    private int[] SplatCounts;
    public Ball ballprefab;
    //public Launcher launcher;


    // Start is called before the first frame update
    void Start()
    {
        SplatCounts = new int[5] { 0, 0, 0, 0, 0 }; // R, G, B, M, Y
        // instantiate launcher here
    }


    // Update is called once per frame
    void Update()
    {
        
        //GetRelativeColourPercentage();

    }

    public void AddCount(Splatter.SplatColour c)
    {
        SplatCounts[(int)c] += 1;
    }

    public void MinusCount(Splatter.SplatColour c)
    {
        //SplatCounts[(int)c] -= 1;
    }

    public double[] GetRelativeColourPercentage()
    {
        double[] p = { 0,0,0,0,0};

        double sum = 0;

        foreach (int i in SplatCounts)
            sum += (double)i;

        for (int i = 0; i < SplatCounts.Length; i++)
        {
            p[i] = (double) ((int) ((SplatCounts[i] / sum) * 1000))/10;
        }
        /*
        string debug = "";
        foreach (double i in p)
            debug += i.ToString() + " ";

        Debug.Log(debug);*/
        return p;
    }
}
