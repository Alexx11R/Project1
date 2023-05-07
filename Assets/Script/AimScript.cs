using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimScript : MonoBehaviour
{
    [SerializeField]
    private GameObject obj;
    public bool isAimed = false;
    public float distance = 0.1f;
    public Texture2D pricel;
    public int crossHairWidth = 50, crossHairHeight = 50;

    void LateUpdate()
    {
        Ray ray = obj.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(transform.position, ray.direction * distance);
        if (Physics.Raycast(ray, distance))
        {
            isAimed = true;
            
        }
        else isAimed = false;
    }

}

