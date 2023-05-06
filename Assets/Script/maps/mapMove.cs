using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMove : MonoBehaviour
{
    public GameObject player;
    public float distance;

    void LateUpdate()
    {
        transform.position = player.transform.position + Vector3.up * distance;
        transform.rotation = player.transform.rotation;
        transform.rotation = Quaternion.Euler(90, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);

    }
}
