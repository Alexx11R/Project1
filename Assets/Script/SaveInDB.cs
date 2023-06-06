using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SaveInDB : MonoBehaviour
{

    //[SerializeField] private TMP_Text rightsT;

    //[SerializeField] private TMP_InputField IdUser;
    [SerializeField] private TMP_InputField idInput;
    [SerializeField] private TMP_InputField rightsInput;
    [SerializeField] private WebManager manager;

   /* public void ChangeRights(TMP_Text newRights)
    {
        rightsT.text = newRights.text;
        WebManager.userData.playerData.rights = newRights.text;
    }*/

    public void LoadData()
    {
        int num;
        num = int.Parse(idInput.text);
        WebManager.userData.playerData.id = num;

        print(WebManager.userData.playerData.rights);
    }

   /* public void SaveData()
    {
        var player = WebManager.userData.playerData;
        manager.SaveData(player.id, player.rights);
    }*/
}
