using UnityEngine;
using System.Collections;
using static EnemyStates;

public class AltEnemyController : MonoBehaviour
{
    public EnemyState state;
    public float movementSpeed;
    public float health = 10;
    public float minDistance = 2.5f;
    [SerializeField] private GameObject player;
    private GameObject lightbulb;
    private ErrorMessageScript gameLogic;
    private float radius = 5f;
    private float damageScale = 0.1f;
    public GameObject smoke;
    public GameObject sparks;
    private Animator anim;

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player");
        lightbulb = GameObject.Find("Point light");
        gameLogic = GameObject.Find("GameLogic").GetComponent<ErrorMessageScript>();
        anim = GetComponentInChildren<Animator>();
        transform.LookAt(player.transform);
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetInteger("State", (int)state);
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
            state = EnemyState.Die;
        }
        if (dist <= minDistance && state != EnemyState.Die)
        {
            state = EnemyState.Attack;
        }
    }

    void Kill()
    {
        Quaternion rotation = Quaternion.Euler(transform.rotation.x - 90, transform.rotation.y, transform.position.z);
        GameObject smokeClone = (GameObject)Instantiate(smoke, transform.position, rotation);
        Destroy(gameObject);
    }

    void Attack()
    {
        GameObject sparksClone = (GameObject)Instantiate(sparks, transform.position, transform.rotation);
        gameLogic.UpdateText();
        state = EnemyState.Die;
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
