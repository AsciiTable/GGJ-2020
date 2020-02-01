using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed : MonoBehaviour
{
    protected int quantity = 0;
    protected float price = 0f;
    protected string seedName = "";
    public int getQuantity() {
        return quantity;
    }

    public void setQuantity(int quant) {
        if (quantity < 0)
            quantity = 0;
        else
            quantity = quant;
    }

    public void decrementQuantity() 
    {
        quantity--;
    }
    public void incrimentQuantity()
    {
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
}
