using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaPlatform : Platform
{
    public int maxDamage = 10;

    public void OnCollisionStay(Collision other)
    {
        if (other.gameObject == player)
        {
            Health PlayerHealth = player.GetComponent<Health>();
            PlayerHealth.HealthPoints -= maxDamage * Time.deltaTime;
        }
    }
}
