using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScene : MonoBehaviour {

    [SerializeField]
    private SceneManager _sc;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnEnable()
    {
        _sc.isMenu = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void OnDisable()
    {
        _sc.isMenu = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
