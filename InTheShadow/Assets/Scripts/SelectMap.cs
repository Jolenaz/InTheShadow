using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectMap : MonoBehaviour {


    [SerializeField]
    private SceneManager _sc;


    [SerializeField]
    private List<GameObject> _buttons = new List<GameObject>();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnEnable()
	{
        for (int i = 0; i < _buttons.Count; i++)
        {
            if (i < _sc.unlocked_map)
            {
                _buttons[i].SetActive(true);
                _buttons[i].transform.localScale = 10.0f * _buttons[i].transform.localScale;
            }
            else if (i > _sc.unlocked_map)
            {
                _buttons[i].SetActive(false);
            }
            else
            {
                _buttons[i].SetActive(true);

            }
        }
	}

}
