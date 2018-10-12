using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour {

    [SerializeField]
    private CameraManager _camera;


    [SerializeField]
    private List<Scene> _scenes = new List<Scene>();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void MoveCamera(int sc_index, bool active)
    {
        if (active)
        {
            _camera.transform.position = _scenes[sc_index]._camera_pos.transform.position;
            _camera.moveSpote();
            _scenes[sc_index].gameObject.SetActive(true);
        }
        else
        {
            _scenes[sc_index].gameObject.SetActive(false);

        }
        
    }

}
