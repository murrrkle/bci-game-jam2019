using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Vector3 InitialVelocity;
    public float SpeedCoefficient;
    public float DespawnThreshold;

    private Rigidbody rb;
    private SphereCollider sc;

    // Start is called before the first frame update
    void Start()
    {
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
}
