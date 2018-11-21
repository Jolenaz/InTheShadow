using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CongratScene : MonoBehaviour {

    [SerializeField]
    private AudioSource _as;

    [SerializeField]
    private SceneManager _sc;

	private void OnEnable()
	{
        _sc.isCongrat = true;
        _as.Play();
	}

	private void OnDisable()
	{
        _sc.isCongrat = false;
	}
}
