using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpreadingPlant : MonoBehaviour
{
    public PlantPooler oPool;
    public Block occupiedBlock;
    public GridManager gm;

    public void Spread() {
        occupiedBlock = this.gameObject.GetComponent<GrowingPlant>().getOBlock();
        occupiedBlock.GetComponent<BoxCollider2D>().enabled = false;
        Block bUp = checkCollision(Vector2.up);
        Block bRight = checkCollision(Vector2.right);
        Block bDown = checkCollision(Vector2.down);
        Block bLeft = checkCollision(Vector2.left);
        
        if (bUp != null)
            bUp.Place(oPool.ID, false);
        if (bRight != null)
            bRight.Place(oPool.ID, false);
        if (bDown != null)
            bDown.Place(oPool.ID, false);
        if (bLeft != null)
            bLeft.Place(oPool.ID, false);
        occupiedBlock.GetComponent<BoxCollider2D>().enabled = true;
    }

    protected Block checkCollision(Vector2 direction) {
        RaycastHit2D hit = Physics2D.Raycast(occupiedBlock.transform.position, direction);
        if (hit.collider != null && hit.collider.CompareTag("Block")) {
            Block b = hit.transform.gameObject.GetComponent<Block>();
            if (b != null) {
                if (hit.transform.childCount == 0) {
                    hit.transform.gameObject.GetComponent<Block>().occupied = false;
                    return hit.transform.gameObject.GetComponent<Block>();
                }
                else {
                    if (hit.transform.GetComponentInChildren<GrowingPlant>().getDestroyable()) {
                        GameObject plant = hit.transform.GetChild(0).gameObject;
                        PlantPooler[] pools = FindObjectsOfType<PlantPooler>();
                        foreach (PlantPooler pool in pools)
                        {
                            if (plant.GetComponent<GrowingPlant>().plantID.Equals(pool.ID))
                            {
                                plant.transform.parent = pool.transform;
                                plant.gameObject.transform.localPosition = new Vector3(0f, 0f, -1f);
                                plant.SetActive(false);
                                hit.transform.gameObject.GetComponent<Block>().occupied = false;
                                return hit.transform.gameObject.GetComponent<Block>();
                            }
                        }
                    }
                }
            }
        }
        return null;
    }
}
