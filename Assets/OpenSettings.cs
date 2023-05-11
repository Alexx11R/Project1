using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenSettings : MonoBehaviour
{
    public void Open(int numberScenes)
    {
        SceneManager.LoadScene(numberScenes);
    }

}
