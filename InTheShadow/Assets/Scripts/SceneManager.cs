using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour {


    public enum GameMode{
        gm_new,
        gm_continue,
        gm_teser        
    }

    [SerializeField]
    private CameraManager _camera;


    [SerializeField]
    private List<Scene> _scenes = new List<Scene>();

    [HideInInspector]
    public GameMode gameMode;

    public int unlocked_map = 1;

    [HideInInspector]
    public int  cur_map;

	[SerializeField]
    private List<GameObject> _available_map = new List<GameObject>();

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
