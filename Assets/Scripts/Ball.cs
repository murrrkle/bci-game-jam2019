using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Vector3 InitialVelocity;
    public float SpeedCoefficient;
    public float DespawnThreshold;
    public Splatter splatter;

    public Color SplatColour;

    private Rigidbody rb;
    private SphereCollider sc;


    private Vector3 oldPos;

    // Start is called before the first frame update
    void Start()
    {
        oldPos = transform.position;
        SpeedCoefficient = 1;

        rb = this.gameObject.GetComponent<Rigidbody>();
        rb.AddForce(InitialVelocity * 2, ForceMode.Impulse);

        sc = this.gameObject.GetComponent<SphereCollider>();
        
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag.Contains("Obstacle_Flat"))
        {
            rb.AddForce(rb.velocity * SpeedCoefficient, ForceMode.Impulse);
            SpeedCoefficient *= 0.9f; // Easing function - how will the coefficient decrease over time
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(rb.velocity.magnitude);

        if (rb.velocity.magnitude <= DespawnThreshold) // Stop Ball if velocity is lower than Threshold.
        {
            rb.velocity = Vector3.zero;
        }
    }

    private void FixedUpdate()
    {
        Vector3 curPos = transform.position;

        if (Vector3.Distance(oldPos, curPos) <= 0.2)
        {
            Splatter splat  = (Splatter)Instantiate(splatter, transform.position, Quaternion.identity);
            splat.transform.parent = GameObject.Find("SplatTrail").transform;

            //spawns the splatter
            splat.GetComponent<Splatter>().splatColor = SplatColour;//set the splatter color
            splat.GetComponent<Splatter>().randomColor = false;//make random false as we want the splatter color to the color we assigned
            splat.GetComponent<Splatter>().ApplyStyle();//then apply the style

            oldPos = curPos;
        }
        
    }
}
