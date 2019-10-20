using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] AudioClip hitSound;
    public int argoDistance = 10;
    GameObject player;
    Rigidbody enemy;
    bool exactTracking;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        enemy = GetComponent<Rigidbody>();
        exactTracking = UnityEngine.Random.Range(0, 2) == 1;
    }

    void FixedUpdate()
    {
        if (transform.position.x - player.transform.position.x <= argoDistance)
        {
            if (exactTracking)
            {
                enemy.transform.position = new Vector3(
                    enemy.transform.position.x,
                    enemy.transform.position.y,
                    player.transform.position.z
                );
            }
            else
            {
                if (transform.position.z > player.transform.position.z)
                {
                    enemy.AddForce(0, 0, -200f);
                }
                if (transform.position.z < player.transform.position.z)
                {
                    enemy.AddForce(0, 0, 200f);
                }
            }

        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == player)
        {
            player.GetComponent<Player>().Damage(20);
            player.GetComponent<AudioSource>().PlayOneShot(hitSound);
            Destroy(gameObject);
        }
    }
}

