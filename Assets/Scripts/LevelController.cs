using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    private int[] SplatCounts;
    public Ball ballprefab;
    public bool[] ActiveColours;
    public GameObject complete;
    public GameObject gameover;

    public int BallCount;


    //public Launcher launcher;


    // Start is called before the first frame update
    void Start()
    {
        SplatCounts = new int[5]{ 0, 0, 0, 0, 0 }; // R, G, B, M, Y
        // instantiate launcher here
    }


    // Update is called once per frame
    void Update()
    {
        // After running out of balls
        if (BallCount <= 0)
        {
            StartCoroutine(CheckWin());
        }

        // Flashes


        //GetRelativeColourPercentage();
        
    }

    IEnumerator CheckWin()
    {
        if (CheckWinState())
        {
            // Do Level Complete
            complete.SetActive(true);
            yield return new WaitForSeconds(5);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        { // Do Game Over
            gameover.SetActive(true);
            yield return new WaitForSeconds(5);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        Debug.Log("SWITCH TO NEW LEVEL");
    }

    private bool CheckWinState()
    {
        GameObject RedBar = GameObject.Find("Red Bar");
        GameObject GreenBar = GameObject.Find("Green Bar");
        GameObject BlueBar = GameObject.Find("Blue Bar");
        GameObject MagentaBar = GameObject.Find("Magenta Bar");
        GameObject YellowBar = GameObject.Find("Yellow Bar");

        GameObject[] colours = {RedBar, GreenBar, BlueBar, MagentaBar, YellowBar };

        for (int i = 0; i < 5; i++)
        {
            if (ActiveColours[i])
            {   
                if (colours[i].transform.GetChild(0).gameObject.GetComponent<Image>().fillAmount >
                    colours[i].transform.GetChild(1).gameObject.GetComponent<setThreshold>().threshold + 0.1f ||
                    colours[i].transform.GetChild(0).gameObject.GetComponent<Image>().fillAmount <
                    colours[i].transform.GetChild(1).gameObject.GetComponent<setThreshold>().threshold - 0.1f)
                {
                    return false;
                }
           }
        }
        return true;

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
        if (sum > 0) {

            for (int i = 0; i < SplatCounts.Length; i++)
            {
                p[i] = (double) ((int) ((SplatCounts[i] / sum) * 1000))/10;
            }
        }
        
        string debug = "";
        foreach (double i in p)
            debug += i.ToString() + " ";

        Debug.Log(debug);
        return p;
    }
}
