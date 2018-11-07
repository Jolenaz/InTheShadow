using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour {

    public int complexity = 2;

    private bool _horiz = false;

    private bool _isFocus = false;

    private bool _translate = false;

    public GameObject lightMap;

    public bool isFinished;

    private SceneManager _sc;

    public Transform posTransform;

    public float maxAngle;

    public Vector3 soluce1;
    public Vector3 soluce2;

	// Use this for initialization
	void Start () {
        _sc = GameObject.Find("SceneManager").GetComponent<SceneManager>();
    }

	private void OnEnable()
	{
        if (complexity > 1)
        {
            transform.eulerAngles = (new Vector3(
                Random.Range(-100, 100),
                Random.Range(-100, 100),
                Random.Range(-100, 100)
            ));
        }
        else{
            gameObject.transform.Rotate(
               Vector3.right,
                Random.Range(-100, 100),
               Space.World
           );
        }
	}

	// Update is called once per frame
	void Update () {
        if (_sc.isMenu)
            return;
        if (Input.GetKeyDown(KeyCode.Space))
            printAngle();
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            _horiz = true;
            _translate = false;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
            _horiz = false;
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            _translate = true;
            _horiz = false;
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
            _translate = false;
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
        if (_isFocus && _horiz && complexity > 1 && !_translate)
		{
            gameObject.transform.Rotate(
                Vector3.up,
                Input.GetAxis("Mouse X") * 2,
                Space.World
            );
            check_pos();
		}
        else if (_isFocus && _translate && complexity > 2 && !_horiz)
        {
            gameObject.transform.Translate(new Vector3(
                Input.GetAxis("Mouse X"),
                Input.GetAxis("Mouse Y"),
                0
            ),Space.World);
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
        if (getAngle(soluce1) || getAngle(soluce2))
            isFinished = true;
        else
            isFinished = false;
    }

    private bool getAngle(Vector3 soluce)
    {
        if ( Mathf.Abs(Vector3.Angle(posTransform.right, transform.right) - soluce.x ) > maxAngle)
            return false;
        if (Mathf.Abs(Vector3.Angle(posTransform.up, transform.up) - soluce.y) > maxAngle)
            return false;
        if (Mathf.Abs(Vector3.Angle(posTransform.forward, transform.forward) - soluce.z) > maxAngle)
            return false;
        return true;
    }

    private void printAngle()
    {
        //Debug.Log(gameObject.name);
        //Debug.Log("right : " + Vector3.Angle(posTransform.right, transform.right));
        //Debug.Log("forward : " + Vector3.Angle(posTransform.forward, transform.forward));
        //Debug.Log("up : " + Vector3.Angle(posTransform.up, transform.up));
    }
}
