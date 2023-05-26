using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelliInter : MonoBehaviour
{
    public KeyCode interactKey = KeyCode.G;
    public GameObject Car;
    public GameObject carObject;
    public GameObject carMeshObject;
    public GameObject playerPrefab;

    public bool isPlayerNearCar = false;
    private List<GameObject> playerObjects = new List<GameObject>();
    public bool isCarActive = false;

    private void Start()
    {
        // �������� ����� FindPlayersWithTag ����� 2 ������� ����� ������� ����
        Invoke("FindPlayersWithTag", 2f);
    }

    private void FindPlayersWithTag()
    {
        // ����� ��� ������� ������� � ����� "Player"
        GameObject[] allObjects = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject obj in allObjects)
        {
            playerObjects.Add(obj);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Helli"))
        {
            isPlayerNearCar = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Helli"))
        {
            isPlayerNearCar = false;
        }
    }

    private void Update()
    {
        Car.transform.position = carObject.transform.position;

        // ���� ������ ������� �������� ������, ����������� ��� ��� ����� ������� � ����� "Player"
        if (playerObjects.Count == 0)
        {
            FindPlayersWithTag();
        }

        if (isPlayerNearCar && Input.GetKeyDown(interactKey))
        {
            if (!isCarActive)
            {
                // �������� ������� ������������� ������� �� ������� ��������� �������
                transform.position = carObject.transform.position;


                // ��������� ��� ������� ������� � ����� "Player"
                foreach (GameObject obj in playerObjects)
                {
                    obj.SetActive(false);
                }

                // �������� ������� ������ ������ � ��������� ��� ������
                carObject.SetActive(true);
                carMeshObject.SetActive(false);
                isCarActive = true;
            }
            else
            {
                // �������� ��� ������� ������� � ����� "Player"
                foreach (GameObject obj in playerObjects)
                {
                    obj.SetActive(true);
                    obj.transform.position = carObject.transform.position + new Vector3(0, 1, 0);
                }

                // ��������� ������� ������ ������ � �������� ��� ������
                carObject.SetActive(false);
                carMeshObject.SetActive(true);
                carMeshObject.transform.position = carObject.transform.position;
                isCarActive = false;
            }
        }
    }
}
