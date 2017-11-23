using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnControl : MonoBehaviour {
    private List<GameObject> spawners = new List<GameObject>();
    public float spawnFrequency;
    private float timeSinceSpawn = 0;
    // Use this for initialization
    void Start () {
		foreach (Transform child in transform)
        {
            spawners.Add(child.gameObject);
        }
	}
	
	// Update is called once per frame
	void Update () {
        timeSinceSpawn += Time.deltaTime;
        if (timeSinceSpawn>=spawnFrequency)
        {
            int activeSpawner = Random.Range(0, spawners.Count);
            spawners[activeSpawner].GetComponent<SpawnControl>().SpawnEnemy();
            timeSinceSpawn = 0;
        }
            
	}
}
