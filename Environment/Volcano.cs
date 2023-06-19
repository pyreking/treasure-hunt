using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Volcano : MonoBehaviour
{
    public int maxDamage = 10;
    private GameObject player;

    void Awake()
    {
        player = GameObject.FindWithTag("Player");
    }

    public void OnCollisionStay(Collision other)
    {
        if (other.gameObject == player)
        {
            Health PlayerHealth = player.GetComponent<Health>();
            PlayerHealth.HealthPoints -= maxDamage * Time.deltaTime;
            ThirdPersonCharacter.touchingVolcano = true;
        }
    }

    public void OnCollisionExit(Collision other)
    {
        if (other.gameObject == player)
        {
            ThirdPersonCharacter.touchingVolcano = false;
        }
    }
}
