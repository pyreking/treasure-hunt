using UnityEngine;
using UnityEngine.Audio;
public class PlayerAudio : MonoBehaviour
{
    public AudioMixer mixer;
    public AudioMixerSnapshot idleSnapshot;
    public AudioMixerSnapshot auxInSnapshot;

    public LayerMask treasureMask;

    bool treasureNear;
    public AudioSource audioS;
    public AudioClip[] steps;
    public AudioClip[] digging;

    private Animator m_Animator;
    private TerrainChecker checker;
    private bool wasJumping = false;

    private Vector3 lastPosition;

    void Awake()
    {
        m_Animator = GetComponent<Animator>();
        checker = new TerrainChecker();
    }

    public void Footsteps()
    {
        if (ThirdPersonCharacter.onPlatform)
        {
            audioS.PlayOneShot(steps[4]);
        } else
        {
            Terrain terrain = checker.GetCurrentTerrain(transform.position);

            if (terrain == null)
            {
                return;
            }

            string layerName = checker.GetLayerName(transform.position, terrain);

            switch (layerName)
            {
                case "Sand":
                    audioS.PlayOneShot(steps[0]);
                    break;
                case "Lava":
                    audioS.PlayOneShot(steps[1]);
                    break;
                case "Grass":
                    audioS.PlayOneShot(steps[2]);
                    break;
                case "Dirt":
                    audioS.PlayOneShot(steps[3]);
                    break;
                case "GrassWithRocks":
                    audioS.PlayOneShot(steps[2]);
                    break;
            }
        }
    }

    public void Digging()
    {
        if (!ThirdPersonCharacter.onPlatform && !ThirdPersonCharacter.insideHurtPlane)
        {
            audioS.PlayOneShot(digging[0]);
        }
    }

    private bool isJumpingOntoPlatform()
    {
        RaycastHit[] hits;

        hits = Physics.RaycastAll(transform.position, -transform.up, 100.0F);

        bool jumpedOntoPlatform = false;

        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i].transform.name == "Platform")
            {
                jumpedOntoPlatform = true;
            }
        }

        return jumpedOntoPlatform;
    }

    public void Update()
    {
        if (m_Animator.GetBool("OnGround") == false)
        {
            wasJumping = true;
        } else if (wasJumping)
        {
            wasJumping = false;

            if (!isJumpingOntoPlatform())
            {
                Footsteps();
            } else
            {
                audioS.PlayOneShot(steps[4]);
            }
        }

        int radius = 20;
        RaycastHit[] hits = Physics.SphereCastAll(transform.position, radius, transform.forward, 0f, treasureMask);
        if (hits.Length > 0)
        {
            if (!treasureNear)
            {
                treasureNear = true;
                auxInSnapshot.TransitionTo(0.5f);
            } else
            {
                float distance = Vector3.Distance(transform.position, hits[0].transform.position);

                if (distance <= (radius / 3))
                {
                    mixer.SetFloat("Pitch", 2f);
                } else if (distance <= (radius / 2))
                {
                    mixer.SetFloat("Pitch", 1.5f);
                } else
                {
                    mixer.SetFloat("Pitch", 1f);
                }
            }
        }
        else
        {
            if (treasureNear)
            {
                treasureNear = false;
                idleSnapshot.TransitionTo(0.5f);
            }
        }
    }
}