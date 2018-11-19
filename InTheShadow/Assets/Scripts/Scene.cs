using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene : MonoBehaviour {


    public GameObject congratScene;

    public GameObject _camera_pos;

	private void OnEnable()
	{
        if (congratScene)
            congratScene.SetActive(false);
	}
}
