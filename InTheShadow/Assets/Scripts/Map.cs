using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour {

    private bool _horiz;

    private bool _isFocus;

    public GameObject lightMap;

    public bool isFinished;

    private SceneManager _sc;

	// Use this for initialization
	void Start () {
        _sc = GameObject.Find("SceneManager").GetComponent<SceneManager>();
    }

	// Update is called once per frame
	void Update () {
        if (_sc.isMenu)
            return;
        if (Input.GetKeyDown(KeyCode.LeftShift))
            _horiz = true;
        else if (Input.GetKeyUp(KeyCode.LeftShift))
            _horiz = false;
        if (Input.GetMouseButtonDown(0))
        {
            Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Physics.Raycast(mouseRay, out hit, 10000.0f);
            if (hit.collider.gameObject == gameObject)
            {
                lightMap.SetActive(true);
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                _isFocus = true;
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            lightMap.SetActive(false);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            _isFocus = false;
        }
		if (_isFocus && _horiz)
		{
            gameObject.transform.Rotate(
                Vector3.up,
                Input.GetAxis("Mouse X") * 2,
                Space.World
            );
            check_pos();
		}
		else if (_isFocus)
		{
			gameObject.transform.Rotate(
				Vector3.right,
                Input.GetAxis("Mouse Y") * 2,
				Space.World
            );
            check_pos();
		}
    }

    private void check_pos()
    {
        if (
            (transform.eulerAngles.x - 5) % 360 < 7 &&
            (transform.eulerAngles.y + 10) % 180 < 7 &&
            transform.eulerAngles.z % 360 < 7
        )
            isFinished = true;
        else
            isFinished = false;
    }
}
