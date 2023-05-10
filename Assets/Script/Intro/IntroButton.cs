using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroButton : MonoBehaviour
{
    public LoadingScreen loadingScreen;//

    /// <summary>
    /// ���ο� ���� ���� ��ư Ŭ�� �� �ε�ȭ�� ����
    /// </summary>
    public void NewStart()
    {
        loadingScreen.LoadGame(); // �ε� ȭ���� ����� �Լ� ȣ��
    }

    /// <summary>
    /// ����� ���� �ҷ����� (���� ����� ������ ���� ������ ���߿� �ڵ� ����)
    /// </summary>
    public void LoadGame()
    {
        string path = Application.persistentDataPath + "/savedata.dat"; // �ҷ��� ���� ���
        if (File.Exists(path)) // ����� ������ �ִ� ��쿡�� �ҷ���
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            //SaveData data = formatter.Deserialize(stream) as SaveData; ���� 
            stream.Close();
            // �ҷ��� �����͸� ó��
            Debug.Log("�ҷ����� �Ϸ�");
        }
        else
        {
            Debug.LogError("����� �����Ͱ� �����ϴ�.");
        }
    }
    /// <summary>
    /// ���� ���� ��ư
    /// </summary>
    public void ExitGame()
    {
        Application.Quit();
    }

    
}
