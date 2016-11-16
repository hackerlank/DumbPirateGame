using UnityEngine;
using System.Collections;

[RequireComponent(typeof(LineRenderer))]
public class DrawMovementLine : MonoBehaviour {

	public Camera playerCamera;

	private LineRenderer lineRenderer;

	// Use this for initialization
	void Start () {
		lineRenderer = GetComponent<LineRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		lineRenderer.SetPosition(0,transform.position);
		if(Input.GetMouseButtonDown(0)){
			Vector3 mousePos = playerCamera.ScreenToWorldPoint(Input.mousePosition);
			lineRenderer.SetPosition(1,new Vector3(mousePos.x,mousePos.y,0));
		}

	}
}
