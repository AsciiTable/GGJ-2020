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
        Debug.Log("Dropped");
        transform.localPosition = Vector3.zero;
        if(seed.getQuantity() > 0)
            seed.PlaceSeed();

    }
}
