 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{


    public enum GameMode
    {
        gm_continue,
        gm_new,
        gm_teser
    }

    public bool isMenu = false;

    [SerializeField]
    private CameraManager _camera;

    [SerializeField]
    private GameObject _menuScene;

    [SerializeField]
    private List<Scene> _scenes = new List<Scene>();

    public GameMode gameMode = GameMode.gm_new;

    public int unlocked_map = 1;

    public int get_unlocked_map()
    {
        if (gameMode == GameMode.gm_continue)
            return unlocked_map;
        else if (gameMode == GameMode.gm_new)
            return 0;
        return _available_map.Count;
    }

    public void SetMenu(bool state){
        _menuScene.SetActive(state);
    }

    [HideInInspector]
    public int  cur_map;

	[SerializeField]
    private List<GameObject> _available_map = new List<GameObject>();

	// Use this for initialization
	void Start () {
        unlocked_map = 1;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
            SetMenu(true);
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
