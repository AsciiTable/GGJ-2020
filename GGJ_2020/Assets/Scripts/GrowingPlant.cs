using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowingPlant : Plant
{
    // Start is called before the first frame update
    void Start()
    {
        occupiedBlock = gameObject.GetComponentInParent<Block>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
