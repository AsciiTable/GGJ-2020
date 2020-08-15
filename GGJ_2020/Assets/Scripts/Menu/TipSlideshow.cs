using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipSlideshow : MonoBehaviour
{
    public List<GameObject> tips;
/*    public GameObject backbutton;
    public GameObject nextbutton;*/
    private int currentTip;

    // Start is called before the first frame update
    void Start()
    {
        currentTip = 0;
        tips[currentTip].SetActive(false);
    }


    void incrementTip() {
        tips[currentTip].SetActive(false);
        if (currentTip + 1 < tips.Count)
            currentTip++;
        else
            currentTip = 0;

        tips[currentTip].SetActive(true);
    }

    void decrementTip() {
        tips[currentTip].SetActive(false);
        if (currentTip - 1 < 0)
            currentTip++;
        else
            currentTip = tips.Count-1;

        tips[currentTip].SetActive(true);
    }
}
