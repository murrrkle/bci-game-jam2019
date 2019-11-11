using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setThreshold : MonoBehaviour
{
    // Start is called before the first frame update

    public float threshold;
    private float thresholdAdjusted;

    private float thresholdHeight;

    private float barheight;
    void Start()
    {
        barheight = 50;
        thresholdHeight = 10;
        thresholdAdjusted = threshold*barheight + thresholdHeight;
    }

    // Update is called once per frame
    void Update()
    {
        if(threshold > 0)
        {
            SetTransformX(thresholdAdjusted);
        }
        
    }

    void SetTransformX(float n)
    {
        transform.position = new Vector3(transform.position.x, n, transform.position.z);
    }
}
