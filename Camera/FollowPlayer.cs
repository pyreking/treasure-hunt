using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;
    private Vector3 newPosition;

    void Start()
    {
        if (player != null && !PauseMenu.isPaused)
        {
            offset.x = transform.position.x - player.transform.position.x;
            offset.y = transform.position.y - player.transform.position.y;
            offset.z = transform.position.z - player.transform.position.z;
            newPosition = transform.position;
            transform.LookAt(player.transform.position);
        }

    }
    void LateUpdate()
    {
        if (player != null && !PauseMenu.isPaused)
        {
            newPosition.x = player.transform.position.x + offset.x;
            newPosition.y = player.transform.position.y + offset.y;
            newPosition.z = player.transform.position.z + offset.z;
            transform.position = newPosition;
            offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * 4f, Vector3.up) * offset;
            transform.LookAt(player.transform.position + new Vector3(0,1,0));
        }
    }
}