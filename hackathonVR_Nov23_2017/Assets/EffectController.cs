using UnityEngine;

public class EffectController : MonoBehaviour {

	// Use this for initialization
	void Start () {
        KillTimer(3);
	}

    void KillTimer(float delay)
    {
        Destroy(gameObject, delay);
    }
}
