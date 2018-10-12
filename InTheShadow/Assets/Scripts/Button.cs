using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {

    [SerializeField]
	private AudioClip clickSound;


    [SerializeField]
    private Animator _sc_Animator;

	private AudioSource audio;
	private Animator anime;



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
        _sc_Animator.SetTrigger("Selection");
    }
}
