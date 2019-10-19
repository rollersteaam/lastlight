using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public Transform player;//set in inspector
    public Vector3 offset;//set in inspector

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPositionX = new Vector3(player.position.x, 0, 0);
        transform.position = playerPositionX + offset;
    }
}
