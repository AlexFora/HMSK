using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{

	public int[] items = new int[] { 0, 5, 10, 15, 20, 25 }; //Список характеристик предметов
	public bool[] hasItems = new bool[] { true, true, false, false, false, false }; //Наличие предметов

	private int currItem = 0; //Текущий предмет
	public int defence = 0; //Защита

	public GameObject armorObject;
	public Sprite[] sprites;

	public void Equip(int index) //Метод надевания предмета
	{
		if (hasItems[index]) //Если такой предмет есть
		{
			currItem = index;
			defence = items[currItem];
			armorObject.GetComponent<SpriteRenderer>().sprite = sprites[currItem]; //Изменение спрайта 
		}
	}

	public void AddItem(int index)
	{
		hasItems[index] = true; //Добавление предмета при подборе
	}
}
