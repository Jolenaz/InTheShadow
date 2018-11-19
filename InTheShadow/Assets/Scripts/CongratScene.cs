using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CongratScene : MonoBehaviour {

    [SerializeField]
    private SceneManager _sc;

	private void OnEnable()
	{
        _sc.isCongrat = true;
	}

	private void OnDisable()
	{
        _sc.isCongrat = false;
	}
}
