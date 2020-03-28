using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Reskinner : MonoBehaviour
{
    private enum PlantType { 
        Grass,
        Flower,
        Tree
    }
    private enum PlantSpriteName { 
        Flower1,
        Flower2,
        Flower3,
        Flower11,
        Flower21
    }
    [SerializeField] private PlantType plantType;
    [SerializeField] private PlantSpriteName spriteSheetName;

    private void LateUpdate()
    {
        var subSprites = Resources.LoadAll<Sprite>(plantType + "/" + spriteSheetName);
        Debug.Log(plantType + "/" + spriteSheetName);
        foreach (var renderer in GetComponentsInChildren<SpriteRenderer>()) { 
            string spriteName = renderer.sprite.name;
            var newSprite = Array.Find(subSprites, item => item.name == spriteName);// subject to change for frame-by-frame
            if (newSprite)
                renderer.sprite = newSprite;
        }
    }
}
