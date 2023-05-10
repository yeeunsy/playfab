using GoogleSheetsToUnity;
using Mono.Cecil.Cil;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.Events;

public class TESTCASE : MonoBehaviour
{

    public string associatedSheet = "1DY9NCkSKajg4tSbTO8VThmVQrYOq0H673B6aPooNU_8";
    public string associatedWorksheet = "1장";

    public List<string> items = new List<string>();

    public List<string> KEY = new List<string>();
    internal void UpdateStats(List<GSTU_Cell> list, string name)
    {
        items.Clear();
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
        //캐릭터 스프라이트 전환 (노멀)
        if (Input.GetKeyDown(KeyCode.Alpha1)) 
        {
            characterManager.SetCharacter(Define.Characters.A1.name, Define.emotion.Default);
        }
        //캐릭터 스프라이트 전환 (기쁨)
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            characterManager.SetCharacter(Define.Characters.A1.name, Define.emotion.Happy);
        }
        //캐릭터 스프라이트 전환 (분노)
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            characterManager.SetCharacter(Define.Characters.A1.name, Define.emotion.Angry);
        }
        //캐릭터 스프라이트 전환 (부끄러움)
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            characterManager.SetCharacter(Define.Characters.A1.name, Define.emotion.Compress);
        }
        //캐릭터 스프라이트 전환 (놀람)
        if (Input.GetKeyDown(KeyCode.Alpha5)) 
        {
            characterManager.SetCharacter(Define.Characters.A1.name, Define.emotion.Suprise);
        }
        //에니메이션 실행 테스트
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            characterManager.PlayAnimation("AnimationName");
        }
        //백그라운드 전환테스트 
        if (Input.GetKeyDown(KeyCode.B)) 
        {
            //backgroundManager.SetBackground(0); 
            //구현안됨
        }
        // 문장키 초기화
        if (Input.GetKeyDown(KeyCode.E))
        {
            //dialogueManager.StartDialogue();
        }
        //다음 문장
        if (Input.GetKeyDown(KeyCode.R))
        {
            //dialogueManager.ShowDialogue();
        }
        //다음 선택지 출력 :UI 수정해야함 버튼안넣음
        if (Input.GetKeyDown(KeyCode.D)) 
        {
            choiceManager.ShowChoices();
        }
        //다음 선택지 숨기기:UI 수정해야함 버튼안넣음
        if (Input.GetKeyDown(KeyCode.F)) 
        {
            choiceManager.HideChoices();
        }


    }



    [CustomEditor(typeof(TESTCASE))]
    public class DataEditor : Editor
    {
        TESTCASE data;

        void OnEnable()
        {
            data = (TESTCASE)target;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            GUILayout.Label("Read Data Examples");

            if (GUILayout.Button("Pull Data Method One"))
            {
                UpdateStats(UpdateMethodOne);
            }
        }

        void UpdateStats(UnityAction<GstuSpreadSheet> callback, bool mergedCells = false)
        {
            SpreadsheetManager.Read(new GSTU_Search(data.associatedSheet, data.associatedWorksheet), callback, mergedCells);
        }

        void UpdateMethodOne(GstuSpreadSheet ss)
        {
            //data.UpdateStats(ss.rows["Jim"]);
            foreach (string dataName in data.KEY)
                data.UpdateStats(ss.rows[dataName], dataName);
            EditorUtility.SetDirty(target);
        }

    }
}
