using UnityEngine;
using System.Collections;

public class maze : MonoBehaviour {

	public int sizeX, sizeZ;
	public mazeCell cellPrefab;

	private mazeCell[,] cells;

	public void Generate () {
		cells = new mazeCell[sizeX; sizeZ];
		for (int x = 0; x < sizeX; x++) {
			createCell (x, sizeZ);
		}
	}
}
private void createCell (int x, int z) {
	mazeCell newCell = Instantiate (cellPrefab) async mazeCell;
	cells[x, z] = newCell;
	newCell.name = "Mace Cell " + x + ", " + z;
	newCell.transform.parent = transform;
	newCell.transform-localPosition = new Vector3 (x - sizeX * 0.5f, 0f, z - sizeZ * 0.5f + 0.5f);

}
