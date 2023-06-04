using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CanvasInteraction : MonoBehaviour
{
    [SerializeField]
    public GameObject AdminInterface;
    public GameObject UserInterface;
    public GameObject GameCanvas;
    public GameObject MapCanvas;
    public GameObject player;
    public GameObject ContinueImageAd;
    public GameObject ContinueImageUs;
    public GameObject StartImageAd;
    public GameObject StartImageUs;
    public bool _clickpoint; // проверка на нажатие метки на карте
    public bool active_info; // проверка на вывод чертежа 
    public int mode = 1;// 1 - menu, 2 - game, 3 - map
    CharacterController controller;
    Teleport t; // переменная из класса Teleport
    public static bool rights_data; //права пользователя из БД

    void Start()
    {
        if (!rights_data) //получены права пользователя
        {
            UserInterface.SetActive(true);
            AdminInterface.SetActive(false);
        }
        else //получены права администратора
        {
            UserInterface.SetActive(false);
            AdminInterface.SetActive(true);
        }
        controller = player.GetComponent<CharacterController>();
        t = player.GetComponent<Teleport>();

        GameCanvas.SetActive(false);
        MapCanvas.SetActive(false);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void StartGame()
    {
        Time.timeScale = 1f;
        StartImageAd.SetActive(false);
        StartImageUs.SetActive(false);
        ContinueImageAd.SetActive(true);
        ContinueImageUs.SetActive(true);
        ContinueImageAd.transform.localScale = new Vector2(1f, 1f);
        ContinueImageUs.transform.localScale = new Vector2(1f, 1f);
        UserInterface.SetActive(false);
        AdminInterface.SetActive(false);
        GameCanvas.SetActive(true);
        MapCanvas.SetActive(false);
        mode = 2;
        active_info = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    private bool mouseClicked = false;
    void Update()
    {
        _clickpoint = t.clickpoint;

        if (_clickpoint == true)
        {
            Time.timeScale = 1f;
            controller.enabled = true;
            UserInterface.SetActive(false);
            AdminInterface.SetActive(false);
            GameCanvas.SetActive(true);
            MapCanvas.SetActive(false);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            mode = 2;
            active_info = true;
            _clickpoint = false;
            t.clickpoint = _clickpoint;

        }

        if (Input.GetKeyDown(KeyCode.M)) // открытие/закрытие карты
        {
            if (mode == 2) // открытие карты
            {
                Time.timeScale = 0f;
                controller.enabled = false;
                mode = 3;
                active_info = false;
                UserInterface.SetActive(false);
                AdminInterface.SetActive(false);
                GameCanvas.SetActive(false);
                MapCanvas.SetActive(true);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;

            }
            else
            {
                if (mode == 3) // закрытие карты
                {
                    Time.timeScale = 1f;
                    controller.enabled = true;
                    UserInterface.SetActive(false);
                    AdminInterface.SetActive(false);
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
            if (mode == 2) //открытие меню
            {
                Time.timeScale = 0f;
                controller.enabled = true;
                GameCanvas.SetActive(false);
                if (!rights_data) UserInterface.SetActive(true);
                else AdminInterface.SetActive(true);
                MapCanvas.SetActive(false);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                mode = 1;
                active_info = false;
            }
            else if (mode == 1) //закрытие меню
            {
                Time.timeScale = 1f;
                controller.enabled = true;
                UserInterface.SetActive(false);
                AdminInterface.SetActive(false);
                GameCanvas.SetActive(true);
                MapCanvas.SetActive(false);
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                mode = 2;
                active_info = true;
            }
            else if (mode == 3) // закрытие карты
            {
                Time.timeScale = 1f;
                controller.enabled = true;
                UserInterface.SetActive(false);
                AdminInterface.SetActive(false);
                GameCanvas.SetActive(true);
                MapCanvas.SetActive(false);
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                mode = 2;
                active_info = true;
            }
        }
        if (Input.GetMouseButtonDown(1) && !mouseClicked)// добавление обработки нажатия ПКМ 
        {
            mouseClicked = true;
        }
        if (mouseClicked)
        {
            ChangeScene();
            mouseClicked = false;
        }
    }

private void ChangeScene() //метод для перехода на другю сцену
    {
        SceneManager.LoadScene("Download");
    }

    public void QuitGAme()
    {
        Debug.Log("Exit"); 
        Application.Quit();
    }
}

