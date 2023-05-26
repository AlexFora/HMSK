using UnityEngine;

public class FullscreenHandler : MonoBehaviour
{
    private bool isFullscreen = false;

    void Start()
    {
        // Подписываемся на событие изменения разрешения экрана
        Screen.fullScreenMode = FullScreenMode.Windowed;
        Screen.SetResolution(1280, 720, false);
        Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
    }

    void Update()
    {
        // Проверяем, нажата ли клавиша F11 (или любая другая клавиша по вашему выбору)
        if (Input.GetKeyDown(KeyCode.F11))
        {
            ToggleFullscreen();
        }
    }

    void ToggleFullscreen()
    {
        isFullscreen = !isFullscreen;

        // Устанавливаем полноэкранный режим
        Screen.fullScreen = isFullscreen;
    }
}

