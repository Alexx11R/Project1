using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    public GameObject img;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void OnMove()
    {
        img.transform.localScale = new Vector2(1.5f, 1.5f);
    }
    public void OnExit()
    {
        img.transform.localScale = new Vector2(1f, 1f);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
