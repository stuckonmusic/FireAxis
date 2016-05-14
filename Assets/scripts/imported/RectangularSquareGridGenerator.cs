using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Generates rectangular shaped grid of squares.
/// </summary>
[ExecuteInEditMode()]
public class RectangularSquareGridGenerator : ICellGridGenerator
{
    public GameObject SquarePrefab;

    public int Width;
	public int length;
    public int Height;

    public override List<Cell> GenerateGrid()
    {
        var ret = new List<Cell>();

        if (SquarePrefab.GetComponent<Square>() == null)
        {
            Debug.LogError("Invalid square cell prefab provided");
            return ret;
        }

        for (int i = 0; i < Width; i++)
        {
            for (int j = 0; j < Height; j++)
				
            {
				for (int k = 0; k<length; k++)
				{
                var square = Instantiate(SquarePrefab);
                var squareSize = square.GetComponent<Cell>().GetCellDimensions();

					square.transform.position = new Vector3(i*squareSize.x,j*squareSize.y,k*squareSize.z);
               // square.GetComponent<Cell>().OffsetCoord = new Vector3(i,j,k);
                square.GetComponent<Cell>().MovementCost = 1;
                ret.Add(square.GetComponent<Cell>());

                square.transform.parent = CellsParent;
				}
            }
        }

			
        return ret;
    }
}
