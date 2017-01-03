using UnityEngine;
using System.Collections;

public class ea : MonoBehaviour {
    public GameObject target;
    public GameObject npc;
    public int max;
    public int min;
    private Vector2 tran;
    float timeLeft;
    

	// Use this for initialization
	void Start () {
        target= GameObject.FindWithTag("Player");
        npc = GameObject.FindWithTag("NPC");
        tran = target.transform.position;
        timeLeft = 20.0f;


    }
	
	// Update is called once per frame
	void Update () {
        bool checkR = CheckRange();
        if (checkR)
        {
            return;
        }
        else
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                Application.Quit(); // should have an end game screen here, use quit as a sub for now
            }
        }
	
	}

    bool CheckRange()
    {
        if ((Vector2.Distance(npc.transform.position, target.transform.position)<max)&& (Vector2.Distance(npc.transform.position, target.transform.position) > min))
        {
            return true;
        }
        return false;
    }

   

}
