using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SaveInDB : MonoBehaviour
{
    [SerializeField] private TMP_InputField loginInput;
    [SerializeField] private TMP_InputField passwordInput;
    [SerializeField] private TMP_InputField surnameInput;
    [SerializeField] private TMP_InputField nameInput;
    [SerializeField] private TMP_InputField patronymicInput;
    [SerializeField] private TMP_InputField rightsInput;
    [SerializeField] private WebManager manager;

    public int int_data_id;
    public static string data_id = "";
    public static string data_login = "";
    public static string data_password = "";
    public static string data_surname = "";
    public static string data_name = "";
    public static string data_patronymic = "";
    public static string data_rights = "";
   
    public void LoadingData() //вывод в InputField
    {
        if (data_id != "")
        {
            int_data_id = int.Parse(data_id); 
            WebManager.userData.playerData.id = int_data_id; // передача данных в веб-менеджер
            WebManager.userData.playerData.login = data_login; 
            WebManager.userData.playerData.password = data_password;
            WebManager.userData.playerData.surname = data_surname;
            WebManager.userData.playerData.name = data_name;
            WebManager.userData.playerData.patronymic = data_patronymic;
            WebManager.userData.playerData.rights = data_rights;

            loginInput.text = WebManager.userData.playerData.login; // вывод данных на экран
            passwordInput.text = WebManager.userData.playerData.password;
            surnameInput.text = WebManager.userData.playerData.surname;
            nameInput.text = WebManager.userData.playerData.name;
            patronymicInput.text = WebManager.userData.playerData.patronymic;
            rightsInput.text = WebManager.userData.playerData.rights;
        }
        else print("Ошибка");
    }

    public void SaveData() // сохранение на сервер
    {
        var player = WebManager.userData.playerData;

        player.login = loginInput.text;
        player.password = passwordInput.text;
        player.surname = surnameInput.text;
        player.name = nameInput.text;
        player.patronymic = patronymicInput.text;
        player.rights = rightsInput.text;

        manager.SaveData(player.id, player.login, player.password, player.surname, player.name, player.patronymic, player.rights);
    }
}
