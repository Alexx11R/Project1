using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitSettings : MonoBehaviour
{
    public void Exit(int numberScenes)
    {
        SceneManager.LoadScene(numberScenes);
    }
}
