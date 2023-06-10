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
    public string login;
    public string password;
    public string surname;
    public string name;
    public string patronymic;
    public string rights;
   

    public Player()
    {

    }

    public Player(int _id, string _login, string _password, string _surname, string _name, string _patronymic, string _rights)                 
    {
        id = _id;
        login = _login;
        password = _password;
        surname = _surname;
        name = _name;
        patronymic = _patronymic;
        rights = _rights;
    }

    public void SetLogin(string log) => login = log;
    public void SetPassword(string pass) => password = pass;
    public void SetSurname(string sur) => surname = sur;
    public void SetName(string nam) => name = nam;
    public void SetPatronymic(string patr) => patronymic = patr;
    public void SetRights(string rigt) => rights = rigt;
}

public class WebManager : MonoBehaviour
{
    public static UserData userData = new UserData();

    [SerializeField] private string targetURL;
    [SerializeField] private UnityEvent OnLogged, OnRegistered;

    public enum RequestType
    {
        logging, register, save, delete
    }

    public string GetUserData(UserData data)
    {
        return JsonUtility.ToJson(data);
    }

    public UserData SetUserData(string data)
    {
        print(data);//

        CanvasInteraction.rights_data = data.Contains("rights\":\"admin");
        print(CanvasInteraction.rights_data);//

        return JsonUtility.FromJson<UserData>(data);
    }

    private void Start()
    {
        userData.error = new Error() { errorText = "text", isError = true };
        userData.playerData = new Player(0, "Login", "Password", "Surname", "Name", "Patronymic", "New Rights");
    }

    public void Login(string login, string password)
    {
        StopAllCoroutines();
        Logging(login, password);
    }

    public void Registration(string login, string password1, string password2, string surname, string name, string patronymic, string rights)
    {
        StopAllCoroutines();
        Registering(login, password1, password2, surname, name, patronymic, rights);
    }

    public void SaveData(int id, string login, string password, string surname, string name, string patronymic, string rights)
    {
        StopAllCoroutines();
        SaveProgress(id, login, password, surname, name, patronymic, rights);
    }

    public void DeleteData(int id)
    {
        StopAllCoroutines();
        DeleteProgress(id);
    }

    public void Logging(string login, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("type", RequestType.logging.ToString());
        form.AddField("login", login);
        form.AddField("password", password);
        StartCoroutine(SendData(form, RequestType.logging));
    }

    public void Registering(string login, string password1, string password2, string surname, string name, string patronymic, string rights)
    {
        WWWForm form = new WWWForm();
        form.AddField("type", RequestType.register.ToString());
        form.AddField("login", login);
        form.AddField("password1", password1);
        form.AddField("password2", password2);
        form.AddField("surname", surname);
        form.AddField("name", name);
        form.AddField("patronymic", patronymic);
        form.AddField("rights", rights);
        StartCoroutine(SendData(form, RequestType.register));
    }

    public void SaveProgress(int id, string login, string password, string surname, string name, string patronymic, string rights)
    {
        WWWForm form = new WWWForm();
        form.AddField("type", RequestType.save.ToString());
        form.AddField("id", id);
        form.AddField("login", login);
        form.AddField("password", password);
        form.AddField("surname", surname);
        form.AddField("name", name);
        form.AddField("patronymic", patronymic);
        form.AddField("rights", rights);
        StartCoroutine(SendData(form, RequestType.save));
    }

    public void DeleteProgress(int id)
    {
        WWWForm form = new WWWForm();
        form.AddField("type", RequestType.delete.ToString());
        form.AddField("id", id);
        StartCoroutine(SendData(form, RequestType.delete));
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
                    if (type != RequestType.save && type != RequestType.delete)
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


