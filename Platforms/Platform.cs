using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public GameObject player;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    public virtual void OnCollisionEnter(Collision other)
    {
        if (other.gameObject == player)
        {
            ThirdPersonCharacter.onPlatform = true;
            other.collider.transform.SetParent(transform.root);
        }
    }

    public virtual void OnCollisionExit(Collision other)
    {
        if (other.gameObject == player)
        {
            ThirdPersonCharacter.onPlatform = false;
            other.collider.transform.SetParent(null);

            if (player.transform.position.y <= 0.1)
            {
                Vector3 newPosition = player.transform.position;
                newPosition.y = 0;
                player.transform.position = newPosition;
            }
        }
    }
}
