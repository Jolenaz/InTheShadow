using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spotInput : MonoBehaviour {

	private void Start() {

		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;

	}

    public bool isMovable = true;

	void get_object()
	{
		RaycastHit hit;
		Physics.Raycast (gameObject.transform.position, gameObject.transform.TransformDirection (Vector3.forward), out hit, 10000.0f);
        Debug.DrawRay(gameObject.transform.position, gameObject.transform.TransformDirection(Vector3.forward) * 1000,Color.red,5);
        Debug.Log(hit.collider);
		if (hit.collider.tag == "Button") {
			var button = hit.collider.GetComponent<Button> ();
			if (button) {
				button.isClicked ();
			}
		}
	}

	// Update is called once per frame
	void Update () {
        if (!isMovable)
            return;
		gameObject.transform.Rotate (
			-Input.GetAxis ("Mouse Y") * 2,
			Input.GetAxis ("Mouse X") * 2,
			0
		);
		if (Input.GetMouseButtonDown (0))
			get_object ();
	}
}
