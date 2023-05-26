using UnityEngine;

public class СursorManager : MonoBehaviour
{
    public Texture2D cursorTexture;
    public int cursorSize = 32;

    void Update()
    {
        Cursor.SetCursor(cursorTexture, new Vector2( cursorSize, cursorSize), CursorMode.Auto);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    private void OnEnable()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Vector3 mousePos = new Vector3(Screen.width / 2, Screen.height / 2, 0f);
        Cursor.SetCursor(null, mousePos, CursorMode.Auto);
    }

    public void HideCursor()
    {
        Cursor.visible = false;
    }

    private void OnDisable()
    {
        HideCursor();
    }
}