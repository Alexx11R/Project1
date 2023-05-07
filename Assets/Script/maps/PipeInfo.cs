using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeInfo : MonoBehaviour
{
    [SerializeField]
    private GameObject obj;
    public bool isImage;
    public bool inDist = false;
    public bool vis;
    public float distance = 0.1f;
    public int width = 600, height = 600, posX = 10, posY = 10;
    public string Info = "Smile if u wanna to give me a blowjob";
    public GUIContent content;
    private Ray ray;
    AimScript a;

    void Start()
    {
       a = obj.GetComponent<AimScript>();
    }
    void Update()
    {
        //a = obj.GetComponent<AimScript>();
        inDist = a.isAimed;
      
     //OnGUI();
    }
    void OnMouseEnter()
    {
        vis = true;
       // OnGUI();
      
    }
    void OnMouseExit()
    {
        vis = false;
    
      
    }
    void OnGUI()
    {
        
        if (inDist==true && vis==true)
        {
            GUI.Box(new Rect(10, 10, 400, 100), Info);
           if (isImage) GUI.Box(new Rect(10, 55, 400, 250), content);
            GUI.enabled = true;
        }
        else GUI.enabled = false;
    }

}


