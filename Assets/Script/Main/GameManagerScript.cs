using GoogleSheetsToUnity;
using Mono.Cecil.Cil;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.Events;
using Unity.VisualScripting;

public class GameManagerScript : MonoBehaviour
{

    public string associatedSheet = "1DY9NCkSKajg4tSbTO8VThmVQrYOq0H673B6aPooNU_8";
    public string associatedWorksheet = "1장";

    public int dialogueKey = 1;
    internal void UpdateStats(List<GSTU_Cell> list, string name)
    {
        //items.Clear();
        string Character = "", Expression = "", line = "", Background = "", Command = "";
        for (int i = 0; i < list.Count; i++)
        {
            switch (list[i].columnId)
            {
                case "Character":
                    {
                        Character = list[i].value;
                        break;
                    }
                case "Expression":
                    {
                        Expression = list[i].value;
                        break;
                    }
                case "line":
                    {
                        line = list[i].value;
                        break;
                    }
                case "Background":
                    {
                        Background = list[i].value;
                        break;
                    }
                case "Command":
                    {
                        Command = list[i].value;
                        break;
                    }
            }
        }
        Debug.Log($" 캐릭터 :{Character} 표정 : {Expression} 대사 : {line}  배경 :{Background} 명령어 :{Command}");

        //캐릭터 및 표정 설정
        CharacterChange(Character, Expression);
        dialogueKey += 1;
        
        dialogueManager.StartDialogue();
        dialogueManager.ShowDialogue(line);
        backgroundChange(Background);
    }

    private void CharacterChange(string Character,string Expression)
    {
        var character_temp = "";
        int expression_temp = 0;
        switch (Character)
        {
            case "A1": character_temp = Define.Characters.A1.name;  break;
        }
        switch (Expression)
        {
            case "Default": expression_temp = Define.emotion.Default; break;
            case "Happy": expression_temp = Define.emotion.Happy; break;
            case "Compress": expression_temp = Define.emotion.Compress; break;
            case "Angry": expression_temp = Define.emotion.Angry; break;
            case "Suprise": expression_temp = Define.emotion.Suprise; break;
        }

        characterManager.SetCharacter(character_temp, expression_temp);
    }

    private void backgroundChange(string Background)
    {
        var character_temp = "";
        int expression_temp = 0;
        switch (Background)
        {
            case "도시": backgroundManager.SetBackground(2); break;
            case "해변": backgroundManager.SetBackground(4); break;
            case "바다": backgroundManager.SetBackground(1); break;
            case "숲": backgroundManager.SetBackground(3); break;
            case "밤호수": backgroundManager.SetBackground(0); break;
        }

        
    }

    // Start is called before the first frame update
    private DialogueManager dialogueManager;
    private CharacterManager characterManager;
    private BackgroundManager backgroundManager;
    private ChoiceManager choiceManager;
    private void Start()
    {
        characterManager = FindObjectOfType<CharacterManager>();
        backgroundManager = FindObjectOfType<BackgroundManager>();
        dialogueManager = FindObjectOfType<DialogueManager>();
        choiceManager = FindObjectOfType<ChoiceManager>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            UpdateStats(UpdateMethodOne);
            //dialogueManager.ShowDialogue();
        }
        

    }



    
    private void UpdateStats(UnityAction<GstuSpreadSheet> callback,  bool mergedCells = false)
    {
        SpreadsheetManager.Read(new GSTU_Search(associatedSheet, associatedWorksheet), callback, mergedCells);
    }

    private void UpdateMethodOne(GstuSpreadSheet ss)
    {
        string dataName = dialogueKey.ToString();
        UpdateStats(ss.rows[dataName], dataName);
            
    }

    
}
