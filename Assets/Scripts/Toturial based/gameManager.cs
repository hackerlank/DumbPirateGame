using UnityEngine;
using System.Collections;

public class gameManager : MonoBehaviour {

	private void Start () {
		BeginGame ();
	
	}

	private void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
		}
	
	}
	public maze mazePrefab;
	private maze mazeInstance;

	private void BeginGame () {
		mazeInstance = Instantiate (mazePrefab) as maze;
		mazeInstance.Generate ();
	}
	private void RestartGame () {
		Destroy (mazeInstance.gameObject);
		BeginGame ();
	}
}
