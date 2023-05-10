using UnityEngine;
using UnityEngine.UI;

public class BackgroundManager : MonoBehaviour
{
    [SerializeField] private Image backgroundImage;
    [SerializeField] private Sprite[] backgroundSprites; // 여러 배경 스프라이트를 저장할 배열

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