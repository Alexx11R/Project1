using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.SqliteClient;
using System.IO;
using System;

public class Che_printall : MonoBehaviour
{
   private SqliteConnection connection;
    private SqliteCommand command;
    public void pdf_copy()
    {
        connection = new SqliteConnection("URI=file:" + Application.dataPath + "/DataBase.db");
        command = new SqliteCommand();
        command.Connection = connection;
        connection.Open();
        command.CommandText = String.Format(" SELECT Link, Name FROM Base;");
        string link = "";
        string name = "";
        SqliteDataReader sqReader = command.ExecuteReader();
        while (sqReader.Read())
        {
            link = sqReader.GetString(0);
            name = sqReader.GetString(1);
        }

        Debug.Log(link);
        File.Copy(Application.dataPath + link, "C:/Users/Администратор/Desktop/There/" + name, true);
        connection.Close();
    }

    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {

    }
}
