using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;

    public float forwardForce = 200f;
    public float sidewaysForce = 150f;
    public float upwardForce = 1000f;
    public float maxVelocity = 10f;
    public int depth = 10;

    bool justSpawned = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        Chrono.Instance.After(1, () =>
        {
            justSpawned = false;
        });
    }

    void FixedUpdate()
    {
        ProcessUnlimitedMovement();

        if (!justSpawned)
        {
            AttemptHardFix();
        }
    }

    void AttemptHardFix()
    {
        if (rb.velocity.magnitude < 1)
        {
            rb.AddForce(0, 1 * upwardForce, 0);
        }
    }

    void ProcessUnlimitedMovement()
    {
        rb.AddForce(forwardForce, 0, 0);

        // Ground is at y=0
        if ((Input.GetKey(UnityEngine.KeyCode.Space)) && rb.position[1] < 0.1)
        {
            rb.AddForce(0, 5 * upwardForce, 0);
        }

        if ((Input.GetKey(UnityEngine.KeyCode.A)))
        {
            rb.AddForce(0, 0, sidewaysForce);
        }

        if ((Input.GetKey(UnityEngine.KeyCode.D)))
        {
            rb.AddForce(0, 0, -1 * sidewaysForce);
        }
    }

    void ProcessMaxVelocityMovement()
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
