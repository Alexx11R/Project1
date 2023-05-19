using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainServer : MonoBehaviour
{
    public string url = "https://ya.ru/";

    public void Login()
    {
        WWWForm form = new WWWForm();
        form.AddField("command", "login");
        form.AddField("login", "");
        form.AddField("pass", "");
        WWW www = new WWW(url, form);
        StartCoroutine(WaitForRequest(www));
    }

    private IEnumerator WaitForRequest(WWW www)
    {
        yield return www;

        if (www.text.Length > 0) 
        {
            Debug.Log("Сервер ответил:" + www.text);
        }
        else Debug.Log("Нет ответа!");
    }

    void Start()
    {
        Login(); 
    }

    
}
