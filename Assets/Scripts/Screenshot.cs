using UnityEngine;
using System.IO;

public class Screenshot : MonoBehaviour
{
    // Указываем клавишу, при нажатии которой будет создан принтскрин
    public KeyCode screenshotKey = KeyCode.N;

    // Указываем базовое название файла для сохранения
    public string filename = "screenshot.png";

    private void Update()
    {
        // Проверяем, была ли нажата указанная клавиша
        if (Input.GetKeyDown(screenshotKey))
        {
            // Считаем количество файлов с таким же названием
            int fileCount = 0;
            while (File.Exists(filename))
            {
                fileCount++;
                filename = "screenshot" + fileCount.ToString() + ".png";
            }

            // Создаем принтскрин и сохраняем его в указанном файле
            ScreenCapture.CaptureScreenshot(filename);
        }
    }
}

