using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tp : MonoBehaviour
{
    public Transform tpPos;
    public GameObject player;
    private CharacterController _charController;
    // Start is called before the first frame update

    // Update is called once per frame
 
     
 
    public void Btn()
    {
        player.transform.position = tpPos.transform.position;
        
    }
}

