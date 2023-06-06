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

    string[] str_data_id = { "" };//
    string[] str_data_rights = { "" };//
    List<string> list_id = new List<string>();//
    List<string> list_rights = new List<string>();//

    public static string load_id = "";
    public static string load_rights = "";

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetRequest("http://game.loc/load_inf.php"));
    }

    // Update is called once per frame
    public void LoadData() //выбор пользователя по id
    {
        for (int j = 0; j < str_data_id.Length; j++)
        {
            if (str_data_id[j] == idInput.text)
            {
                load_id = str_data_id[j];
                load_rights = str_data_rights[j];
            }
            //else print("Такого пользователя нет");
        }
        if (load_id != "")
        {
            //print(load_id + " " + load_rights);
            SaveInDB.data_id = load_id;
            DeleteInDB.data_id_del = load_id;
            SaveInDB.data_rights = load_rights;
            load_id = "";
            load_rights = "";

           // print(DeleteInDB.data_id_del);
        }
        else print("Данный id не найден!");
    }

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {  // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            //string[] str_data = {""};//
            //List <string> list = new List<string>();//

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
                    //Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);

                    string rawresponse = webRequest.downloadHandler.text;

                    string[] users = rawresponse.Split("*");

                    for (int i = 0; i < users.Length; i++)
                    {
                        //Debug.Log("Current data: " + users[i]);
                        if (users[i] != "")
                        {
                            string[] user_info = users[i].Split(',');
                            Debug.Log("Id: " + user_info[0] + " Login: " + user_info[1] + " Password: " + user_info[2]);

                            GameObject inform = (GameObject)Instantiate(userInfoTemplate);
                            inform.transform.SetParent(userInfoContainer.transform);
                            inform.GetComponent<UserInfoDB>().login.text = user_info[0];
                            inform.GetComponent<UserInfoDB>().password.text = user_info[1];

                            
                            list_id.Add(user_info[0]);
                            list_rights.Add(user_info[1]);
                            str_data_id = list_id.ToArray();
                            str_data_rights = list_rights.ToArray();
                            
                        }
                    }
                    break;
            }
            
            
        }
    }
}
