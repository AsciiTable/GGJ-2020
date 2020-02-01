using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayQuantity : MonoBehaviour
{
    public Seed seed;
    public TextMeshProUGUI tmpro;

    // Update is called once per frame
    void Update()
    {
        tmpro.SetText(seed.getQuantity().ToString());
    }
}
