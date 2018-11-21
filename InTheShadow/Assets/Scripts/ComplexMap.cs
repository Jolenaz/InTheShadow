using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComplexMap : MonoBehaviour {

    public Map Obj1;
    public Map Obj2;

    [SerializeField]
    private SceneManager _sc;

    [SerializeField]
    private GameObject _congratMap;

    [SerializeField]
    private int map_id;

    public Vector3 objectif;

    public float maxDistance;

    public bool isFinished;

	// Use this for initialization
	void Start () {
        isFinished = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (getDistance() && Obj1.isFinished && Obj2.isFinished)
            finisedMap();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            finisedMap();
        }
	}

    bool getDistance()
    {
        if (Mathf.Abs(Obj1.transform.position.x - Obj2.transform.position.x - objectif.x) > maxDistance)
            return false;
        if (Mathf.Abs(Obj1.transform.position.y - Obj2.transform.position.y - objectif.y) > maxDistance)
            return false;
        if (Mathf.Abs(Obj1.transform.position.z - Obj2.transform.position.z - objectif.z) > maxDistance)
            return false;
        return true;
    }

    public void finisedMap()
    {
        isFinished = true;
        _sc.set_unlocked_map(map_id + 1);
        _congratMap.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Obj1.closeMap();
        Obj2.closeMap();
    }
}
