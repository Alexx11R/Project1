using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasInf : MonoBehaviour
{
   private Button CherPrint;
   private Button SpezPrint;
   private DataBase DB;
    void Start()
    {
        CherPrint=transform.GetChild(0).GetComponent<Button>();
        
        SpezPrint=transform.GetChild(1).GetComponent<Button>();
        DB=GetComponent<DataBase>();
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeId (int id)
    {
        CherPrint.onClick.AddListener(delegate{DB.pdf_copy(id);});
    }
}
