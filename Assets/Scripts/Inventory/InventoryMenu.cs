using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryMenu : MonoBehaviour
{



	[SerializeField] private GameObject _player;

	private Items items;

	public Transform inventorySlots;

	private Slot[] slots;

	void Start()
	{

		items = _player.GetComponent<Items>();
		slots = inventorySlots.GetComponentsInChildren<Slot>();
	}

    public void Update()
    {
		UpdateUI();
	}

    void UpdateUI()
	{
		for (int i = 0; i < slots.Length; i++) //�������� ���� ���������
		{
			bool active = false;
			if (items.hasItems[i]) //���� ����� ������� ���� � ������������, �� �� ����� ������������ � �����
			{
				active = true;
			}

			slots[i].UpdateSlot(active);
		}
	}
}
