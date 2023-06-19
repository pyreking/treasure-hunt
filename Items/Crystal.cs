using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crystal : MonoBehaviour
{
    public string treasurePieceName;
    public AudioClip itemFound;
    public AudioSource source;
    public Text treasureCounter;

    private Renderer thisRenderer = null;
    private Collider thisCollider = null;

    void Awake()
    {
        thisRenderer = GetComponent<Renderer>();
        thisCollider = GetComponent<Collider>();
    }

    void Start()
    {
        thisRenderer.enabled = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        if (!gameObject.activeSelf) return;

        thisCollider.enabled = false;
        thisRenderer.enabled = false;

        if (ItemManager.GetItemStatus(treasurePieceName) == Item.ITEMSTATUS.HIDDEN)
        {
            ItemManager.SetItemStatus(treasurePieceName, Item.ITEMSTATUS.FOUND);
            treasureCounter.text = ItemManager.GetTreasureText();

            if (source != null && itemFound != null)
            {
                source.PlayOneShot(itemFound);
            }

            if (ItemManager.GetNumTreasuresFound() == ItemManager.GetNumTreasures())
            {
                WinMenu.isActive = true;
            }
        }
    }
}
