using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadInf : MonoBehaviour
{
    public int cherid;
    public CanvasInf MainCanvas;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown() {
       MainCanvas.gameObject.SetActive(true);
    MainCanvas.ChangeId(cherid);
    Cursor.visible=true;
    Cursor.lockState=CursorLockMode.None;
    }
}
