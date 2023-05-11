using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeInfo : MonoBehaviour
{
    [SerializeField]
    private GameObject obj;
    //private GameObject player;
    public bool isImage;
    public bool inDist = false;
    public bool vis;
    public bool act;
    public float distance = 0.1f;
    public int width = 600, height = 600, posX = 10, posY = 10;
    public string Info;
    public GUIContent content;
    private Ray ray;
    AimScript a;
    CanvasInteraction c;

    void Start()
    {
       a = obj.GetComponent<AimScript>();
       c = obj.GetComponent<CanvasInteraction>();
    }

    void Update()
    {
        inDist = a.isAimed;
        act = c.active_info;
    }

    void OnMouseEnter()
    {
        vis = true;
    }

    void OnMouseExit()
    {
        vis = false;
    }

    void OnGUI()
    {
        
        if (inDist==true && vis==true && act==true)
        {
            GUI.Box(new Rect(10, 10, 400, 100), Info);
           if (isImage) GUI.Box(new Rect(10, 55, 400, 250), content);
            GUI.enabled = true;
        }
        else GUI.enabled = false;
    }

}


