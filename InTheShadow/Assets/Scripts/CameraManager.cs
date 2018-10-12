using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {

    [SerializeField]
    private GameObject _spot;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void moveSpote()
    {
        _spot.transform.eulerAngles = new Vector3(-2,10,0);
    }

}
