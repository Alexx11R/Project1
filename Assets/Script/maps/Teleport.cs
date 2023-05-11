using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform tpPos1;
    public Transform tpPos2;
    public Transform tpPos3;
    public GameObject player;
    public bool clickpoint = false; //проверка на нажатие метки

    public void ClickPoint1()
    {
        clickpoint = true;
        player.transform.position = tpPos1.transform.position;
    }

    public void ClickPoint2()
    {
        clickpoint = true;
        player.transform.position = tpPos2.transform.position;
    }

    public void ClickPoint3()
    {
        clickpoint = true;
        player.transform.position = tpPos3.transform.position;
    }

}

