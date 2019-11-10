using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Vector3 InitialVelocity;
    public float SpeedCoefficient;
    public float DespawnThreshold;
    public float SplatDistanceThreshold;
    public Splatter splatter;

    public Color SplatColour;

    private Rigidbody rb;
    private SphereCollider sc;


    private Vector3 oldPos;

    private Color[] colorset = {Color.red, Color.green, Color.blue};

    // Start is called before the first frame update
    void Start()
    {
        oldPos = transform.position;
        SpeedCoefficient = 1;

        rb = this.gameObject.GetComponent<Rigidbody>();
        rb.AddForce(InitialVelocity * 2, ForceMode.VelocityChange);

        sc = this.gameObject.GetComponent<SphereCollider>();
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        string collisionTag = collision.gameObject.tag;
        if (collisionTag.Contains("Obstacle_Flat"))
        {
            //rb.AddForce(rb.velocity * SpeedCoefficient, ForceMode.VelocityChange);
            rb.AddForce(rb.velocity* SpeedCoefficient, ForceMode.VelocityChange);
            SpeedCoefficient *= 0.9f; // Easing function - how will the coefficient decrease over time
        }
        else if (collisionTag.Contains("Bumper")) {
            SpeedCoefficient = 1;
            rb.AddForce(rb.velocity.normalized * 5, ForceMode.VelocityChange);
        }

        if( collision.gameObject.tag.Contains("Random"))
        {
            SplatColour = colorset[(int)Random.Range(0,3)];
        }
         if (collision.gameObject.tag.Contains("Colour"))
        {
            SplatColour = collision.gameObject.GetComponent<Wall>().Colour;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(rb.velocity.magnitude);

        if (rb.velocity.magnitude <= DespawnThreshold) // Stop Ball if velocity is lower than Threshold.
        {
            rb.velocity = Vector3.zero;
        }

        else if (rb.velocity.magnitude >= 50)
        {
            rb.velocity = rb.velocity.normalized * 50;
        }

        Vector3 curPos = transform.position;

        if (Vector3.Distance(oldPos, curPos) >= SplatDistanceThreshold && SplatColour.a != 0)
        {
            Splatter splat = (Splatter)Instantiate(splatter, transform.position, Quaternion.identity);
            splat.transform.parent = GameObject.Find("SplatTrail").transform;

            //spawns the splatter
            splat.GetComponent<Splatter>().splatColor = SplatColour;//set the splatter color
            splat.GetComponent<Splatter>().randomColor = false;//make random false as we want the splatter color to the color we assigned
            splat.GetComponent<Splatter>().ApplyStyle();//then apply the style

            oldPos = curPos;
        }
    }
    
}
