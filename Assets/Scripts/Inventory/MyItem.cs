using UnityEngine;

public class MyItem : MonoBehaviour
{
	public int index = 0; //����� ��������, � ���� ���� ����� ����� 3 ���� �����, ������� ������ ����� ������� ������ ��� ������

	void OnTriggerEnter2D(Collider2D obj) //������ �� ������
	{
		if (obj.transform.tag == "Player")
		{
            obj.GetComponent<Items>().AddItem(index);//���� ������ �����, �� �� ������ ��������� �������
            Destroy(gameObject); //�������� ������� � �����
        }
	}
}
