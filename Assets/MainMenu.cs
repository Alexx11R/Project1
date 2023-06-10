using UnityEngine;
using System.Collections;

public class FileLoader : MonoBehaviour
{
    public string fileName; // ��� �����, ������� �� ������ ���������

    public void LoadFile()
    {
        StartCoroutine(LoadFileFromStreamingAssets(fileName));
    }

    IEnumerator LoadFileFromStreamingAssets(string fileName)
    {
        string filePath = System.IO.Path.Combine(Application.streamingAssetsPath, fileName);

        if (filePath.Contains("://"))
        {
            // ���� ���� ��������� ������ ������, ��������� ��� ����������
            var www = new UnityEngine.Networking.UnityWebRequest(filePath);
            www.downloadHandler = new UnityEngine.Networking.DownloadHandlerBuffer();
            yield return www.SendWebRequest();
            string fileContents = www.downloadHandler.text;
            // ��������� ����������� �����
        }
        else
        {
            // ���� ���� ��������� � ��������� �������� �������, ��������� ��� ���������
            string fileContents = System.IO.File.ReadAllText(filePath);
            // ��������� ����������� �����
        }
    }
}