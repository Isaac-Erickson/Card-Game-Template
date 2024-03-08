using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public Card_data data;

    public string card_name;
    public string description;
    public int health;
    public int damage;
    public Sprite sprite;
    public Sprite suit;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI descriptionText;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI damageText;
    public Image spriteImage;
    public Image suitImage;
        

    // Start is called before the first frame update
    void Start()
    {
        card_name = data.card_name;
        description = data.description;
        health = data.health;
        damage = data.damage;
        sprite = data.sprite;
        suit = data.suit;
        nameText.text = card_name;
        descriptionText.text = description;
        healthText.text = health.ToString();
        damageText.text = damage.ToString();
        spriteImage.sprite = sprite;
        suitImage.sprite = suit;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
