using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed : MonoBehaviour
{
    public static int zAxisPos = 0;
    [SerializeField] protected int quantity = 0;
    [SerializeField] public Structs.id seedID;
    protected bool onBlock = false;
    public Vector3 origin;

    public bool hasSeeds
    {
        get { return (quantity <= 0); }
    }

    private void Start()
    {
        origin = this.gameObject.transform.position;
    }


    public Block GetOccupiedBlock() {
        Vector3 mouse = new Vector3(Input.mousePosition.x, Input.mousePosition.y, zAxisPos - Camera.main.transform.position.z);
        mouse = Camera.main.ScreenToWorldPoint(mouse);
        this.transform.position = new Vector3(mouse.x, mouse.y, zAxisPos);
        if (Input.GetMouseButtonUp(0))
        {
            RaycastHit2D rayHit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));
            if (rayHit)
            {
                Block b = rayHit.transform.gameObject.GetComponent<Block>();
                if (b != null)
                {
                    if (rayHit.transform.childCount == 0 && getQuantity() > 0)
                        return rayHit.transform.gameObject.GetComponent<Block>();
                    else
                        return null;
                }
            }
            this.gameObject.transform.position = origin;
        }
        return null;
    }

    public bool PlaceSeed()
    {
        Vector3 mouse = new Vector3(Input.mousePosition.x, Input.mousePosition.y, zAxisPos - Camera.main.transform.position.z);
        mouse = Camera.main.ScreenToWorldPoint(mouse);
        this.transform.position = new Vector3(mouse.x, mouse.y, zAxisPos);
        if (Input.GetMouseButtonUp(0))
        {
            RaycastHit2D rayHit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));
            if (rayHit) {
                Block b = rayHit.transform.gameObject.GetComponent<Block>();
                if (b != null) {
                    if (rayHit.transform.childCount == 0 && getQuantity() > 0)
                    {
                        Debug.Log("Placing " + seedID.ToString());
                        b.Place(seedID, true);
                        
                        decrementQuantity();
                        return true;
                    }
                    else
                    {
                        Debug.Log("Already Occupied!");
                    }
                }
            }
            this.gameObject.transform.position = origin;
        }
        return false;
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

    public string toString() {
        return seedID +  "\nQuantity: " + quantity;
    }
}
