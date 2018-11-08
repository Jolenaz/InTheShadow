using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComplexMap : MonoBehaviour {

    public Map Obj1;
    public Map Obj2;

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
        {
            isFinished = true;
            Debug.Log("Dragon finished");
        }
        else
            isFinished = false;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(Obj1.transform.position - Obj2.transform.position );
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
}
