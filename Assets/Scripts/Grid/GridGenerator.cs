using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    public float x = 0;
    public float y = 0;
    public float xOffset = 0;
    public float yOffset = 0;
    public GameObject gridPiecePrefab;
    public GameObject roboPrefab;

    void InitializeGrid()
    {
        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                Instantiate(gridPiecePrefab, new Vector3(i + xOffset, j + yOffset, 0),
                transform.rotation, this.transform);
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        InitializeGrid();
    }
}
