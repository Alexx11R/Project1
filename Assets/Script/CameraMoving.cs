using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoving : MonoBehaviour
{
    public Camera MainCamera;
    public GameObject TargetPosition;
    public float speed = 1;
    public bool camera_move_enabled = false;
    public GameObject Point_1;
    public GameObject Point_2;
    public GameObject Point_3;
    public GameObject Point_4;
    public GameObject Point_5;



    void CamMove(GameObject target,Camera cam)
    {
        cam.transform.position = Vector3.Lerp(transform.position, target.transform.position, speed * Time.deltaTime);
        cam.transform.rotation = Quaternion.Lerp(transform.rotation, target.transform.rotation, speed * Time.deltaTime);

    }
    void Update()
    {


        if (camera_move_enabled)
        {
            CamMove(TargetPosition, MainCamera);
            if (MainCamera.transform.position == TargetPosition.transform.position && MainCamera.transform.rotation == TargetPosition.transform.rotation)
            {
                TargetPosition.transform.position = Point_1.transform.position;
                TargetPosition.transform.rotation = Point_1.transform.rotation;
                Debug.Log("Yeah");
                CamMove(TargetPosition, MainCamera);
            }
        }

    }

   
   
}
