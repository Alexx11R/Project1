using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInterface : MonoBehaviour
{
    public GameObject MenuCanvas;
    public GameObject GameCanvas;
    public GameObject MapCanvas;
    public GameObject player;
    public GameObject NextImage;
    public GameObject NowImage;
    CharacterController controller;
    public int mode = 2;// 0 - game, 1 - map, 2- menu
    
    void Start()
    {
        controller = player.GetComponent<CharacterController>();
        MenuCanvas.SetActive(true);
        GameCanvas.SetActive(false);
        MapCanvas.SetActive(false);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
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
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (mode == 0)
            {
                MenuCanvas.SetActive(true);
                GameCanvas.SetActive(false);
                MapCanvas.SetActive(false);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                mode = 2;
            }
            else
            {
                if (mode == 1)
                {
                    
                    MenuCanvas.SetActive(false);
                    GameCanvas.SetActive(true);
                    MapCanvas.SetActive(false);
                    Cursor.visible = false;
                    Cursor.lockState = CursorLockMode.Locked;
                    mode = 0;
                    controller.enabled = true;
                }
            }

                  
        }
    }
    public void StartGame()
    {
        NowImage.SetActive(false);
        NextImage.SetActive(true);
        MenuCanvas.SetActive(false);
        GameCanvas.SetActive(true);
        MapCanvas.SetActive(false);
        mode = 0;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void QuitGAme()
    {
        Application.Quit();
    }
}

