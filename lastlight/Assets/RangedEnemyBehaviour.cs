using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemyBehaviour : MonoBehaviour
{
    GameObject player;
    Rigidbody enemy;
    public int argoDistance = 30;
    public GameObject bullet;//set in inspector
    bool fired;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        enemy = GetComponent<Rigidbody>();
        fired = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if ( (fired == false) && (Mathf.Abs(player.transform.position.x - transform.position.x) <= argoDistance) )
        {
            fired = true;
            Chrono.Instance.After(3,() =>
             {
                 GameObject clone;
                 clone = Instantiate(bullet, enemy.transform.position, Quaternion.identity);
                 clone.transform.LookAt(player.transform);
                 clone.transform.position = enemy.transform.position;
                 fired = false;
             });
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == player)
        {
            player.GetComponent<Player>().Damage(20);
            Destroy(gameObject);
        }
    }
}
