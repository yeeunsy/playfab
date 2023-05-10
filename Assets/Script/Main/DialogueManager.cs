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
        //시작시 대화탕 닫기
        
    }

    public void StartDialogue()//string text)
    {
        //dialogueBox.SetActive(true);
        // 대화 상자를 표시하고 대화를 시작합니다.
        dialogueBox.SetActive(true);
        //ShowDialogue(text);
    }

    public void ShowDialogue(string text)
    {
        // 현재 대화를 표시하고 다음 대화로 넘어갑니다.
        if (text != "")
        {
            dialogueText.text = text;
            currentLine++;
        }
        else
        {
            // 대화가 끝나면 대화 상자를 숨깁니다.
            dialogueBox.SetActive(false);
        }
    }

    public void SkipDialogue()
    {
        Debug.Log("스킵버튼 눌림");
        // 스킵 기능 구현
    }

    public void OpenLog()
    {
        Debug.Log("로그버튼 눌림");
    }

    public void ToggleAutoProgress()
    {
        Debug.Log("자동 진행버튼 눌림");
    }
    public void Save()
    {
        Debug.Log("저장버튼 눌림");
        //
        string gameData = gameDataInputField.text;
        saveManager.SaveGameData(gameData);
    }
    public void Load()
    {
        Debug.Log("불러오기버튼 눌림");
    }
    public void ClickDialog() //메시지창을 눌러 다음 스토리 진행
    {
        Debug.Log("불러오기버튼 눌림");
        //ShowDialogue();
    }
}
