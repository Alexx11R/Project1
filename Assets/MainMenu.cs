using UnityEngine;
using System.Collections;

public class FileLoader : MonoBehaviour
{
    public string fileName; // Имя файла, который вы хотите загрузить

    public void LoadFile()
    {
        StartCoroutine(LoadFileFromStreamingAssets(fileName));
    }

    IEnumerator LoadFileFromStreamingAssets(string fileName)
    {
        string filePath = System.IO.Path.Combine(Application.streamingAssetsPath, fileName);

        if (filePath.Contains("://"))
        {
            // Если файл находится внутри архива, загружаем его асинхронно
            var www = new UnityEngine.Networking.UnityWebRequest(filePath);
            www.downloadHandler = new UnityEngine.Networking.DownloadHandlerBuffer();
            yield return www.SendWebRequest();
            string fileContents = www.downloadHandler.text;
            // Обработка содержимого файла
        }
        else
        {
            // Если файл находится в локальной файловой системе, загружаем его синхронно
            string fileContents = System.IO.File.ReadAllText(filePath);
            // Обработка содержимого файла
        }
    }
}