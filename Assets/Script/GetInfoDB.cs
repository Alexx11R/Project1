using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

public class GetInfoDB : MonoBehaviour
{
    public GameObject userInfoContainer;
    public GameObject userInfoTemplate;

    [SerializeField] private TMP_InputField idInput;

    string[] str_data_id = { "" };
    string[] str_data_login = { "" };
    string[] str_data_password = { "" };
    string[] str_data_surname = { "" };
    string[] str_data_name = { "" };
    string[] str_data_patronymic = { "" };
    string[] str_data_rights = { "" };

    List<string> list_id = new List<string>();
    List<string> list_login = new List<string>();
    List<string> list_password = new List<string>();
    List<string> list_surname = new List<string>();
    List<string> list_name = new List<string>();
    List<string> list_patronymic = new List<string>();
    List<string> list_rights = new List<string>();

    public static string load_id = "";
    public static string load_login = "";
    public static string load_password = "";
    public static string load_surname = "";
    public static string load_name = "";
    public static string load_patronymic = "";
    public static string load_rights = "";

    void Start()
    {
        StartCoroutine(GetRequest("http://game.loc/load_inf.php"));
    }

    public void LoadData() //выбор пользовател€ по id
    {
        for (int j = 0; j < str_data_id.Length; j++)
        {
            if (str_data_id[j] == idInput.text)
            {
                load_id = str_data_id[j];
                load_login = str_data_login[j];
                load_password = str_data_password[j];
                load_surname = str_data_surname[j];
                load_name = str_data_name[j];
                load_patronymic = str_data_patronymic[j];
                load_rights = str_data_rights[j];
            }
        }

        if (load_id != "")
        {
            DeleteInDB.data_id_del = load_id;

            SaveInDB.data_id = load_id;
            SaveInDB.data_login = load_login;
            SaveInDB.data_password = load_password;
            SaveInDB.data_surname = load_surname;
            SaveInDB.data_name = load_name;
            SaveInDB.data_patronymic = load_patronymic;
            SaveInDB.data_rights = load_rights;
           
            load_id = "";
            load_login = "";
            load_password = "";
            load_surname = "";
            load_name = "";
            load_patronymic = "";
            load_rights = "";
        }
        else print("ƒанный id не найден!");
    }

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {  
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:

                    string rawresponse = webRequest.downloadHandler.text;

                    string[] users = rawresponse.Split("*");

                    for (int i = 0; i < users.Length; i++)
                    {
                        if (users[i] != "")
                        {
                            string[] user_info = users[i].Split(',');
                            Debug.Log("Id: " + user_info[0] + " Login: " + user_info[1] + " Password: " + user_info[2] + " Surname: " + user_info[3] + " Name: " + user_info[4] + " Patronymic: " + user_info[5] + " Rights: " + user_info[6]);

                            GameObject inform = (GameObject)Instantiate(userInfoTemplate);
                            inform.transform.SetParent(userInfoContainer.transform);

                            inform.GetComponent<UserInfoDB>().id.text = user_info[0];
                            inform.GetComponent<UserInfoDB>().login.text = user_info[1];
                            inform.GetComponent<UserInfoDB>().password.text = user_info[2];
                            inform.GetComponent<UserInfoDB>().surname.text = user_info[3];
                            inform.GetComponent<UserInfoDB>().name.text = user_info[4];
                            inform.GetComponent<UserInfoDB>().patronymic.text = user_info[5];
                            inform.GetComponent<UserInfoDB>().rights.text = user_info[6];

                            list_id.Add(user_info[0]);
                            list_login.Add(user_info[1]);
                            list_password.Add(user_info[2]);
                            list_surname.Add(user_info[3]);
                            list_name.Add(user_info[4]);
                            list_patronymic.Add(user_info[5]);
                            list_rights.Add(user_info[6]);

                            str_data_id = list_id.ToArray();
                            str_data_login = list_login.ToArray();
                            str_data_password = list_password.ToArray();
                            str_data_surname = list_surname.ToArray();
                            str_data_name = list_name.ToArray();
                            str_data_patronymic = list_patronymic.ToArray();
                            str_data_rights = list_rights.ToArray();
                            
                        }
                    }
                    break;
            }
            
            
        }
    }
}
