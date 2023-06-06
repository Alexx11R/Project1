using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SaveInDB : MonoBehaviour
{

    //[SerializeField] private TMP_Text rightsT;

    //[SerializeField] private TMP_InputField IdUser;
   // [SerializeField] private TMP_InputField idInput;
    [SerializeField] private TMP_InputField rightsInput;
    [SerializeField] private WebManager manager;

    public static string data_id = "";
    public static string data_rights = "";
    public int int_data_id;
   // GameObject load_id;


    /* public void ChangeRights(TMP_Text newRights)
     {
         rightsT.text = newRights.text;
         WebManager.userData.playerData.rights = newRights.text;
     }*/

    public void LoadingData()
    {
        //load_id.GetComponent<GetInfoDB>().login.text;
        if (data_id != "")
        {
            int_data_id = int.Parse(data_id);
            WebManager.userData.playerData.id = int_data_id;

            WebManager.userData.playerData.rights = data_rights;

            rightsInput.text = WebManager.userData.playerData.rights;
            //print(WebManager.userData.playerData.id + " " + WebManager.userData.playerData.rights);
        }
        else print("������");
    }

    public void SaveData()
    {
        var player = WebManager.userData.playerData;
        player.rights = rightsInput.text;
        manager.SaveData(player.id, player.rights);
    }
}
