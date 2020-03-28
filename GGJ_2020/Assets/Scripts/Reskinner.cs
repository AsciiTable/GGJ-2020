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
        Flower11,
        Flower21
    }
    [SerializeField] private PlantType plantType;
    [SerializeField] private PlantSpriteName spriteSheetName;

    private void LateUpdate()
    {
        var subSprites = Resources.LoadAll<Sprite>(plantType + "/" + spriteSheetName);
        Debug.Log(plantType + "/" + spriteSheetName);
        // All of this is unecessary if we just have 1 varient; clarify with team first
        foreach (var renderer in GetComponentsInChildren<SpriteRenderer>()) { 
            string spriteName = renderer.sprite.name;
            var newSprite = Array.Find(subSprites, item => item.name == spriteName);// subject to change for frame-by-frame (figure out what this does first)
            if (newSprite)
                renderer.sprite = newSprite;
        }
    }
}
