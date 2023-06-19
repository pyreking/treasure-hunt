using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnTouchPlatform : Platform
{
    private Animator platformAnimator;

    void Awake()
    {
        platformAnimator = GetComponentInParent<Animator>();
    }

    public override void OnCollisionEnter(Collision other)
    {
        if (other.gameObject == player)
        {
            ThirdPersonCharacter.onPlatform = true;
            other.collider.transform.SetParent(transform.root);
            platformAnimator.SetBool("Move", true);
        }
    }
}
