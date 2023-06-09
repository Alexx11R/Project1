using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeleteInDB : MonoBehaviour
{
    [SerializeField] private WebManager manager;

    public static string data_id_del = "";
    public int int_data_id_del;

    public void LoadingData()
    {
        if (data_id_del != "")
        {
            int_data_id_del = int.Parse(data_id_del);
            WebManager.userData.playerData.id = int_data_id_del;
        }
        else print("Ошибка");
    }

    public void DeleteData()
    {
        var player = WebManager.userData.playerData;

        manager.DeleteData(player.id);
    }
}
