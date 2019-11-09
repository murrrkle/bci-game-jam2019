using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Vector3 InitialVelocity;

    private Rigidbody rb;
    private SphereCollider sc;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
        rb.AddForce(InitialVelocity * 2, ForceMode.Impulse);
        sc = this.gameObject.GetComponent<SphereCollider>();
        
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag.Contains("Obstacle_Flat"))
        {
            rb.AddForce(rb.velocity, ForceMode.Impulse);
        }
    }

    private void FixedUpdate()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
