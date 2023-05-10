using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapInteraction : MonoBehaviour
{
    //public GameObject MenuCanvas;
    public GameObject GameCanvas;
    public GameObject MapCanvas;
    public GameObject player;
    private int mode = 2;
   // private GameObject obj;
   // public GameObject ContinueImage;
   // public GameObject StartImage;
    CharacterController controller;
   // StartMenu m; // 0 - authoriz, 1 - menu, 2 - game, 3 - map
    //public int mode = 1;// 0 - authoriz, 1 - menu, 2 - game, 3 - map

    void Start()
    {
        controller = player.GetComponent<CharacterController>();
      //  m = player.GetComponent<StartMenu>();
        /*MenuCanvas.SetActive(true);
        GameCanvas.SetActive(false);
        // MapCanvas.SetActive(false);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;*/
    }

   /* public void StartGame()
    {
        StartImage.SetActive(false);
        ContinueImage.SetActive(true);
        ContinueImage.transform.localScale = new Vector2(1f, 1f);
        MenuCanvas.SetActive(false);
        GameCanvas.SetActive(true);
        //MapCanvas.SetActive(false);
        mode = 2;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }*/

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (mode == 2)
            {
                controller.enabled = false;
                mode = 3;
                //MenuCanvas.SetActive(false);
                GameCanvas.SetActive(false);
                MapCanvas.SetActive(true);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                if (mode == 3)
                {
                    controller.enabled = true;
                    //MenuCanvas.SetActive(false);
                    GameCanvas.SetActive(true);
                    MapCanvas.SetActive(false);
                    Cursor.visible = false;
                    Cursor.lockState = CursorLockMode.Locked;
                    mode = 2;
                }
            }
        }



        if (Input.GetKeyDown(KeyCode.Escape))
        {
            /*if (mode == 2)
            {
                controller.enabled = true;
                MenuCanvas.SetActive(true);
                GameCanvas.SetActive(false);
                // MapCanvas.SetActive(false);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                mode = 1;
            }
            else
             {*/
                 if (mode == 3)
                 {
                     controller.enabled = true;
                     //MenuCanvas.SetActive(false);
                     GameCanvas.SetActive(true);
                     MapCanvas.SetActive(false);
                     Cursor.visible = false;
                     Cursor.lockState = CursorLockMode.Locked;
                     mode = 2;
                 }
            // }


        }
    }

  /*  public void QuitGAme()
    {
        Debug.Log("Exit");
        Application.Quit();
    }*/
}
