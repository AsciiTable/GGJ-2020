using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class ItemDragHandler : MonoBehaviour, IDragHandler, IEndDragHandler
{
    
    public Image img;
    public Seed seed;

    void Start() {
        img = this.gameObject.GetComponent<Image>();
    }
    
    public void OnDrag(PointerEventData eventData)
    {
        if (seed.getQuantity() > 0)
            transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.localPosition = Vector3.zero;
        if (seed.getQuantity() > 0) {
            if (seed.PlaceSeed()) {
                Debug.Log("START DAY " + Plant.dayCount);
                if (seed.seedID.Equals(Structs.id.flower))
                {
                    Plant.flowersPlanted = true;
                    Plant.growthNeeds = false;
                }
                else {
                    Plant.growthNeeds = true;
                    Plant.callForMaint = true;
                }
                Plant.turnAboutToEnd = true;
            }  
        }
    }
}
