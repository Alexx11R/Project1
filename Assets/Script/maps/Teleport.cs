using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform tpPos1;
    public Transform tpPos2;
    public Transform tpPos3;
    public GameObject player;
    private CharacterController _charController;
 
    public void ClickPoint1()
    {
        player.transform.position = tpPos1.transform.position;
    }

    public void ClickPoint2()
    {
        player.transform.position = tpPos2.transform.position;
    }

    public void ClickPoint3()
    {
        player.transform.position = tpPos3.transform.position;
    }
}

