using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DBLoginMenu : MonoBehaviour
{
    [System.Serializable]
    public class MenuLogin
    {
        public TMP_Text login, password;
    }

    public MenuLogin loginWindow;
  
    [SerializeField] private WebManager webManager;

    int numberScenes;

    public void Login()
    {
        webManager.Login(loginWindow.login.text, loginWindow.password.text);
    }

    public void Enter(int numberScenes)
    {
        SceneManager.LoadScene(numberScenes);
    }
}
