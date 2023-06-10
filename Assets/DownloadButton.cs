using UnityEngine;
using System.IO;

public class DownloadButton : MonoBehaviour
{
    public string folderPath = "Assets/Files"; // ���� � ����� � ������� ������ Unity

    public void DownloadFiles()
    {
        string dataPath = Application.dataPath; // �������� ���� � �������� ����� �������

        string folderFullPath = Path.Combine(dataPath, folderPath); // �������� ������ ���� � ����� � �������

        string[] filePaths = Directory.GetFiles(folderFullPath); // �������� ��� ����� � �����

        // ������� ��������� ����� �� �� ������������, ����� ��������� ��������� �����
        string downloadPath = Path.Combine(Application.temporaryCachePath, folderPath);
        Directory.CreateDirectory(downloadPath);

        // ���������� �� ������� ����� � ��������� ���
        foreach (string filePath in filePaths)
        {
            string fileName = Path.GetFileName(filePath);
            string destinationPath = Path.Combine(downloadPath, fileName); // ����, ���� ��������� ���� �� �� ������������

            File.Copy(filePath, destinationPath, true); // �������� ���� � ����� ����������
        }

        Debug.Log("����� ������� ������� �� �� ������������.");
    }
}