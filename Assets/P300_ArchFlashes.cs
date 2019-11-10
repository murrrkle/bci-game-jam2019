using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.LSL4Unity.Scripts;
using Assets.LSL4Unity;

public class P300_ArchFlashes : MonoBehaviour
{
    public float flashLength;
    public int samples;
    public Color onColor;
    public Color offColor;

    private List<Shapes2D.Shape> arcShapes;
    private DrawMeter drawMeter;
    private LSLMarkerStream marker;
    private Resolution[] resolution;
    private int refreshRate;
    private bool startFlashes;

    void Start()
    {
        drawMeter = GameObject.FindGameObjectWithTag("Launcher").GetComponent<DrawMeter>();
        arcShapes = drawMeter.CreateArcList();

        marker = FindObjectOfType<LSLMarkerStream>();

        resolution = Screen.resolutions;
        refreshRate = resolution[3].refreshRate;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) {
            startFlashes = !startFlashes;

            if (startFlashes) {
                marker.Write("P300 SingleFlash Begins");
                
            }
        }
    }
}
