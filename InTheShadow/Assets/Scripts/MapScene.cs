using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapScene : MonoBehaviour {


    [SerializeField]
    private spotInput spot;

	// Use this for initialization
	void Start () {
		
	}

    private void OnEnable()
    {
        spot.isMovable = false;
    }

    private void OnDisable()
    {
        spot.isMovable = true;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
