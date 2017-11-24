using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ErrorMessageScript : MonoBehaviour {
    private List<string> tables = new List<string> { "Error when parsing XML Stream", "Conversion from type 'DBNull' to type 'Integer' is not valid.","General Error" };
    private GameObject syncText;
    private float timeSinceChange = 0f;
    private int num = 0;
    // Use this for initialization
    void Start()
    {
        syncText = GameObject.FindGameObjectWithTag("ScoreText");
    }
    public void UpdateText()
    {
        syncText.GetComponent<Text>().text = tables[num] ;
        num = (num < tables.Count - 1) ? num + 1 : 0;
    }
}
