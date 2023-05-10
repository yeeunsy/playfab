using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour
{
    public string sceneName; // ������ ������ Scene �̸�
    public GameObject loadingScreen; // �ε� �� ȭ�鿡 ��� gameObj

    /// <summary>
    /// �ε� �� ���� ����
    /// </summary>
    public void LoadGame()
    {
        StartCoroutine(LoadSceneAsync()); // ������ Scene�� �񵿱������ �ε�
    }

    IEnumerator LoadSceneAsync()
    {
        loadingScreen.SetActive(true); // �ε� ȭ�� Ȱ��ȭ
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName); // �񵿱������ ���� Scene �ε�
        asyncLoad.allowSceneActivation = false; // Scene�� �ε��� �� ��� ��ȯ���� �ʵ��� ����

        while (!asyncLoad.isDone)
        {
            if (asyncLoad.progress >= 0.9f) // ���� Scene �ε��� ���� �Ϸ�� ���
            {
                asyncLoad.allowSceneActivation = true; // Scene ��ȯ ���
            }

            yield return null;
        }
    }
}
