using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class MessageManager : MonoBehaviour 
{
    public TMP_Text MessageText;
    public GameObject MessagePanel;

    public static MessageManager Instance;

    void Awake()
    {
        Instance = this;
        MessagePanel.SetActive(false);
    }

    public void ShowMessage(string Message, float Duration, Command com)
    {
        StartCoroutine(ShowMessageCoroutine(Message, Duration, com));
    }

    IEnumerator ShowMessageCoroutine(string Message, float Duration, Command com)
    {
        //Debug.Log("Showing some message. Duration: " + Duration);
        MessageText.text = Message;
        MessagePanel.SetActive(true);

        yield return new WaitForSeconds(Duration);

        MessagePanel.SetActive(false);
        Command.CommandExecutionComplete();
    }
}
