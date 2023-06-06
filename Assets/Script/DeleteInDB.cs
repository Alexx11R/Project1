using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeleteInDB : MonoBehaviour
{

    //[SerializeField] private TMP_Text rightsT;

    //[SerializeField] private TMP_InputField IdUser;
    // [SerializeField] private TMP_InputField idInput;
    //[SerializeField] private TMP_InputField rightsInput;
    [SerializeField] private WebManager manager;

    public static string data_id_del = "";
    //public static string data_rights = "";
    public int int_data_id_del;
    // GameObject load_id;


    /* public void ChangeRights(TMP_Text newRights)
     {
         rightsT.text = newRights.text;
         WebManager.userData.playerData.rights = newRights.text;
     }*/

    public void LoadingData()
    {
        //load_id.GetComponent<GetInfoDB>().login.text;
        if (data_id_del != "")
        {
            int_data_id_del = int.Parse(data_id_del);
            WebManager.userData.playerData.id = int_data_id_del;

            print("Œeee");

            //WebManager.userData.playerData.rights = data_rights;

            //rightsInput.text = WebManager.userData.playerData.rights;
            //print(WebManager.userData.playerData.id + " " + WebManager.userData.playerData.rights);
        }
        else print("Œ¯Ë·Í‡");
    }

    public void DeleteData()
    {
        var player = WebManager.userData.playerData;
        //player.rights = rightsInput.text;
        manager.DeleteData(player.id);
    }
}
