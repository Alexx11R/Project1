using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour
{
    public GameObject MenuCanvas;
    public GameObject GameCanvas;
    //public GameObject MapCanvas;
    public GameObject player;
    public GameObject ContinueImage;
    public GameObject StartImage;
    CharacterController controller;
    public int mode = 2;// 0 - game, 1 - map, 2- menu

    void Start()
    {
        controller = player.GetComponent<CharacterController>();
        MenuCanvas.SetActive(true);
        GameCanvas.SetActive(false);
        // MapCanvas.SetActive(false);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void StartGame()
    {
        StartImage.SetActive(false);
        ContinueImage.SetActive(true);
        ContinueImage.transform.localScale = new Vector2(1f, 1f);
        MenuCanvas.SetActive(false);
        GameCanvas.SetActive(true);
        //MapCanvas.SetActive(false);
        mode = 0;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.M))
        {
            if (mode == 0)
            {
                controller.enabled = false;
                mode = 1;
                MenuCanvas.SetActive(false);
                GameCanvas.SetActive(false);
                MapCanvas.SetActive(true);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;

            }
            else
            {
                if (mode == 1)
                {
                    controller.enabled = true;
                    MenuCanvas.SetActive(false);
                    GameCanvas.SetActive(true);
                    MapCanvas.SetActive(false);
                    Cursor.visible = false;
                    Cursor.lockState = CursorLockMode.Locked;
                    mode = 0;
                }
            }
        }*/

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (mode == 0)
            {
                controller.enabled = true;
                MenuCanvas.SetActive(true);
                GameCanvas.SetActive(false);
               // MapCanvas.SetActive(false);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                mode = 2;
            }
            /* else
             {
                 if (mode == 1)
                 {
                     controller.enabled = true;
                     MenuCanvas.SetActive(false);
                     GameCanvas.SetActive(true);
                     MapCanvas.SetActive(false);
                     Cursor.visible = false;
                     Cursor.lockState = CursorLockMode.Locked;
                     mode = 0;
                 }
             }*/


        }
    }

    public void QuitGAme()
    {
        Debug.Log("Exit");
        Application.Quit();
    }
}

