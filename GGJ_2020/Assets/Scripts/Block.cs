using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    
    [Header("Content")]
    [Tooltip("The object that will content the block")]
    [SerializeField] private Structs.id wantedPlant = Structs.id.empty;
    public bool content = false;
    public bool occupied = false;

    [Header("Grid ID")]
    public bool newBlock = true;
    public int row = 0;
    public int column = 0;

    public bool Place(Structs.id seed)
    {
        if (occupied)
            return false;

        occupied = true;

        ObjectPooler[] po0ps = FindObjectsOfType<ObjectPooler>();

        return true;
    }
}
