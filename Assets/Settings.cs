using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{
    public void OpenSettings(int numberScenes)
    {
        SceneManager.LoadScene(numberScenes);
    }

    public void ExitSettings(int numberScenes)
    {
        SceneManager.LoadScene(numberScenes);
    }
}
