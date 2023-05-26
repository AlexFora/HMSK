using UnityEngine;

public class FullscreenHandler : MonoBehaviour
{
    private bool isFullscreen = false;

    void Start()
    {
        // ������������� �� ������� ��������� ���������� ������
        Screen.fullScreenMode = FullScreenMode.Windowed;
        Screen.SetResolution(1280, 720, false);
        Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
    }

    void Update()
    {
        // ���������, ������ �� ������� F11 (��� ����� ������ ������� �� ������ ������)
        if (Input.GetKeyDown(KeyCode.F11))
        {
            ToggleFullscreen();
        }
    }

    void ToggleFullscreen()
    {
        isFullscreen = !isFullscreen;

        // ������������� ������������� �����
        Screen.fullScreen = isFullscreen;
    }
}

