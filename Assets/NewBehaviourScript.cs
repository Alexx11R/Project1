using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.SqliteClient;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    private SqliteConnection connection;
    private SqliteCommand command;


    void Start()
    {
            connection = new SqliteConnection("URI=file:" + Application.dataPath + "/DataBase.db");
            command = new SqliteCommand();
            command.Connection = connection;
            connection.Open();
    command.CommandText= " SELECT Name FROM Example;";
    var tmp= command.ExecuteScalar();
    Debug.Log (tmp);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
