using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantPooler : ObjectPooler
{
    [SerializeField] private Structs.id id = Structs.id.empty;

    public Structs.id ID { get => id; }
}
