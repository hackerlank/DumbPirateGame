using UnityEngine;
using System.Collections;

public class CameraSelector : MonoBehaviour {

	public float sizeMultiplier = 1.4f;

	private SpriteRenderer spriteRenderer;
	private Transform currentFocusObject;

	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer>();
		spriteRenderer.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(currentFocusObject != null){
			transform.position = currentFocusObject.position;
			transform.Rotate(new Vector3(0,0,1));
		}
	}

	public void Focus(Transform focusObject, float fadeTime = 2f){
		StopAllCoroutines();
		currentFocusObject = focusObject;
		spriteRenderer.enabled = true;
		transform.localScale = Vector3.one*focusObject.localScale.magnitude*sizeMultiplier;
		StartCoroutine(followAndFade(fadeTime));
	}

	IEnumerator followAndFade(float fadeTime){
		for(float a = 1f; a >= 0; a -= Time.fixedDeltaTime/fadeTime){
			Color c = spriteRenderer.color;
			c.a = a;
			spriteRenderer.color = c;
			yield return new WaitForFixedUpdate();
		}
		currentFocusObject = null;
		spriteRenderer.enabled = false;
	}



}
