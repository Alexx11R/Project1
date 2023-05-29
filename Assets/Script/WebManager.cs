using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;

[System.Serializable]
public class UserData
{
    public Player playerData;
    public Error error;
}

[System.Serializable]
public class Error
{
    public string errorText;
    public bool isError;
}

[System.Serializable]
public class Player
{
    public int id;
    public string rights;

    public Player()
    {

    }

    public Player(string _rights)                 
    {
        rights = _rights;
    }

    public void SetRights(string rigt) => rights = rigt;
}

public class WebManager : MonoBehaviour
{
    public static UserData userData = new UserData();

    

    [SerializeField] private string targetURL;

    [SerializeField] private UnityEvent OnLogged, OnRegistered;


    public enum RequestType
    {
        logging, register, save
    }

    public string GetUserData(UserData data)
    {
        return JsonUtility.ToJson(data);
    }

    public UserData SetUserData(string data)
    {
        print(data);//

        CanvasInteraction.rights_data = data.Contains("\"rights\":\"admin\"");
        print(CanvasInteraction.rights_data);//

        return JsonUtility.FromJson<UserData>(data);
    }

    private void Start()
    {
        userData.error = new Error() { errorText = "text", isError = true };
        userData.playerData = new Player("New User");
    }

    public void Login(string login, string password)
    {
        StopAllCoroutines();
        Logging(login, password);
    }

    public void Registration(string login, string password1, string password2, string rights)
    {
        StopAllCoroutines();
        Registering(login, password1, password2, rights);
    }

    public void SaveData(int id, string rights)
    {
        StopAllCoroutines();
        SaveProgress(id, rights);
    }

    public void Logging(string login, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("type", RequestType.logging.ToString());
        form.AddField("login", login);
        form.AddField("password", password);
        StartCoroutine(SendData(form, RequestType.logging));
    }

    public void Registering(string login, string password1, string password2, string rights)
    {
        WWWForm form = new WWWForm();
        form.AddField("type", RequestType.register.ToString());
        form.AddField("login", login);
        form.AddField("password1", password1);
        form.AddField("password2", password2);
        form.AddField("rights", rights);
        StartCoroutine(SendData(form, RequestType.register));
    }

    public void SaveProgress(int id, string rights)
    {
        WWWForm form = new WWWForm();
        form.AddField("type", RequestType.save.ToString());
        form.AddField("id", id);
        form.AddField("rights", rights);
        StartCoroutine(SendData(form, RequestType.save));
    }

    IEnumerator SendData(WWWForm form, RequestType type)
    {
        using (UnityWebRequest www = UnityWebRequest.Post(targetURL, form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                var data = SetUserData(www.downloadHandler.text);
                if (!data.error.isError)
                {
                    if (type != RequestType.save)
                    {
                        userData = data;
                        if (type == RequestType.logging)
                        {
                            OnLogged.Invoke();
                        }
                        else
                        {
                            OnRegistered.Invoke();
                        }
                    }
                }
            }
        }
    }
}


