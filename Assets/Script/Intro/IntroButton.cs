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
    /// 새로운 게임 시작 버튼 클릭 시 로딩화면 띄우기
    /// </summary>
    public void NewStart()
    {
        loadingScreen.LoadGame(); // 로딩 화면을 띄워줄 함수 호출
    }

    /// <summary>
    /// 저장된 게임 불러오기 (아직 저장된 게임이 없기 때문에 나중에 코드 수정)
    /// </summary>
    public void LoadGame()
    {
        string path = Application.persistentDataPath + "/savedata.dat"; // 불러올 파일 경로
        if (File.Exists(path)) // 저장된 파일이 있는 경우에만 불러옴
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            //SaveData data = formatter.Deserialize(stream) as SaveData; 아직 
            stream.Close();
            // 불러온 데이터를 처리
            Debug.Log("불러오기 완료");
        }
        else
        {
            Debug.LogError("저장된 데이터가 없습니다.");
        }
    }
    /// <summary>
    /// 게임 종료 버튼
    /// </summary>
    public void ExitGame()
    {
        Application.Quit();
    }

    
}
