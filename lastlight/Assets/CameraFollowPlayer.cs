using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    [SerializeField] private Vector3 offset = new Vector3(0, 0, 0);//set in inspector
	private Transform playerTransform;

	void Start()
	{
		playerTransform = GameObject.FindWithTag("Player").transform;
	}

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPositionX = new Vector3(playerTransform.position.x, 0, 0);
        transform.position = playerPositionX + offset;
    }
}
