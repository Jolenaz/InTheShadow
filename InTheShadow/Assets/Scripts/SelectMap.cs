using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectMap : MonoBehaviour {


    [SerializeField]
    private AudioSource _as;

    [SerializeField]
    private SceneManager _sc;


    [SerializeField]
    private List<GameObject> _buttons = new List<GameObject>();


	void OnEnable()
	{
        if (_sc.get_unlocked_map() > 0)
            _as.Play();
        for (int i = 0; i < _buttons.Count; i++)
        {
            if (i < _sc.get_unlocked_map())
            {
                _buttons[i].SetActive(true);
                var bt = _buttons[i].GetComponent<Button>();
                bt.setMaterial("finished");
                bt.GetComponent<Animator>().SetTrigger("unlocked");
            }
            else if (i > _sc.get_unlocked_map())
            {
                _buttons[i].SetActive(false);
            }
            else
            {
                _buttons[i].SetActive(true);
                _buttons[i].GetComponent<Button>().setMaterial("normal");
            }
        }
	}

}
