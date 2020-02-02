using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpreadingPlant : MonoBehaviour
{
    public ObjectPooler oPool;
    private Block bOccupied;
    private bool hasSpread;
    private RaycastHit2D hit;
    public GridManager gm;

    private void OnEnable()
    {
        bOccupied = gameObject.GetComponentInParent<Block>();
        hasSpread = false;
        gm = (GridManager)FindObjectOfType(typeof(GridManager));
        if (gm == null)
            Debug.Log("Can't find GRIDMANAGER.");
    }

    public void Spread() {
        if (gm != null) {
            if (checkCollision(Vector2.up, gm.))
                Debug.Log("Up");
            if (checkCollision(Vector2.right))
                Debug.Log("Right");
            if (checkCollision(-Vector2.up))
                Debug.Log("Down");
            if (checkCollision(-Vector2.right))
                Debug.Log("Left");
        }
    }

    protected bool checkCollision(Vector2 v2, float distance) {
        hit = Physics2D.Raycast(transform.position, v2);
        if (hit.collider != null) {
            Block b = hit.transform.gameObject.GetComponent<Block>();
            if (b != null) {
                Debug.Log("Hit " + hit.transform.name);
                Debug.DrawLine(this.gameObject.transform.position, hit.transform.position, Color.cyan, 60f);
                if (hit.transform.childCount == 0)
                    return true;
                else {
                    GrowingPlant g = b.gameObject.GetComponentInChildren<GrowingPlant>();
                    if (g.getDestroyable()) {
                        return true;
                    }
                    return false;
                }
            }
        }
        return false;
    }
}
