using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tip : MonoBehaviour
{
    private bool disabled = false;
    private void OnEnable()
    {
        ItemDragHandler.OnClicked += OnTipViewed;
    }

    private void OnDisable()
    {
        ItemDragHandler.OnClicked -= OnTipViewed;
    }

    private void OnTipViewed() {
        if (!disabled) {
            Debug.Log("Tip heading out!");
            disabled = true;
            this.GetComponent<Animator>().SetBool("IsVisible", false);
        }
    }
}
