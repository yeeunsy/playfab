using UnityEngine;
using UnityEngine.UI;

public class BackgroundManager : MonoBehaviour
{
    [SerializeField] private Image backgroundImage;
    [SerializeField] private Sprite[] backgroundSprites; // ���� ��� ��������Ʈ�� ������ �迭

    public void SetBackground(int index)
    {
        if (index >= 0 && index < backgroundSprites.Length)
        {
            backgroundImage.sprite = backgroundSprites[index];
        }
        else
        {
            Debug.LogWarning("Invalid background index.");
        }
    }
}