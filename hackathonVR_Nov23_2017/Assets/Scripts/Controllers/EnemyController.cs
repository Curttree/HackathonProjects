using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EnemyStates;

public class EnemyController : MonoBehaviour {
    public EnemyState state;
    public float movementSpeed;
    public float health=10;
    private GameObject player;
    private float radius=200;
    private float damageScale=0.1f;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
        DetermineState();
        DamageCalculation();
	}

    void DetermineState()
    {
        switch (state)
        {
            case EnemyState.Move:
                transform.position -= transform.forward * Time.deltaTime * movementSpeed;
                break;
            case EnemyState.Die:
                Kill();
                break;
            case EnemyState.Attack:
                Attack();
                break;
            default:
                //Should never hit..stall and wait for a valid state.
                break;
        }
    }

    void DamageCalculation()
    {
        float dist = GetDistance(player);
        if (dist < radius)
        {
            health -= damageScale;
        }
        if (health <= 0)
        {
            state = EnemyState.Die;
        }
    }

    void Kill()
    {
        Destroy(gameObject);
    }

    void Attack()
    {

    }

    float GetDistance(GameObject other)
    {
        float dist = 0;
        if (other)
        {
            dist = Vector3.Distance(other.transform.position, transform.position);
        }
        return dist;
    }
}
