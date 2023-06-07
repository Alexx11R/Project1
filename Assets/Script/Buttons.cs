using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public GameObject img;

    public void OnMove()
    {
        img.transform.localScale = new Vector2(1.5f, 1.5f);
    }
    public void OnExit()
    {
        img.transform.localScale = new Vector2(1f, 1f);
    }

    public void ChangeScene(int numberScenes)
    {
        SceneManager.LoadScene(numberScenes);
    }
}
