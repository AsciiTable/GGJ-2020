using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [Header("Current Data")]
    public Structs.id plant = Structs.id.empty;
    
    [Header("Content")]
    [Tooltip("The object that will content the block")]
    [SerializeField] private Structs.id wantedPlant = Structs.id.basicSeed;
    public bool content = false;

    [Header("Grid ID")]
    public bool newBlock = true;
    public int row = 0;
    public int column = 0;

    public bool Place(Structs.id seed)
    {
        if (plant != Structs.id.empty)
            return false;

        plant = seed;
        return true;
    }
}
