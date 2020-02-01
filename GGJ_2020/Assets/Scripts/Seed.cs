using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed : MonoBehaviour
{
    public static int zAxisPos = 0;
    [SerializeField] protected int quantity = 0;
    [SerializeField] protected float price = 0f;
    [SerializeField] protected string seedName = "";
    [SerializeField] protected Structs.id ID;
    protected bool onBlock = false;
    public Vector3 origin;

    private void Start()
    {
        origin = this.gameObject.transform.position;
    }

    public void PlaceSeed()
    {
        Vector3 mouse = new Vector3(Input.mousePosition.x, Input.mousePosition.y, zAxisPos - Camera.main.transform.position.z);
        mouse = Camera.main.ScreenToWorldPoint(mouse);
        this.transform.position = new Vector3(mouse.x, mouse.y, zAxisPos);
        if (Input.GetMouseButtonUp(0))
        {
            RaycastHit2D rayHit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));
            if (rayHit) {
                Debug.Log(rayHit.transform.name);
                if (rayHit.transform.childCount == 0 && getQuantity() > 0)
                {
                    Debug.Log("Planted");
                    decrementQuantity();
                }
                else {
                    Debug.Log("Already Occupied!");
                }
            }
                
            this.gameObject.transform.position = origin;
        }
    }

    public int getQuantity() {
        return quantity;
    }

    public void setQuantity(int quant) {
        if (quantity < 0)
            quantity = 0;
        else if (quantity > 99)
            quantity = 99;
        else
            quantity = quant;
    }

    public void decrementQuantity() 
    {
        if(quantity > 0)
            quantity--;
    }
    public void incrementQuantity()
    {
        if(quantity < 99)
            quantity++;
    }

    public float getPrice() {
        return price;
    }

    public void setPrice(float pri) {
        price = pri;
    }

    public string getName() {
        return seedName;
    }

    public void setName(string n) {
        seedName = n;
    }

    public string toString() {
        return seedName + "\n$" + price + "\nQuantity: " + quantity;
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Hit");
        if (col.gameObject.tag == "Block") {
            Debug.Log("Block is good");
        }
    }
}
