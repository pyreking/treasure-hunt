using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : Platform
{
    private Vector3 initialPosition;
    private Quaternion initialRotation;
    private Rigidbody rb;
    public AudioSource audioS;
    public AudioClip fallingSound;
    private bool onGround;

    void Awake()
    {
        initialPosition = transform.position;
        initialRotation = transform.rotation;
        rb = GetComponent<Rigidbody>();
        onGround = false;
    }

    public override void OnCollisionEnter(Collision other)
    {
        if (other.gameObject == player)
        {
            ThirdPersonCharacter.onPlatform = true;
            other.collider.transform.SetParent(transform.root);
            StartCoroutine(CollapsePlatform());
        }
        else if (player.transform.parent != transform.root)
        {
            ResetPlatform();
            audioS.PlayOneShot(fallingSound);
        } else
        {
            onGround = true;
            audioS.PlayOneShot(fallingSound);
        }
    }

    public void OnCollisionStay(Collision other)
    {
        if (other.gameObject != player)
        {
            ResetPlatform();
        }
    }

    public override void OnCollisionExit(Collision other)
    {
        if (other.gameObject == player && onGround)
        {
            ResetPlatform();
            ThirdPersonCharacter.onPlatform = false;
            onGround = false;
        }
    }

    private void ResetPlatform()
    {
        StopCoroutine(CollapsePlatform());
        transform.position = initialPosition;
        transform.rotation = initialRotation;
        rb.isKinematic = true;
    }

    private IEnumerator CollapsePlatform()
    {
        yield return new WaitForSeconds(1f);
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.isKinematic = false;
    }
}
