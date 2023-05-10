using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class ChoiceManager : MonoBehaviour
{
    [System.Serializable]
    public class Choice
    {
        public string choiceText;
        public UnityEvent choiceEvent;
    }

    [SerializeField] private GameObject choicePanel;
    [SerializeField] private GameObject choiceButtonPrefab; // 수정된 부분
    [SerializeField] private List<Choice> choices;

    private void Start()
    {
        // 선택지 패널을 처음에 숨깁니다.
        choicePanel.SetActive(false);
    }

    public void ShowChoices()
    {
        // 선택지 패널을 표시하고 선택지 버튼을 생성합니다.
        choicePanel.SetActive(true);

        foreach (Choice choice in choices)
        {
            GameObject choiceButtonObject = Instantiate(choiceButtonPrefab, choicePanel.transform);
            Button choiceButton = choiceButtonObject.GetComponent<Button>();
            TextMeshProUGUI choiceText = choiceButton.GetComponentInChildren<TextMeshProUGUI>();
            choiceText.text = choice.choiceText;

            // 버튼 클릭 이벤트에 선택지 이벤트를 추가합니다.
            choiceButton.onClick.AddListener(() => choice.choiceEvent.Invoke());
            choiceButton.onClick.AddListener(() => HideChoices());
        }
    }

    public void HideChoices()
    {
        // 선택지 패널을 숨기고 선택지 버튼을 제거합니다.
        choicePanel.SetActive(false);
        foreach (Button button in choicePanel.GetComponentsInChildren<Button>())
        {
            Destroy(button.gameObject);
        }
    }
}