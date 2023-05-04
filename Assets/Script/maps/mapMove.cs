using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapMove : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public float distance;


    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + Vector3.up * distance;
        transform.rotation = player.transform.rotation;
        transform.rotation = Quaternion.Euler(90, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);

    }
}
