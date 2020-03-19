using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;


public class ItemDragHandler : MonoBehaviour, IDragHandler, IEndDragHandler
{

    public delegate void ClickAction();
    public static event ClickAction OnClicked;
    public GameObject dayCountDisplayer;

    public Image img;
    public Seed seed;

    void Start() {
        img = this.gameObject.GetComponent<Image>();
        dayCountDisplayer = GameObject.FindGameObjectWithTag("dayCounter");
    }
    
    public void OnDrag(PointerEventData eventData)
    {
        if (seed.getQuantity() > 0 && !StageManager.flowerGrowing)
            transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!StageManager.flowerGrowing) { 
            transform.localPosition = Vector3.zero;
            if (seed.getQuantity() > 0) {
                if (seed.PlaceSeed()) {
                    if (OnClicked != null)
                        OnClicked();
                    StageManager.dayCount++;
                    Debug.Log("DAY " + StageManager.dayCount);
                    dayCountDisplayer.GetComponent<TextMeshProUGUI>().SetText("Day " + StageManager.dayCount);
                }  
            }
        }
        
    }
}
