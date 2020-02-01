using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [Header("Blocks")]
    public GameObject[] blocks;

    [Header("Initialization")]
    [SerializeField] private GameObject blockPrefab;
    [Space(5)]
    [SerializeField] private float borderWidth = 1f;
    [SerializeField] private float borderHieght = 1f;
    [SerializeField] private float blockWidth = 1f;
    [SerializeField] private float blockHeight = 1f;
    [SerializeField] private int xRows = 5;
    [SerializeField] private int yRows = 5;

    void Start()
    {
        DropBlocks();
    }

    private void DropBlocks()
    {
        blocks = new GameObject[25];

        Debug.Log(xRows % 2 > 0);

        Vector3 pos = new Vector3(Mathf.Floor(xRows/2f) * -(blockWidth + borderWidth),Mathf.Floor(yRows/2f) * (blockHeight + borderHieght), 0f);
        if (xRows % 2 == 0)
            pos.x += blockWidth / 2f;
        if (yRows % 2 == 0)
            pos.y -= blockHeight / 2f;

        for (int i = 1; i <= yRows; i++)
        {
            for(int j = 1; j <= xRows; j++)
            {
                GameObject block = Instantiate(blockPrefab);
                block.transform.position = pos;
                block.transform.localScale = new Vector3(blockWidth, blockHeight, 1f);

                pos.x += blockWidth + borderWidth;
            }

            pos.y -= blockHeight + borderHieght;
            pos.x = Mathf.Floor(xRows / 2f) * -(blockWidth + borderWidth);
            if (xRows % 2 == 0)
                pos.x += blockWidth / 2f;
        }
    }
}
