using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.LSL4Unity.Scripts;
using Assets.LSL4Unity;

public class P300_ArchFlashes : MonoBehaviour
{
    public float flashLength;
    public float freqHz;
    public int samples;
    public Color onColor;
    public Color offColor;

    private List<Shapes2D.Shape> arcShapes;
    private DrawMeter drawMeter;
    private LSLMarkerStream marker;
    private Resolution[] resolution;
    private int refreshRate;
    private bool startFlashes;
    private List<int> flash_counter = new List<int>();
    private int counter = 0;
    private int numTrials;
    private int s_trials;

    public Color largeColor;
    public Color mediumColor;
    public Color smallColor;

    private List<int> s_indexes = new List<int>();

    void Start()
    {
        drawMeter = GameObject.FindGameObjectWithTag("Launcher").GetComponent<DrawMeter>();
        arcShapes = drawMeter.CreateArcList();
        SetUpSingle();

        print(largeColor.ToString());

        // marker = FindObjectOfType<LSLMarkerStream>();

        resolution = Screen.resolutions;
        print(Screen.resolutions[1]);
        refreshRate = resolution[3].refreshRate;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) {
            startFlashes = !startFlashes;

            if (startFlashes) {
                // marker.Write("P300 SingleFlash Begins");
                StartCoroutine("SingleFlash");
            }
        }
    }

    public void SetUpSingle() {
        //Setting counters for each shape
        for(int i = 0; i < arcShapes.Count; i++) {
            flash_counter.Add(samples);
        }

        numTrials = samples * arcShapes.Count;
        s_trials = numTrials;

        //Set up test single indices
        for(int i = 0; i < arcShapes.Count; i++) {
            s_indexes.Add(i);
        }

        print("---------- SINGLE FLASH DETAILS ----------");
        print("Number of Trials will be: " + numTrials);
        print("Number of flashes for each cell: " + samples);
        print("--------------------------------------");
    }


    /* Single Flash Operation */
    IEnumerator SingleFlash() {
        while(startFlashes){
            //Generate a random number from the list of indices that have non-zero counters
            System.Random random = new System.Random();
            int randomIndex = random.Next(s_indexes.Count);
            int randomShapeIndex = s_indexes[randomIndex];

            //Turn off the cubes to give the flashing image
            TurnOff();

            //If the counter is non-zero, then flash that cube and decrement the flash counter
            if(flash_counter[randomShapeIndex] > 0) {
                yield return new WaitForSecondsRealtime((1f/freqHz));

                Shapes2D.Shape randomShape = arcShapes[randomIndex];
                randomShape.settings.fillColor = new Color(255, 255, 255);                
                flash_counter[randomShapeIndex]--;
                counter++;
                print("CUBE: " + randomShape.ToString());
                print(counter);

                //Write to the LSL Outlet stream
               //marker.Write("s," + randomShape.ToString());
            } else if(numTrials == counter){
                print("Done P300 Single Flash Trials");
                break;
            } else {
                //If the counter for a specific cube has reached zero, then remove it from the indexes so that the random
                //number generator does not pick it again (to reduce lag)
                if(flash_counter[randomShapeIndex] == 0){
                    s_indexes.RemoveAt(randomIndex);
                }
                //Go to the next iteration of the single flash 
                continue;
            }

            yield return new WaitForSecondsRealtime(flashLength);

        }
        //ResetCounters();
        //Write to LSL stream to indicate end of P300 SingleFlash
       //marker.Write("P300 SingleFlash Ends");
        startFlashes = !startFlashes;
        //keyLocks[KeyCode.S] = !keyLocks[KeyCode.S];
    }

    public void TurnOff() {
        for (int i = 0; i < arcShapes.Count; i++) {
            Shapes2D.Shape shape = arcShapes[i];
            string shapeName = shape.ToString();

            if (shapeName.Contains("Large")) {
                shape.settings.fillColor = largeColor;
            } else if (shapeName.Contains("Medium")) {
                shape.settings.fillColor = mediumColor;
            } else {
                shape.settings.fillColor = smallColor;
            }
        }
    }
}
