using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadMoveScript : MonoBehaviour
{
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(new Vector3(0, 0, 30f));
            // transform.position = transform.position + new Vector3(0, 0, 0.2f);
        }
    }
}
