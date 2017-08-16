using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public Transform Spawnpoint;
    public GameObject Visitor;
    public Text VisitorCountText;
    int VisitorCount = 0;
    List<GameObject> Visitors = new List<GameObject>();

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        VisitorCountText.text = VisitorCount.ToString();
    }

    public void AddVisitor()
    {
        GameObject g = Instantiate(Visitor, Spawnpoint.position, Quaternion.identity);
        Visitors.Add(g);
        VisitorCount++;        
    }

    public void RemoveVisitor(GameObject g)
    {
        VisitorCount--;
        Visitors.Remove(g);
        Destroy(g);
    }
}
