using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public int argoDistance = 10;
    GameObject player;
    Rigidbody enemy;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        enemy = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.x - player.transform.position.x <= argoDistance)
        {
            if (transform.position.z > player.transform.position.z) 
            {
                enemy.AddForce(0, 0, -50f);
            }
            if (transform.position.z < player.transform.position.z)
            {
                enemy.AddForce(0, 0, 50f);
            }
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

