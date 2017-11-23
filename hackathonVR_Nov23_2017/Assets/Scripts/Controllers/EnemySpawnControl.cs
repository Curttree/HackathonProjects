using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnControl : MonoBehaviour {
    private List<GameObject> spawners = new List<GameObject>();
	// Use this for initialization
	void Start () {
		foreach (Transform child in transform)
        {
            spawners.Add(child.gameObject);
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("space"))
            spawners[0].GetComponent<SpawnControl>().SpawnEnemy();
	}
}
