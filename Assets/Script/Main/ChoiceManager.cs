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
    [SerializeField] private GameObject choiceButtonPrefab; // ������ �κ�
    [SerializeField] private List<Choice> choices;

    private void Start()
    {
        // ������ �г��� ó���� ����ϴ�.
        choicePanel.SetActive(false);
    }

    public void ShowChoices()
    {
        // ������ �г��� ǥ���ϰ� ������ ��ư�� �����մϴ�.
        choicePanel.SetActive(true);

        foreach (Choice choice in choices)
        {
            GameObject choiceButtonObject = Instantiate(choiceButtonPrefab, choicePanel.transform);
            Button choiceButton = choiceButtonObject.GetComponent<Button>();
            TextMeshProUGUI choiceText = choiceButton.GetComponentInChildren<TextMeshProUGUI>();
            choiceText.text = choice.choiceText;

            // ��ư Ŭ�� �̺�Ʈ�� ������ �̺�Ʈ�� �߰��մϴ�.
            choiceButton.onClick.AddListener(() => choice.choiceEvent.Invoke());
            choiceButton.onClick.AddListener(() => HideChoices());
        }
    }

    public void HideChoices()
    {
        // ������ �г��� ����� ������ ��ư�� �����մϴ�.
        choicePanel.SetActive(false);
        foreach (Button button in choicePanel.GetComponentsInChildren<Button>())
        {
            Destroy(button.gameObject);
        }
    }
}