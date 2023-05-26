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
        // Вызываем метод FindPlayersWithTag через 2 секунды после запуска игры
        Invoke("FindPlayersWithTag", 2f);
    }

    private void FindPlayersWithTag()
    {
        // Найти все игровые объекты с тегом "Player"
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

        // Если список игровых объектов пустой, попробовать еще раз найти объекты с тегом "Player"
        if (playerObjects.Count == 0)
        {
            FindPlayersWithTag();
        }

        if (isPlayerNearCar && Input.GetKeyDown(interactKey))
        {
            if (!isCarActive)
            {
                // Обновить позицию родительского объекта на позицию дочернего объекта
                transform.position = carObject.transform.position;


                // Отключить все игровые объекты с тегом "Player"
                foreach (GameObject obj in playerObjects)
                {
                    obj.SetActive(false);
                }

                // Включить игровой объект машины и отключить меш машины
                carObject.SetActive(true);
                carMeshObject.SetActive(false);
                isCarActive = true;
            }
            else
            {
                // Включить все игровые объекты с тегом "Player"
                foreach (GameObject obj in playerObjects)
                {
                    obj.SetActive(true);
                    obj.transform.position = carObject.transform.position + new Vector3(0, 1, 0);
                }

                // Отключить игровой объект машины и включить меш машины
                carObject.SetActive(false);
                carMeshObject.SetActive(true);
                carMeshObject.transform.position = carObject.transform.position;
                isCarActive = false;
            }
        }
    }
}
