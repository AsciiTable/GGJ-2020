using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [Header("Block List")]
    [SerializeField] private BlockPooler objectPooler = null;
    public GameObject[,] blocks;

    [Header("Update Blocks")]
    //[SerializeField] private GameObject blockPrefab = null;
    [Space(20)]
    [SerializeField] private float borderWidth = 1f;
    [SerializeField] private float borderHeight = 1f;
    [SerializeField] private float blockWidth = 1f;
    [SerializeField] private float blockHeight = 1f;

    public float BorderWidth { get => borderWidth; }
    public float BorderHeight { get => borderHeight; }
    public float BlockWidth { get => blockWidth; }
    public float BlockHeight { get => blockHeight; }

    [SerializeField] private int xRows = 5;
    [SerializeField] private int yRows = 5;

    private float OriginX
    {
        get { return Mathf.Floor(xRows / 2f) * -(blockWidth + borderWidth); }
    }
    private float OriginY
    {
        get { return Mathf.Floor(yRows / 2f) * (blockHeight + borderHeight); }
    }


    [ContextMenu("Update Blocks")]
    private void UpdateBlocks()
    {
        //Clear out blocks array to new xyRow sizes
        blocks = new GameObject[yRows, xRows];
        objectPooler.ClearPool();
        UpdatePool();

        //Get to the top the position of the top left screen
        Vector3 pos = new Vector3(OriginX, OriginY, 0f);
        if (xRows % 2 == 0)
            pos.x += blockWidth / 2f;
        if (yRows % 2 == 0)
            pos.y -= blockHeight / 2f;

        for (int r = 0; r < blocks.GetLength(0); r++)
        {
            for (int c = 0; c < blocks.GetLength(1); c++)
            {
                blocks[r, c].transform.position = pos;
                blocks[r, c].transform.localScale = new Vector3(blockWidth, blockHeight, 1f);

                pos.x += blockWidth + borderWidth;
            }

            pos.y -= blockHeight + borderHeight;
            pos.x = OriginX;
            if (xRows % 2 == 0)
                pos.x += blockWidth / 2f;
        }
    }
    
    private void UpdatePool()
    {
        for (int r = 0; r < yRows; r++)
            for(int c = 0; c < xRows; c++)
            {
                foreach (GameObject obj in objectPooler.GetPool())
                {
                    if (!obj.activeInHeirarchy)
                    {
                        if (!obj.GetComponent<Block>().newBlock)
                        {
                            if (obj.GetComponent<Block>().row == (r + 1) && obj.GetComponent<Block>().column == (c + 1))
                            {
                                Debug.Log("Its working");
                                blocks[r, c] = obj;
                                obj.SetActive(true);
                            }
                        }
                    }
                }
                if (blocks[r, c] == null)
                    blocks[r, c] = MakeBlock(r + 1, c + 1);
            }
    }
    private GameObject MakeBlock(int row, int column)
    {
        GameObject obj = objectPooler.GetBlock();
        obj.SetActive(true);

        Block block = obj.GetComponent<Block>();
        block.row = row;
        block.column = column;
        block.newBlock = false;

        return obj;
    }
}
