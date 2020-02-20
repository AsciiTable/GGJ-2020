using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpreadingPlant : MonoBehaviour
{
    public PlantPooler oPool;
    public Block occupiedBlock;
    public GridManager gm;


    public void Spread(bool buffer = false) {
        GrowingPlant parentPlant = this.gameObject.GetComponent<GrowingPlant>();
        occupiedBlock = parentPlant.getOBlock();
        occupiedBlock.GetComponent<BoxCollider2D>().enabled = false;
        Block bUp = checkCollision(Vector2.up, (gm.BlockHeight + gm.BorderHeight) / 1.99f);
        Block bRight = checkCollision(Vector2.right, (gm.BlockWidth + gm.BorderWidth) / 1.99f);
        Block bDown = checkCollision(Vector2.down, (gm.BlockHeight + gm.BorderHeight) / 1.99f);
        Block bLeft = checkCollision(Vector2.left, (gm.BlockWidth + gm.BorderWidth) / 1.99f);

        if (bUp != null) {
            bUp.Place(oPool.ID, false, parentPlant.uniqueID, buffer);
            bUp.content = true;
        }
        if (bRight != null) {
            bRight.Place(oPool.ID, false, parentPlant.uniqueID, buffer);
            bRight.content = true;
        }
        if (bDown != null) {
            bDown.Place(oPool.ID, false, parentPlant.uniqueID, buffer);
            bDown.content = true;
        }
        if (bLeft != null) {
            bLeft.Place(oPool.ID, false, parentPlant.uniqueID, buffer);
            bLeft.content = true;
        }
        occupiedBlock.GetComponent<BoxCollider2D>().enabled = true;
    }

    protected Block checkCollision(Vector2 direction, float distance) {
        RaycastHit2D hit = Physics2D.Raycast(occupiedBlock.transform.position, direction, distance);
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
                                FindObjectOfType<LevelHandler>().treeDied = true;

                                plant.transform.parent = pool.transform;
                                plant.gameObject.transform.localPosition = new Vector3(0f, 0f, -1f);
                                plant.GetComponent<GrowingPlant>().resetPlant();
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
