using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BASICBOITEMPANANIM_PLANTS : MonoBehaviour
{
    [SerializeField] private Flower flower;
    [SerializeField] private SpriteRenderer flowerSprite;
    
    [SerializeField] private Color[] flowerColors;
    private static List<int> colorIDS;
    private static Color[] IDColors;
    private static int newestColor = 0;
    private static bool newScene = true;
    [SerializeField] private Sprite[] flowerSprites;
    private void OnEnable()
    {
        if (flower == null)
        {
            if (GetComponent<Flower>() != null)
                flower = GetComponent<Flower>();
            if (GetComponent<SpriteRenderer>() != null)
                flowerSprite = GetComponent<SpriteRenderer>();
        }

        if(flowerColors == null)
        {
            flowerColors = new Color[7];
            flowerColors[0] = Color.white;
            flowerColors[1] = Color.cyan;
            flowerColors[2] = Color.green;
            flowerColors[3] = Color.blue;
            flowerColors[4] = Color.yellow;
            flowerColors[5] = Color.magenta;
            flowerColors[6] = Color.red;
        }
    }

    private void Start()
    {
        if (newScene)
        {
            Debug.Log("And so colors begin anew");
            newScene = false;
            colorIDS = new List<int>();
            newestColor = 0;
            IDColors = new Color[flowerColors.Length];
        }
    }
    private void OnDisable()
    {
        Debug.Log("Death to Colors");
        colorIDS = new List<int>();
        newestColor = 0;
        IDColors = new Color[flowerColors.Length];
        newScene = true;
    }

    private void Update()
    {
        if (!flower.spreadEnabled && flowerSprite.color != Color.black)
        {
            flowerSprite.color = Color.black;
        }
        else if (flower.spreadEnabled)
        {
            if (CheckColorBank() != -1)
            {
                flowerSprite.color = IDColors[CheckColorBank()];
            }
            else 
            {
                if(flowerColors.Length > newestColor)
                {
                    colorIDS.Add(flower.uniqueID);
                    flowerSprite.color = flowerColors[newestColor];
                    IDColors[newestColor] = flowerColors[newestColor];
                    newestColor++;
                }
                
            }
        }
    }

    private int CheckColorBank()
    {
        if (IDColors.Length == 0)
            return -1;

        for(int i = 0; i < colorIDS.Count; i++)
        {
            if (colorIDS[i] == flower.uniqueID)
                return i;
        }
        return -1;
    }
}
