using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DownloadMenu: MonoBehaviour
{
    private void Start()
    {
        // ���������� ��������� ������� ����
        Cursor.visible = true;
    }

    public void Download(int numberScenes)
    {
        SceneManager.LoadScene(numberScenes);
    }
  
}