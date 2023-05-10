 using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private List<string> dialogueLines;
    private int currentLine = 0;
    // Start is called before the first frame update

    //
    public SaveManager saveManager;
    public InputField gameDataInputField;

    void Start()
    {
        if (!dialogueBox.active) {
            dialogueBox.SetActive(false); ;
        }
        //���۽� ��ȭ�� �ݱ�
        
    }

    public void StartDialogue()//string text)
    {
        //dialogueBox.SetActive(true);
        // ��ȭ ���ڸ� ǥ���ϰ� ��ȭ�� �����մϴ�.
        dialogueBox.SetActive(true);
        //ShowDialogue(text);
    }

    public void ShowDialogue(string text)
    {
        // ���� ��ȭ�� ǥ���ϰ� ���� ��ȭ�� �Ѿ�ϴ�.
        if (text != "")
        {
            dialogueText.text = text;
            currentLine++;
        }
        else
        {
            // ��ȭ�� ������ ��ȭ ���ڸ� ����ϴ�.
            dialogueBox.SetActive(false);
        }
    }

    public void SkipDialogue()
    {
        Debug.Log("��ŵ��ư ����");
        // ��ŵ ��� ����
    }

    public void OpenLog()
    {
        Debug.Log("�α׹�ư ����");
    }

    public void ToggleAutoProgress()
    {
        Debug.Log("�ڵ� �����ư ����");
    }
    public void Save()
    {
        Debug.Log("�����ư ����");
        //
        string gameData = gameDataInputField.text;
        saveManager.SaveGameData(gameData);
    }
    public void Load()
    {
        Debug.Log("�ҷ������ư ����");
    }
    public void ClickDialog() //�޽���â�� ���� ���� ���丮 ����
    {
        Debug.Log("�ҷ������ư ����");
        //ShowDialogue();
    }
}
