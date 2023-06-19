using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustCloud : MonoBehaviour
{
    public GameObject dustCloud;
    public GameObject dustCloudClone;

    private Animator m_animator;
    private bool instantiated = false;

    void Awake()
    {
        m_animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (m_animator.GetBool("Digging") == true)
        {
            if (!instantiated)
            {
                instantiated = true;
                StartCoroutine(CreateCloud());
            }
        } else if (instantiated)
        {
            instantiated = false;
            Destroy(dustCloudClone);
        }
    }

    private IEnumerator CreateCloud()
    {
        yield return new WaitForSeconds(1.3f);
        dustCloudClone = Instantiate(dustCloud, transform.position, dustCloud.transform.rotation);
    }
}
