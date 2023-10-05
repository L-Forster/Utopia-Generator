using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexGrid : MonoBehaviour
{
    [Header("Grid Settings")]
    public Vector2Int gridSize;

    [Header("Tile Settings")]
    public float outerSize = 1f;
    public float innerSize = 0f;
    public float height = 1f;
    public Material material;

    [Header("HexGen settings")]
    public HexGen hexgen;
    public int Residential;
    public int Industrial;
    public int Commercial;
    public int Infrastructure;
    public int Entertainment;
    public int Greenspace;
    public int Nothing;
    
    public void OnDone()
    {
        LayoutGrid();
    }
    //private void OnValidate()
    //{
        //if (Application.isPlaying)
        //{
        //    LayoutGrid();
        //}
    //}

    private void LayoutGrid()
    {
        hexgen = new HexGen();
        hexgen.hexlist(Residential, Industrial, Commercial, Infrastructure, Entertainment, Greenspace, Nothing);
        for (int y = 0; y < gridSize.y; y++)
        {
            for (int x = 0; x < gridSize.x; x++)
            {
                
                GameObject tile = new GameObject($"Hex {x},{y}", typeof(HexRenderer));
                HexRenderer hexRenderer = tile.GetComponent<HexRenderer>();
                tile.transform.position = GetPositionForHexFromCoordinate(new Vector2Int(x, y));

                hexRenderer.outerSize = outerSize;
                hexRenderer.innerSize = innerSize;
                hexRenderer.height = height;
                hexRenderer.setMaterial(material);
                hexRenderer.DrawMesh();
                HexType hextype = hexgen.generator(tile.transform.position);
                hextype.GenerateHex(tile.transform.position);
                tile.transform.SetParent(transform, true);

            }
        }
    }

    public Vector3 GetPositionForHexFromCoordinate(Vector2Int coordinate)
    {
        int column = coordinate.x;
        int row = coordinate.y;
        float width;
        float height;
        float xPosition;
        float yPosition;
        bool shouldOffset;
        float horizontalDistance;
        float verticalDistance;
        float offset;
        float size = outerSize;
        
        //shouldOffset = (row % 2) == 0;
        //width = Mathf.Sqrt(3) * size;
        //height = 2f * size;
        //horizontalDistance = width;
        //verticalDistance = height * (3f / 4f);
        //offset = (shouldOffset) ? width / 2 : 0;
        //xPosition = (column * (horizontalDistance)) + offset;
        //yPosition = (row * verticalDistance);
        //return new Vector3(xPosition, 0, -yPosition);
        shouldOffset = (column % 2) == 0;
        height = Mathf.Sqrt(3) * size;
        width = 2f * size;
        horizontalDistance = width* (3f / 4f);;
        verticalDistance = height;
        offset = (shouldOffset) ? height / 2 : 0;
        xPosition = (column * (horizontalDistance));
        yPosition = (row * verticalDistance) -offset;
        return new Vector3(xPosition, 0, -yPosition);
    }
}
