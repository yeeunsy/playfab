using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour
{
    public string sceneName; // 게임을 진행할 Scene 이름
    public GameObject loadingScreen; // 로딩 중 화면에 띄울 gameObj

    /// <summary>
    /// 로딩 후 게임 진입
    /// </summary>
    public void LoadGame()
    {
        StartCoroutine(LoadSceneAsync()); // 진행할 Scene을 비동기식으로 로딩
    }

    IEnumerator LoadSceneAsync()
    {
        loadingScreen.SetActive(true); // 로딩 화면 활성화
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName); // 비동기식으로 게임 Scene 로딩
        asyncLoad.allowSceneActivation = false; // Scene이 로딩된 후 즉시 전환되지 않도록 설정

        while (!asyncLoad.isDone)
        {
            if (asyncLoad.progress >= 0.9f) // 게임 Scene 로딩이 거의 완료된 경우
            {
                asyncLoad.allowSceneActivation = true; // Scene 전환 허용
            }

            yield return null;
        }
    }
}
