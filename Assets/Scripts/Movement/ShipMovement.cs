using UnityEngine;
using System.Collections;

public class ShipMovement : MonoBehaviour {

	public Camera playerCamera;
	public Vector3 targetPosition;

	public float turnSpeed = 20;
	public float forwardSpeed = 5;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)){
			Vector3 mousePos = playerCamera.ScreenToWorldPoint(Input.mousePosition);
			targetPosition = new Vector3(mousePos.x,mousePos.y,transform.position.z);
		}
	}

	void FixedUpdate(){
		Vector3 targetDirection = (targetPosition-transform.position);
		if(targetDirection.magnitude > 1){
			transform.up = Vector3.RotateTowards(transform.up, targetDirection.normalized, turnSpeed*Time.fixedDeltaTime,0);
		}

		transform.position += transform.up*forwardSpeed*Time.fixedDeltaTime;

	}

}
