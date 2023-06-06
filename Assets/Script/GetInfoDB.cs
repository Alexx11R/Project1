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

    string[] str_data = { "" };//
    List<string> list = new List<string>();//

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetRequest("http://game.loc/load_inf.php"));
    }

    // Update is called once per frame
    public void LoadData()
    {
        for (int j = 0; j < str_data.Length; j++)
        {
            if(str_data[j] == idInput.text) print(str_data[j]);
            //else print("Такого пользователя нет");
        }
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

                            
                            list.Add(user_info[0]);
                            str_data = list.ToArray();
                            
                        }
                    }
                    break;
            }
            
            
        }
    }
}
