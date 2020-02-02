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
        hasSpread = false;
    }

    public void Spread() {
        bOccupied = this.gameObject.GetComponent<Flower>().getOBlock();
        bOccupied.GetComponent<BoxCollider2D>().enabled = false;
        if (checkCollision(Vector2.up, gm.BorderHeight + gm.BlockHeight))
            Debug.Log("Up");
        if (checkCollision(Vector2.right, gm.BorderWidth + gm.BlockWidth))
            Debug.Log("Right");
        if (checkCollision(Vector2.down, -1 * (gm.BorderHeight + gm.BlockHeight)))
            Debug.Log("Down");
        if (checkCollision(Vector2.left, -1 * (gm.BorderWidth + gm.BlockWidth)))
            Debug.Log("Left");
        bOccupied.GetComponent<BoxCollider2D>().enabled = true;
    }

    protected bool checkCollision(Vector2 direction, float distance) {
        RaycastHit2D hit = Physics2D.Raycast(bOccupied.transform.position, direction);
        if (hit.collider != null && hit.collider.CompareTag("Block")) {
            Block b = hit.transform.gameObject.GetComponent<Block>();
            if (b != null) {
                if (hit.transform.childCount == 0)
                    return true;
                else {
                    if (hit.transform.GetComponentInChildren<GrowingPlant>().getDestroyable()) {
                        GameObject plant = hit.transform.GetChild(0).gameObject;
                        PlantPooler[] pools = FindObjectsOfType<PlantPooler>();
                        foreach (PlantPooler pool in pools)
                        {
                            if (plant.GetComponent<GrowingPlant>().plantID == pool.ID)
                            {
                                plant.transform.parent = pool.transform;
                                plant.gameObject.transform.localPosition = new Vector3(0f, 0f, -1f);
                                plant.SetActive(false);
                                return true;
                            }
                        }
                        
                        plant.GetComponent<GrowingPlant>().giveLifeToPlant();
                        plant.transform.parent = transform;
                        return true;
                    }
                }
            }
        }
        return false;
    }
}
