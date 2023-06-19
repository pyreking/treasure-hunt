using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    public enum ITEMSTATUS { HIDDEN = 0, FOUND = 1 };
    public ITEMSTATUS Status = ITEMSTATUS.HIDDEN;
    public string itemName = string.Empty;
}

public class ItemManager : MonoBehaviour
{
	public Item[] Items;
	private int treasuresFound = 0;
	private static ItemManager SingletonInstance = null;
	public static ItemManager ThisInstance
	{
		get
		{
			if (SingletonInstance == null)
			{
				GameObject ItemObject = new GameObject("Default");
				SingletonInstance = ItemObject.AddComponent<ItemManager>();
			}
			return SingletonInstance;
		}
	}

	void Awake()
	{
		if (SingletonInstance)
		{
			DestroyImmediate(gameObject);
			return;
		}

		SingletonInstance = this;
		DontDestroyOnLoad(gameObject);
	}

	public static Item.ITEMSTATUS GetItemStatus(string itemName)
	{
		foreach (Item item in ThisInstance.Items)
		{
			if (item.itemName.Equals(itemName))
				return item.Status;
		}

		return Item.ITEMSTATUS.HIDDEN;
	}

	public static void SetItemStatus(string itemName, Item.ITEMSTATUS newStatus)
	{
		foreach (Item item in ThisInstance.Items)
		{
			if (item.itemName.Equals(itemName))
			{
				if (newStatus == Item.ITEMSTATUS.FOUND)
                {
					ThisInstance.treasuresFound++;
                }
				item.Status = newStatus;
				return;
			}
		}
	}

	public static string GetTreasureText()
	{
		return ThisInstance.treasuresFound.ToString() + "/" + ThisInstance.Items.Length.ToString();
	}

	public static int GetNumTreasures()
    {
		return ThisInstance.Items.Length;
	}

	public static int GetNumTreasuresFound()
	{
		return ThisInstance.treasuresFound;
	}

	public static void Reset()
	{
		if (ThisInstance == null) return;

		foreach (Item item in ThisInstance.Items)
			item.Status = Item.ITEMSTATUS.HIDDEN;

		ThisInstance.treasuresFound = 0;
	}
}