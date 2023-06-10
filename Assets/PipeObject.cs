using UnityEngine;

public class PipeObject : MonoBehaviour
{
    public string filePath;

    private void Awake()
    {
        filePath = Application.dataPath + "/Script/Maps/big.jpg";
    }
}