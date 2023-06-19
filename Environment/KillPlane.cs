using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlane : MonoBehaviour
{
    private GameObject player;
    private Animator m_Animator;
    private bool wasJumping = false;

    void Update()
    {
        if (m_Animator != null && m_Animator.GetBool("OnGround") == false)
        {
            wasJumping = true;
        }
    }

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
        m_Animator = player.GetComponent<Animator>();
    }

    private void OnCollisionStay(Collision collision)
    {
        if (player == collision.gameObject)
        {
            if (wasJumping)
            {
                wasJumping = false;
            } else
            {
                Destroy(collision.gameObject);
                GameOverMenu.gameOver = true;
            }
        }
    }
}
