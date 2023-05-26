using UnityEngine;
using System.IO;

public class Screenshot : MonoBehaviour
{
    // ��������� �������, ��� ������� ������� ����� ������ ����������
    public KeyCode screenshotKey = KeyCode.N;

    // ��������� ������� �������� ����� ��� ����������
    public string filename = "screenshot.png";

    private void Update()
    {
        // ���������, ���� �� ������ ��������� �������
        if (Input.GetKeyDown(screenshotKey))
        {
            // ������� ���������� ������ � ����� �� ���������
            int fileCount = 0;
            while (File.Exists(filename))
            {
                fileCount++;
                filename = "screenshot" + fileCount.ToString() + ".png";
            }

            // ������� ���������� � ��������� ��� � ��������� �����
            ScreenCapture.CaptureScreenshot(filename);
        }
    }
}

