using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SaveInDB : MonoBehaviour
{

    [SerializeField] private TMP_InputField rightsInput;
    //[SerializeField] private WebManager manager;

    public void LoadData()
    {
        print(WebManager.userData.playerData.rights);
        print("ok");
        rightsInput.text = WebManager.userData.playerData.rights;
    }

   /* public void SaveData()
    {
        var player = WebManager.userData.playerData;
        manager.SaveData(player.id, player.nickname);
    }*/
}
