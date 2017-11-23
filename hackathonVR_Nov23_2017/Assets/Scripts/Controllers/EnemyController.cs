using UnityEngine;
using static EnemyStates;

public class EnemyController : MonoBehaviour {
    public EnemyState state;
    public float movementSpeed;
    public float health=10;
    public float minDistance = 2.5f;
    [SerializeField] private GameObject player;
    private GameObject lightbulb;
    private ScoreController gameLogic;
    private float radius=5f;
    private float damageScale=0.1f;

    // Use this for initialization
    void Start () {
        player = GameObject.Find("Player");
        lightbulb = GameObject.Find("Point light");
        gameLogic = GameObject.Find("GameLogic").GetComponent<ScoreController>();
        transform.LookAt(player.transform);
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
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
                transform.position += transform.forward * Time.deltaTime * movementSpeed;
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
        float dist = GetDistance(lightbulb);
        radius = lightbulb.GetComponent<Light>().range;
        if (dist < radius)
        {
            health -= damageScale;
        }
        if (health <= 0)
        {
            if (state != EnemyState.Die)
            {
                gameLogic.UpdateScore(100);
            }    
            state = EnemyState.Die;
            Debug.Log(state.ToString());
        }
        if (dist <= minDistance && state != EnemyState.Die)
        {
            state = EnemyState.Attack;
            Debug.Log(state.ToString());
        }
    }

    void Kill()
    {
        Destroy(gameObject);
    }

    void Attack()
    {
        gameLogic.UpdateScore(-500);
        state = EnemyState.Die;
        Debug.Log(state.ToString());
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
