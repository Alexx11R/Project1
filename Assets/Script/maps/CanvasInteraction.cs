using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasInteraction : MonoBehaviour
{
    [SerializeField]
    public GameObject MenuCanvas;
    public GameObject GameCanvas;
    public GameObject MapCanvas;
    public GameObject player;
    public GameObject ContinueImage;
    public GameObject StartImage;
    public bool _clickpoint; // проверка на нажатие метки на карте
    public bool active_info;
    public int mode = 1;// 0 - authoriz, 1 - menu, 2 - game, 3 - map
    CharacterController controller;
    Teleport t;
   // PipeInfo p;
    

    void Start()
    {
        controller = player.GetComponent<CharacterController>();
        t = player.GetComponent<Teleport>();
       // p = player.GetComponent<PipeInfo>();
        MenuCanvas.SetActive(true);
        GameCanvas.SetActive(false);
        MapCanvas.SetActive(false);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void StartGame()
    {
        Time.timeScale = 1f;
        StartImage.SetActive(false);
        ContinueImage.SetActive(true);
        ContinueImage.transform.localScale = new Vector2(1f, 1f);
        MenuCanvas.SetActive(false);
        GameCanvas.SetActive(true);
        MapCanvas.SetActive(false);
        mode = 2;
        active_info = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        _clickpoint = t.clickpoint;

        if (_clickpoint == true)
        {
            Time.timeScale = 1f;
            controller.enabled = true;
            MenuCanvas.SetActive(false);
            GameCanvas.SetActive(true);
            MapCanvas.SetActive(false);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            mode = 2;
            active_info = true;
            _clickpoint = false;
            t.clickpoint = _clickpoint;
           
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            if (mode == 2)
            {
                Time.timeScale = 0f;
                controller.enabled = false;
                mode = 3;
                active_info = false;
                MenuCanvas.SetActive(false);
                GameCanvas.SetActive(false);
                MapCanvas.SetActive(true);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
               
            }
            else
            {
                if (mode == 3)
                {
                    Time.timeScale = 1f;
                    controller.enabled = true;
                    MenuCanvas.SetActive(false);
                    GameCanvas.SetActive(true);
                    MapCanvas.SetActive(false);
                    Cursor.visible = false;
                    Cursor.lockState = CursorLockMode.Locked;
                    mode = 2;
                    active_info = true;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (mode == 2)
            {
                Time.timeScale = 0f;
                controller.enabled = true;
                GameCanvas.SetActive(false);
                MenuCanvas.SetActive(true);
                MapCanvas.SetActive(false);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                mode = 1;
                active_info = false;
            }
            else if (mode == 1)
                {
                Time.timeScale = 1f;
                controller.enabled = true;
                MenuCanvas.SetActive(false);
                GameCanvas.SetActive(true);
                MapCanvas.SetActive(false);
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                mode = 2;
                active_info = true;
            }
            else if (mode == 3)
                 {
                Time.timeScale = 1f;
                controller.enabled = true;
                MenuCanvas.SetActive(false);
                GameCanvas.SetActive(true);
                MapCanvas.SetActive(false);
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                mode = 2;
                active_info = true;
            }
        }
    }

    public void QuitGAme()
    {
        Debug.Log("Exit");
        Application.Quit();
    }
}

