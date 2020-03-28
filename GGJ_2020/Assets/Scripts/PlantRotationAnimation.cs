using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantRotationAnimation : MonoBehaviour
{
    [SerializeField] private GrowingPlant plant;
    [SerializeField] private SpriteRenderer plantSprite;
    [SerializeField] private Sprite[] plantSprites;
    private bool initDeathAnim = false;
    private static int spriteIndex = 0;
    [HideInInspector] public static bool newScene = true;
    
    private void OnEnable()
    {
        if (plant == null) {
            if (GetComponent<GrowingPlant>() != null)
                plant = GetComponent<GrowingPlant>();
            if (GetComponent<SpriteRenderer>() != null)
                plantSprite = GetComponent<SpriteRenderer>();
        }
        //UpdateHandler.UpdateOccurred += 
        ItemDragHandler.OnClicked += UpdateStatus;
    }
    private void OnDisable()
    {
        //UpdateHandler.UpdateOccurred -= 
        ItemDragHandler.OnClicked += UpdateStatus;
        newScene = true;
    }
    private void UpdateStatus() {
        if (newScene)
            newScene = false;
        if (plant.plantIsDead && !initDeathAnim) {
            // Play death animation ONCE
            Debug.Log("Flower has DIED in \"Animation\"");
            initDeathAnim = true;
        }
        if (!plant.plantIsDead) {
            plantSprite.sprite = plantSprites[spriteIndex];
            spriteIndex++;
            if (spriteIndex >= plantSprites.Length)
                spriteIndex = 0;
        }
    }
}
