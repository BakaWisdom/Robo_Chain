using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    public float x = 0;
    public float y = 0;
    public float xOffset = 0;
    public float yOffset = 0;

    public GameObject emptyPrefab;
    public GameObject wallPrefab;
    public GameObject robotPrefab;
    public GameObject endpointPrefab;
    public GameObject conveyorSpeed1Prefab;
    public GameObject conveyorSpeed2Prefab;
    public GameObject spikePrefab;

    public Sprite levelSprite;

    private GameObject gridPiecePrefab;

    void InitializeGrid()
    {
        Texture2D levelCode = levelSprite.texture;

        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                gridPiecePrefab = decodePixel( ColorUtility.ToHtmlStringRGB(levelCode.GetPixel(i, j)).ToLower());

                GameObject gridPiece = Instantiate(gridPiecePrefab, new Vector3(i + xOffset, j + yOffset, 0),
                    transform.rotation, this.transform);
                gridPiece.name = gridPiecePrefab.name + i + j;
            }
        }
    }

    private GameObject decodePixel(string color)
    {
        switch (color)
        {
            case ("ffffff"):
                return emptyPrefab;
            case ("aaaa9a"):
                return robotPrefab;
            case ("ce953b"):
                return endpointPrefab;
            case ("81df86"):
                return conveyorSpeed1Prefab;
            case ("535aa9"):
                return conveyorSpeed2Prefab;
            case ("bb3232"):
                return spikePrefab;
            case ("000000"):
            default:
                return wallPrefab;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        InitializeGrid();
    }
}
