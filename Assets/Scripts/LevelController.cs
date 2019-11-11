using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    private int[] SplatCounts;
    public Ball ballprefab;
    public GameObject launcher;

    private DrawMeter drawMeter;
    private P300_ArchFlashes flasher;
    private List<Shapes2D.Shape> arcList;
    private bool isBallRolling = false;
    private bool isFlashing = false;
    private int largePower = 8;
    private int mediumPower = 5;
    private int smallPower = 3;
    private GameObject markerStream;
    private Inlet_P300 inlet;
    private Vector3 launchVector;

    // Start is called before the first frame update
    void Start()
    {
        SplatCounts = new int[5] { 0, 0, 0, 0, 0 }; // R, G, B, M, Y
        // instantiate launcher here
        launcher = GameObject.FindGameObjectsWithTag("Launcher")[0];
        drawMeter = launcher.GetComponent<DrawMeter>();
        arcList = drawMeter.CreateArcList();
        flasher = launcher.GetComponent<P300_ArchFlashes>();
        launcher.SetActive(false);

        markerStream = GameObject.FindGameObjectsWithTag("MarkerStream")[0];
        inlet = markerStream.GetComponent<Inlet_P300>();
    }


    // Update is called once per frame
    void Update()
    {
        //GetRelativeColourPercentage();
        if (!isBallRolling) {
            launcher.SetActive(true);
            flasher.StartFlashes(arcList);
            isBallRolling = !isBallRolling;
            isFlashing = true;
        }

        if (isFlashing) {
            if (Input.GetMouseButtonDown(0)) {
                RaycastHit hitInfo;
                bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
            
                if (hit) {
                    Shapes2D.Shape shape = hitInfo.transform.gameObject.GetComponent<Shapes2D.Shape>();
                    int shapeIndex = arcList.IndexOf(shape);
                    print(shapeIndex);
                    if (shapeIndex >= 0) {
                        launchVector = CalculateLaunchVector(shapeIndex);
                        isFlashing = !isFlashing;
                        GameObject.Find("Index").GetComponent<Text>().text = "Index: " + shapeIndex;
                        //Call function to launch ball here
                    }
                }
                
            }

            if (!flasher.startFlashes && inlet.cubeIndex >= 0) {
                launchVector = CalculateLaunchVector(inlet.cubeIndex);
                isFlashing = !isFlashing;
                GameObject.Find("Index").GetComponent<Text>().text = "Index: " + inlet.cubeIndex;
                //Call function to launch ball here
            }
        }
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

    private Vector3 CalculateLaunchVector(int index) {
        int power = 0;
        if (index % 3 == 0) {
            power = largePower;
        } else if (index % 3 == 1) {
            power = mediumPower;
        } else {
            power = smallPower;
        }
        
        int xPower = power;
        int zPower = power;
        int row = index / 3;

        switch (row) {
            case 1:
                zPower /= 4;
                break;
            case 2:
                zPower /= 2;
                break;
            case 4:
                xPower /= 2;
                break;
            case 5:
                xPower /= 4;
                break;
        }

        return new Vector3(xPower, 0, zPower);
    }
}
