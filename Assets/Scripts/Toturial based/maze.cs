using UnityEngine;
using System.Collections;

/* Notes on the code:
 * You kinda screwed up one of the brackets and that was causing a lot of the issues ^^
 * 
 */

public class maze : MonoBehaviour
{

    public int sizeX, sizeZ;
    public mazeCell cellPrefab;

    private mazeCell[,] cells;

    public void Generate()
    {
        cells = new mazeCell[sizeX, sizeZ]; //cells = new mazeCell[sizeX; sizeZ]; (You used a semi-colon on the array declaration)
        /*for (int x = 0; x < sizeX; x++)
        {
            createCell(x, sizeZ); (Was only going through the X dimention of the array, also sizeZ is technically outside of the array, ask me about that later)
        }
        */ 
        for (int x = 0; x < sizeX; x++)
        {
            for (int z = 0; z < sizeZ; z++)
            {
                createCell(x, z);
            }
        }
    }
    private void createCell(int x, int z)
    {
        mazeCell newCell = Instantiate(cellPrefab) as mazeCell; //mazeCell newCell = Instantiate (cellPrefab) async mazeCell; (You used 'async' instead of 'as', blame autocorrect ^^ )
        cells[x, z] = newCell;
        newCell.name = "Mace Cell " + x + ", " + z;
        newCell.transform.parent = transform;
        newCell.transform.localPosition = new Vector3(x - sizeX * 0.5f, 0f, z - sizeZ * 0.5f + 0.5f);

    }
}