using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantPooler : ObjectPooler
{
    private Structs.id _ID = Structs.id.empty;

    public Structs.id ID { get => _ID; }

}
