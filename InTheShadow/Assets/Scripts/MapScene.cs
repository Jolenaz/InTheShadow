
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapScene : MonoBehaviour {

    [SerializeField]
    private List<GameObject> _maps = new List<GameObject>();

    [SerializeField]
    private spotInput spot;

    [SerializeField]
    private SceneManager _sc;

	// Use this for initialization
	void Start () {
		
	}

    private void OnEnable()
    {
        spot.isMovable = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        _maps[_sc.cur_map].SetActive(true);
    }

    private void OnDisable()
    {
        spot.isMovable = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        _maps[_sc.cur_map].SetActive(false);
    }

    // Update is called once per frame
    void Update () {
        //if (!Cursor.visible){
        //    Cursor.lockState = CursorLockMode.None;
        //    Cursor.visible = true;
        //}

	}
}
