using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour
{

    [Header("A1 Sprites")]
    public Sprite A1DefaultSprite;
    public Sprite A1HappySprite;
    public Sprite A1AngrySprite;
    public Sprite A1Suprise;
    public Sprite A1Compress;


    [Header("A2 Sprites")]
    public Sprite A2DefaultSprite;
    public Sprite A2HappySprite;
    public Sprite A2AngrySprite;
    public Sprite A2Suprise;
    public Sprite A2Compress;

    [Header("A3 Sprites")]
    public Sprite A3DefaultSprite;
    public Sprite A3HappySprite;
    public Sprite A3AngrySprite;
    public Sprite A3Suprise;
    public Sprite A3Compress;

    [Header("A4 Sprites")]
    public Sprite A4DefaultSprite;
    public Sprite A4HappySprite;
    public Sprite A4AngrySprite;
    public Sprite A4Suprise;
    public Sprite A4Compress;

    [Header("A5 Sprites")]
    public Sprite A5DefaultSprite;
    public Sprite A5HappySprite;
    public Sprite A5AngrySprite;
    public Sprite A5Suprise;
    public Sprite A5Compress;

    [Header("A6 Sprites")]
    public Sprite A6DefaultSprite;
    public Sprite A6HappySprite;
    public Sprite A6AngrySprite;
    public Sprite A6Suprise;
    public Sprite A6Compress;

    [Header("A7 Sprites")]
    public Sprite A7DefaultSprite;
    public Sprite A7HappySprite;
    public Sprite A7AngrySprite;
    public Sprite A7Suprise;
    public Sprite A7Compress;

    [Header("A8 Sprites")]
    public Sprite A8DefaultSprite;
    public Sprite A8HappySprite;
    public Sprite A8AngrySprite;
    public Sprite A8Suprise;
    public Sprite A8Compress;

    [Header("A9 Sprites")]
    public Sprite A9DefaultSprite;
    public Sprite A9HappySprite;
    public Sprite A9AngrySprite;
    public Sprite A9Suprise;
    public Sprite A9Compress;


    [System.Serializable]
    public class Character
    {
        public string characterName;
        public List<Sprite> characterSprites;
        public RuntimeAnimatorController animatorController;
    }

    [SerializeField] private Image characterImage;
    [SerializeField] private Animator characterAnimator;
    [SerializeField] private Character[] characters;

    private void Start()
    {
        characterImage.enabled = false;
    }

    public void SetCharacter(string characterName, int spriteIndex = 0)
    {
        Character character = System.Array.Find(characters, c => c.characterName == characterName);

        if (character != null)
        {
            if (spriteIndex < 0 || spriteIndex >= character.characterSprites.Count)
            {
                spriteIndex = 0;
            }
            characterImage.sprite = character.characterSprites[spriteIndex];
            characterAnimator.runtimeAnimatorController = character.animatorController;
            characterImage.enabled = true;
        }
        else
        {
            characterImage.enabled = false;
        }
    }

    public void PlayAnimation(string animationName)
    {
        characterAnimator.Play(animationName);
    }

    private void Awake()
    {
        // Initialize character sprites
        characters[0].characterSprites = new List<Sprite>
        {
            A1DefaultSprite,
            A1HappySprite,
            A1AngrySprite,
            A1Suprise,
            A1Compress
        };
        characters[1].characterSprites = new List<Sprite>
        {
            A2DefaultSprite,
            A2HappySprite,
            A2AngrySprite,
            A2Suprise,
            A2Compress
        };
        characters[2].characterSprites = new List<Sprite>
        {
            A3DefaultSprite,
            A3HappySprite,
            A3AngrySprite,
            A3Suprise,
            A3Compress
        };
        characters[3].characterSprites = new List<Sprite>
        {
            A4DefaultSprite,
            A4HappySprite,
            A4AngrySprite,
            A4Suprise,
            A4Compress
        };
        characters[4].characterSprites = new List<Sprite>
        {
            A5DefaultSprite,
            A5HappySprite,
            A5AngrySprite,
            A5Suprise,
            A5Compress
        };
        characters[5].characterSprites = new List<Sprite>
        {
            A6DefaultSprite,
            A6HappySprite,
            A6AngrySprite,
            A6Suprise,
            A6Compress
        };
        characters[6].characterSprites = new List<Sprite>
        {
            A7DefaultSprite,
            A7HappySprite,
            A7AngrySprite,
            A7Suprise,
            A7Compress
        };
        characters[7].characterSprites = new List<Sprite>
        {
            A8DefaultSprite,
            A8HappySprite,
            A8AngrySprite,
            A8Suprise,
            A8Compress
        };
        characters[8].characterSprites = new List<Sprite>
        {
            A9DefaultSprite,
            A9HappySprite,
            A9AngrySprite,
            A9Suprise,
            A9Compress
        };
        // Initialize other characters in the same way.
    }
}