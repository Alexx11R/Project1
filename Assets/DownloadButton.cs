using UnityEngine;
using System.IO;

public class DownloadButton : MonoBehaviour
{
    public string folderPath = "Assets/Files"; // Путь к папке с файлами внутри Unity

    public void DownloadFiles()
    {
        string dataPath = Application.dataPath; // Получаем путь к корневой папке проекта

        string folderFullPath = Path.Combine(dataPath, folderPath); // Получаем полный путь к папке с файлами

        string[] filePaths = Directory.GetFiles(folderFullPath); // Получаем все файлы в папке

        // Создаем временную папку на ПК пользователя, чтобы сохранить скачанные файлы
        string downloadPath = Path.Combine(Application.temporaryCachePath, folderPath);
        Directory.CreateDirectory(downloadPath);

        // Проходимся по каждому файлу и скачиваем его
        foreach (string filePath in filePaths)
        {
            string fileName = Path.GetFileName(filePath);
            string destinationPath = Path.Combine(downloadPath, fileName); // Путь, куда сохранить файл на ПК пользователя

            File.Copy(filePath, destinationPath, true); // Копируем файл в папку сохранения
        }

        Debug.Log("Файлы успешно скачаны на ПК пользователя.");
    }
}