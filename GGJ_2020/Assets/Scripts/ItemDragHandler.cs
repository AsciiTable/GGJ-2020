using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class ItemDragHandler : MonoBehaviour, IDragHandler, IEndDragHandler
{
    //This checks if plants are spreading or not
    public static bool isDragReady = true;

    public delegate void ClickAction();
    public static event ClickAction OnClicked;

    public Image img;
    public Seed seed;

    void Start() {
        img = this.gameObject.GetComponent<Image>();
    }
    
    public void OnDrag(PointerEventData eventData)
    {
        if (seed.getQuantity() > 0 && isDragReady)
            transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (isDragReady) { 
            transform.localPosition = Vector3.zero;
            if (seed.getQuantity() > 0) {
                if (seed.PlaceSeed()) {
                    if (OnClicked != null)
                        OnClicked();
                    StageManager.dayCount++;
                    Debug.Log("DAY " + StageManager.dayCount);
                }  
            }
        }
        
    }
}
