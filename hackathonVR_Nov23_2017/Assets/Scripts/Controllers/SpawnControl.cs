using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnControl : MonoBehaviour {

    public GameObject ghost;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SpawnEnemy()
    {
        GameObject ghostClone = (GameObject) Instantiate(ghost, transform.position, transform.rotation);
    }

}
