using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlane : MonoBehaviour
{
    public int maxDamage = 5;

    private void OnTriggerEnter(Collider collider)
    {
        ThirdPersonCharacter.insideHurtPlane = true;
    }

    private void OnTriggerStay(Collider collider)
    {
        if (GameObject.FindWithTag("Player") == collider.gameObject && !ThirdPersonCharacter.onPlatform)
        {
            Health PlayerHealth = collider.gameObject.GetComponent<Health>();
            PlayerHealth.HealthPoints -= maxDamage * Time.deltaTime;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        ThirdPersonCharacter.insideHurtPlane = false;
    }
}
