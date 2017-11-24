using System;
using UnityEngine;

public class LightController : MonoBehaviour {
    public float power=5f;
    public float maxPower = 15f;
    public float drain=0.01f;
    public float gain = 3f;
    public float gainScale = 1f;
    public float sensitivity = 5f;
    public float deteriorationPercent = 0.75f;
    public Vector3 previousPosition;
    private GameObject lightbulb;
    private GameObject cameraObj;

	// Use this for initialization
	void Start () {
        lightbulb = GameObject.Find("Point light");
        cameraObj = GameObject.Find("Main Camera");
        previousPosition = cameraObj.transform.forward;
	}
	
	// Update is called once per frame
	void Update () {
        GetHeadMovement();
        CalcPower();
        lightbulb.GetComponent<Light>().range = power;
	}

    void CalcPower()
    {
        power -= (power>0)?drain:0;
        power += (power<maxPower)?gain:0;
        Debug.Log("GAIN: " + gain + " POWER: " + power);
    }

    void GetHeadMovement()
    {
   
        float newGain = gainScale * Vector3.Distance(previousPosition, cameraObj.transform.forward);
        if (newGain <= sensitivity)
        {
            gain = newGain;
        }
        else
        {
            //Deteriorate the gain. Will need to implement better approach to handle non cycling head movement
            gain = gain * deteriorationPercent;
        }
        previousPosition= cameraObj.transform.forward;
    }
}
