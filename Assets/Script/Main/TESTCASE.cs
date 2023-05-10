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
    public string associatedWorksheet = "1��";

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
        Debug.Log($" ĳ���� :{Character} ǥ�� : {Expression} ��� : {line}  ��� :{Background} ��ɾ� :{Command}");


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
        //ĳ���� ��������Ʈ ��ȯ (���)
        if (Input.GetKeyDown(KeyCode.Alpha1)) 
        {
            characterManager.SetCharacter(Define.Characters.A1.name, Define.emotion.Default);
        }
        //ĳ���� ��������Ʈ ��ȯ (���)
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            characterManager.SetCharacter(Define.Characters.A1.name, Define.emotion.Happy);
        }
        //ĳ���� ��������Ʈ ��ȯ (�г�)
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            characterManager.SetCharacter(Define.Characters.A1.name, Define.emotion.Angry);
        }
        //ĳ���� ��������Ʈ ��ȯ (�β�����)
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            characterManager.SetCharacter(Define.Characters.A1.name, Define.emotion.Compress);
        }
        //ĳ���� ��������Ʈ ��ȯ (���)
        if (Input.GetKeyDown(KeyCode.Alpha5)) 
        {
            characterManager.SetCharacter(Define.Characters.A1.name, Define.emotion.Suprise);
        }
        //���ϸ��̼� ���� �׽�Ʈ
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            characterManager.PlayAnimation("AnimationName");
        }
        //��׶��� ��ȯ�׽�Ʈ 
        if (Input.GetKeyDown(KeyCode.B)) 
        {
            //backgroundManager.SetBackground(0); 
            //�����ȵ�
        }
        // ����Ű �ʱ�ȭ
        if (Input.GetKeyDown(KeyCode.E))
        {
            //dialogueManager.StartDialogue();
        }
        //���� ����
        if (Input.GetKeyDown(KeyCode.R))
        {
            //dialogueManager.ShowDialogue();
        }
        //���� ������ ��� :UI �����ؾ��� ��ư�ȳ���
        if (Input.GetKeyDown(KeyCode.D)) 
        {
            choiceManager.ShowChoices();
        }
        //���� ������ �����:UI �����ؾ��� ��ư�ȳ���
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
