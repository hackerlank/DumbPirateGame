using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Camera))]
public class CameraMovement : MonoBehaviour {

	public Transform cameraFocus;
	public CameraSelector cameraSelector; 
	public Vector3 cameraOffset = new Vector3(0,0,-10);
	public float zoomInterval = 0.2f;
	public float zoomOutMax = 1.5f;
	public float zoomInMax = 0.5f;

	private Camera camera;
	private Vector3 oldMousePos;
	private float currentZoomLevel = 1f;
	private float orignalOrphoSize;

	// Use this for initialization
	void Start () {
		camera = GetComponent<Camera>();
		orignalOrphoSize = camera.orthographicSize;
	}
	
	// Update is called once per frame
	void Update () {

		handleMovement();
		handleZoom();

	}

	void handleZoom(){
		float mouseScrollY = Input.mouseScrollDelta.y*zoomInterval;

		currentZoomLevel = Mathf.Clamp(currentZoomLevel-mouseScrollY,zoomOutMax,zoomInMax);

		//Debug.Log(mouseScrollY);

		camera.orthographicSize = orignalOrphoSize * currentZoomLevel;
	}

	void handleMovement(){
		Vector3 cameraMove = Vector3.zero;

		if(Input.GetMouseButtonDown(1)){
			Ray mouseRay = camera.ScreenPointToRay(Input.mousePosition);
			RaycastHit rayInfo;
			if(Physics.Raycast(mouseRay, out rayInfo)){
				if(rayInfo.collider.gameObject.layer == LayerMask.NameToLayer("CameraFocusable")){
					cameraFocus = rayInfo.collider.transform;
					cameraSelector.Focus(rayInfo.collider.transform);
				}else{
					oldMousePos = camera.ScreenToWorldPoint(Input.mousePosition);
					cameraFocus = null;
				}
			}else{
				oldMousePos = camera.ScreenToWorldPoint(Input.mousePosition);
				cameraFocus = null;
			}
		}else if(Input.GetMouseButton(1)){
			if(cameraFocus == null){
				cameraMove = oldMousePos - camera.ScreenToWorldPoint(Input.mousePosition);
			}
		}
		if(cameraFocus != null){
			cameraMove = ((cameraFocus.transform.position + cameraOffset)-camera.transform.position)/5;
		}

		camera.transform.position += cameraMove;
	}

}
