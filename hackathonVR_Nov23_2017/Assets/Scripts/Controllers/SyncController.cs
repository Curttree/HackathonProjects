using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SyncController : MonoBehaviour {
    private List<string> tables = new List<string>{"Customers","Vendors","Items","Estimates","Invoices","PurchaseOrders","SalesOrders","SalesReceipts"};
    private GameObject syncText;
    private float timeSinceChange = 0f;
    private int num=0;
    // Use this for initialization
	void Start () {
        syncText = GameObject.FindGameObjectWithTag("SyncText");
        UpdateText();
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceChange += Time.deltaTime;
        if (timeSinceChange >= 5f)
        {
            timeSinceChange = 0f;
            UpdateText();
        }
    }
    void UpdateText()
    {
        syncText.GetComponent<Text>().text = "Checking server for changes in '" + tables[num] + "'...";
        num = (num < tables.Count - 1) ? num+1 : 0;
    }
}
