using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spotInput : MonoBehaviour {

	private void Start() {

		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;

	}


	void get_object()
	{
		RaycastHit hit;
		Physics.Raycast (gameObject.transform.position, gameObject.transform.TransformDirection (Vector3.forward), out hit, 1000.0f);
		if (hit.collider.tag == "Button") {
			var button = hit.collider.GetComponent<Button> ();
			if (button) {
				button.isClicked ();
			}
		}
	}

	// Update is called once per frame
	void Update () {
		gameObject.transform.Rotate (
			-Input.GetAxis ("Mouse Y") * 2,
			Input.GetAxis ("Mouse X") * 2,
			0
		);
		if (Input.GetMouseButtonDown (0))
			get_object ();
	}
}
