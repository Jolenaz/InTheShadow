using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {

    private enum type{
        nav,
        game,
        map
    }

    [SerializeField]
	private AudioClip clickSound;


    [SerializeField]
    private SceneManager _sc;

    [SerializeField]
    private string _trigger;

	private AudioSource audio;
	private Animator anime;

    [SerializeField]
    private type _type;

    [SerializeField]
    private int value;

	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource>();
		anime = GetComponent<Animator> ();
		audio.clip = clickSound;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void isClicked()
	{
		audio.Play();
		anime.SetTrigger ("click");
	}

    public void animation_finised()
    {
        _sc.GetComponent<Animator>().SetTrigger(_trigger);
        if (_type == type.game)
        {
            _sc.gameMode = (SceneManager.GameMode)value;
        }
        else if (_type == type.map)
        {
            _sc.cur_map = value;   
        }
    }
}
