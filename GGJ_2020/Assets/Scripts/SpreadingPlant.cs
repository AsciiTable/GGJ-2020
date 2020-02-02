using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpreadingPlant : MonoBehaviour
{
    public ObjectPooler oPool;
    public Block bOccupied;
    private bool hasSpread;
    private RaycastHit2D hit;
    public GridManager gm;

    private void OnEnable()
    {
        bOccupied = gameObject.GetComponentInParent<Block>();
        hasSpread = false;
    }

    public void Spread() {
        if (checkCollision(Vector2.up))
            Debug.Log("Up");
        if (checkCollision(Vector2.right))
            Debug.Log("Right");
        if (checkCollision(-Vector2.up))
            Debug.Log("Down");
        if (checkCollision(-Vector2.right))
            Debug.Log("Left");
    }

    protected bool checkCollision(Vector2 direction) {
        Ray2D ray = new Ray2D(bOccupied.transform.position, direction);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, 20f);
        if (hit.collider != null && hit.collider.CompareTag("Block")) {
            Debug.DrawLine(bOccupied.transform.position, hit.collider.transform.position);
            ray = new Ray2D(hit.collider.transform.position, direction);
            hit = Physics2D.Raycast(ray.origin, ray.direction, 20f);
            if (hit.collider != null && hit.collider.CompareTag("Block")) {
                Debug.DrawLine(ray.origin, hit.collider.transform.position);
                return true;
            }
        }
        return false;
    }
}
