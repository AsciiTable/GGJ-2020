using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantRotationAnimation : MonoBehaviour
{
    [SerializeField] private GrowingPlant plant;
    [SerializeField] private SpriteRenderer plantSprite;
    [SerializeField] private Sprite[] plantSprites;
    private static List<int> plantIDs;
    private bool initDeathAnim = false;
    private static int spriteIndex = 0;
    [HideInInspector] public static bool newScene = true;
    
    private void OnEnable()
    {
        if (plantIDs == null)
            plantIDs = new List<int>();
        if (plant == null) {
            if (GetComponent<GrowingPlant>() != null)
                plant = GetComponent<GrowingPlant>();
            if (GetComponent<SpriteRenderer>() != null)
                plantSprite = GetComponent<SpriteRenderer>();
        }
        UpdateHandler.UpdateOccurred += UpdateStatus;
        //ItemDragHandler.OnClicked += UpdateStatus;
    }
    private void OnDisable()
    {
        UpdateHandler.UpdateOccurred -= UpdateStatus;
        //ItemDragHandler.OnClicked += UpdateStatus;
        newScene = true;
        spriteIndex = 0;
    }
    private void UpdateStatus() {
        if (newScene) {
            onNewScene();
            newScene = false;
        }
            
        if (plant.plantIsDead && !initDeathAnim) {
            // Play death animation ONCE
            plantSprite.color = Color.black;
            initDeathAnim = true;
        }
        if (!plant.plantIsDead) {
            if (CheckPlantIDs() != -1){
                plantSprite.sprite = plantSprites[CheckPlantIDs()%plantSprites.Length];
            }
            else {
                plantIDs.Add(plant.uniqueID);
                spriteIndex++;
                if (spriteIndex >= plantSprites.Length)
                    spriteIndex = 0;
                plantSprite.sprite = plantSprites[spriteIndex];
            }
        }
    }

    private int CheckPlantIDs() {
        for (int i = 0; i < plantIDs.Count; i++) {
            if (plantIDs[i] == plant.uniqueID)
                return i;
        }
        return -1;
    }

    public static void onNewScene(){
        plantIDs = new List<int>();
        spriteIndex = 0;
        newScene = true;
    }
}
