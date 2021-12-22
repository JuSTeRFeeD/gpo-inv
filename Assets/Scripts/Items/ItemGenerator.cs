using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class ItemGenerator : MonoBehaviour
{
    private static int id = 0;
    private const int MAX_LEVEL = 100;
    
    private const float MIN_DAMAGE = 10;
    private const float MAX_DAMAGE = 100;
    
    private const float MIN_DEFENCE = 1;
    private const float MAX_DEFENCE = 50;
    
    private const float MIN_DURABILITY = 50;
    private const float MAX_DURABILITY = 100;
    
    
    [SerializeField] private Sprite[] topSprites;
    [SerializeField] private Sprite[] bottomSprites;

    public Item GenerateNewItem(int level)
    {
        var minDmg = MIN_DAMAGE + (((MAX_DAMAGE - MIN_DAMAGE) / MAX_LEVEL) * (level - 1) + 1);
        var maxDmg = MIN_DAMAGE + (((MAX_DAMAGE - MIN_DAMAGE) / MAX_LEVEL) * level);
        
        var minDef = MIN_DEFENCE + (((MAX_DEFENCE - MIN_DEFENCE) / MAX_LEVEL) * (level - 1) + 1);
        var maxDef = MIN_DEFENCE + (((MAX_DEFENCE - MIN_DEFENCE) / MAX_LEVEL) * level);
        
        var minDur = MIN_DURABILITY + (((MAX_DURABILITY - MIN_DURABILITY) / MAX_LEVEL) * (level - 1) + 1);
        var maxDur = MIN_DURABILITY + (((MAX_DURABILITY - MIN_DURABILITY) / MAX_LEVEL) * level);

        var dmg = Random.Range(minDmg, maxDmg);
        var def = Random.Range(minDef, maxDef);
        var dur = Random.Range(minDur, maxDur);
        var item = new Item
        {
            resourceName = "Item " + id++,
            topSprite = topSprites[Random.Range(0, topSprites.Length)],
            bottomSprite = bottomSprites[Random.Range(0, bottomSprites.Length)],
            damage = dmg,
            defence = def,
            durability = dur,
        };
        item.quality = item.durability / (item.damage + item.defence);
        item.description = $"Dmg: {dmg}\nDef: {def}\nDur: {dur}\nQuality: {item.quality}";
        return item;
    }
}
