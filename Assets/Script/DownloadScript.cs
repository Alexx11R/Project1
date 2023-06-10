using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.IO;

public class DownloadScript : MonoBehaviour
{
    public Button downloadButton;
    public Text statusText;
    public PipeObject pipeObject;

    private void Start()
    {
        downloadButton.onClick.AddListener(DownloadFile);
    }

    public void DownloadFile()
    {
        StartCoroutine(DownloadCoroutine());
    }

    private System.Collections.IEnumerator DownloadCoroutine()
    {
        string sourceFilePath = pipeObject.filePath;
        string fileName = Path.GetFileName(sourceFilePath);

        string destinationPath = Path.Combine(Application.persistentDataPath, fileName);

        using (UnityWebRequest www = UnityWebRequest.Get("file://" + sourceFilePath))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                File.WriteAllBytes(destinationPath, www.downloadHandler.data);
                statusText.text = "File downloaded";

                StartCoroutine(DisplayStatusTextCoroutine());
            }
            else
            {
                statusText.text = "Download failed";
            }
        }
    }

    private System.Collections.IEnumerator DisplayStatusTextCoroutine()
    {
        statusText.gameObject.SetActive(true);

        yield return new WaitForSeconds(2f);

        statusText.gameObject.SetActive(false);
    }
}