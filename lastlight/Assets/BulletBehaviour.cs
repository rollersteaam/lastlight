using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 0.5f;
    public float forwardForce = 100f;
    GameObject player;
    Vector3 target;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindWithTag("Player");
        rb.transform.LookAt(player.transform);
      //rb.transform.position = GameObject.FindWithTag("Enemy").transform.position;
        target = new Vector3(player.transform.position.x,player.transform.position.y,player.transform.position.z);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.transform.position = Vector3.MoveTowards(transform.position, target, speed);
        if (transform.position == target)
        {
        Destroy(gameObject);//bullet has missed player
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == player)
        {
            player.GetComponent<Player>().Damage(10);
            Destroy(gameObject);
        }
        
    }
}
