using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platformspawn : MonoBehaviour {
    public float maxLeft = -4.5f;
    public float maxRight = 4.5f;

    public float randomPlatDist = 2f;
    public float PlatDist = 1.2f;
    public float desiredDist = 7f;

    private float playerHighestPos = 0;
    private float latestPlatHeight = 0;


    private GameObject player;

    private List<GameObject> blockList = new List<GameObject>();


    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        
        createPlatform(4f);
	}
	
	// Update is called once per frame
	void Update () {
       

        if (player.transform.position.y > playerHighestPos)
        {
            playerHighestPos = player.transform.position.y;
        }

        if(playerHighestPos > latestPlatHeight - desiredDist)
        {

            createPlatform(latestPlatHeight + PlatDist);
        }
		
	}

   private void deletePlatform(float block)
    {
        
    }

    private void createPlatform(float height)
    {
        float x = Random.Range(maxLeft, maxRight);
        float y = Random.Range(-randomPlatDist, +randomPlatDist);
        GameObject enemyInstance = Instantiate(Resources.Load("block", typeof(GameObject))) as GameObject;
        enemyInstance.transform.Translate(new Vector3(x, height + y, 0));
        enemyInstance.transform.parent = transform;

        latestPlatHeight = height;

        Destroy(enemyInstance, 10f);
        
    }
}
