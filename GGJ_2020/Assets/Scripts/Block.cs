using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public bool occupied = false;
    public bool content = false;

    [Tooltip("The object that will content the block")]
    public Structs.id wantedPlant = Structs.id.basicSeed;

    public void Place()
    {
        
    }
}
