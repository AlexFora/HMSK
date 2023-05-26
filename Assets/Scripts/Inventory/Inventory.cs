using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;


public class Inventory : MonoBehaviour
{
    public Canvas inventoryCanvas;
    //public Texture2D cursorTexture;
    //public CursorMode cursorMode = CursorMode.Auto;
    //public Vector2 hotSpot = Vector2.zero;
    private bool isInventoryActive = false;
    public ÑursorManager cursorManager;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            isInventoryActive = !isInventoryActive;
            //if (cursorManager.gameObject.activeSelf)
            //{
            //    cursorManager.HideCursor();
            //}
            inventoryCanvas.gameObject.SetActive(isInventoryActive);
            //Cursor.visible = isInventoryActive;
            //Cursor.lockState = CursorLockMode.None;

            if (isInventoryActive == true || inventoryCanvas.gameObject.activeSelf == true)
            {
                //Vector2 hotSpot = new Vector2(cursorTexture.width / 2, cursorTexture.height / 2);
                //Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
                //Cursor.visible = true;
                StopCameraRotation(true);
            }
            else
            {
                //Cursor.SetCursor(null, Vector2.zero, cursorMode);
                StopCameraRotation(false);
                //Cursor.visible = false;
            }
        }


        if (inventoryCanvas.gameObject.activeSelf == false)
        {
            StopCameraRotation(false);
            //cursorManager.HideCursor();
            //Cursor.visible = false;
        }
    }


    private void StopCameraRotation(bool On)
    {

        bool _on = On;


        Camera mainCamera = GameObject.FindGameObjectWithTag("MainCamera")?.GetComponent<Camera>();
        FirstPersonLook firstPersonLook = mainCamera?.GetComponent<FirstPersonLook>();

        if (firstPersonLook != null)
        {
            if(_on == true)
            {
                firstPersonLook.enabled = false;
            }
            else
            {
                firstPersonLook.enabled = true;
            }
        }
    }
}


[System.Serializable]
public class Item
{
    public string name;
    public Sprite icon;
    public GameObject prefab;
}

