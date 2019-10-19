using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;

    public float forwardForce = 200f;
    public float sidewaysForce = 150f;
    public float upwardForce = 1000f;
    public float maxVelocity = 10f;
    public int depth = 10;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (rb.velocity[0] <= maxVelocity)
        {
            rb.AddForce(forwardForce, 0, 0);
        }

        // Ground is at y=0
        if ((Input.GetKey(UnityEngine.KeyCode.Space)) && rb.position[1] < 0.1 && rb.velocity[1] <= 0)
        {
            rb.AddForce(0, 5 * upwardForce, 0);
        }

        if ((Input.GetKey(UnityEngine.KeyCode.A)) && (rb.velocity[2] <= maxVelocity))
        {
            rb.AddForce(0, 0, sidewaysForce);
        }

        if ((Input.GetKey(UnityEngine.KeyCode.D)) && (rb.velocity[2] >= (-1 * maxVelocity)))
        {
            rb.AddForce(0, 0, -1 * sidewaysForce);
        }
    }
}
