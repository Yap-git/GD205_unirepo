using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour

{
	public float laserPwr = 150f;

	//This Code is for the Enemies, I make a private integer here to keep track
	//of the player's bodycount behind the scenes, which would then be used
	//for secrets/extras within the game
	
	
	private int Kills;
    // Start is called before the first frame update
    void Start()
    {
        Kills = 0;

    }

    // Update is called once per frame
    void Update()
    {
    	if(Input.GetMouseButtonDown(0)){



        Ray damager = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit = new RaycastHit();

        if (Physics.Raycast(damager, out hit, 10000f)){
        	Debug.Log("Hit" + hit.transform.gameObject.name);
        } 
//Here, if the object we click on shares the tag of "Enemy", we remove Enemy and add a kill to the player
        if  (hit.transform.gameObject.CompareTag("Enemy")){
        	Destroy(hit.collider.gameObject);
        	Kills = Kills + 1;
        	}
        
        
        }

    }
}
