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

    public bool isCongrat = false;

    [SerializeField]
    private CameraManager _camera;

    [SerializeField]
    private GameObject _menuScene;

    [SerializeField]
    private List<Scene> _scenes = new List<Scene>();

    public GameMode gameMode = GameMode.gm_new;

    public int unlocked_map;

    public int get_unlocked_map()
    {
        if (gameMode == GameMode.gm_continue)
            return unlocked_map;
        else if (gameMode == GameMode.gm_new)
        {
            set_unlocked_map(0);
            return 0;
        }
        return _available_map.Count;
    }

    public void set_unlocked_map(int value)
    {
        unlocked_map = value;
        PlayerPrefs.SetInt("unlocked_map", value);
    }

    public void SetMenu(){
        isMenu = !isMenu;
        _menuScene.SetActive(isMenu);
    }

    [HideInInspector]
    public int  cur_map;

	[SerializeField]
    private List<GameObject> _available_map = new List<GameObject>();

	// Use this for initialization
	void Start () {
        if (PlayerPrefs.HasKey("unlocked_map"))
            unlocked_map = PlayerPrefs.GetInt("unlocked_map");
        else
            set_unlocked_map(0);
	}

	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape) && !isCongrat)
            SetMenu();
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

    public void QuitGamet()
    {
        Application.Quit();
    }

}
