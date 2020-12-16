using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMov : MonoBehaviour

{
	Rigidbody enemyRB;
	public Transform prey;
	public float forceAmt = 2f;
	public float proximityAlert;
    // Start is called before the first frame update
    void Start()
    {
    	enemyRB = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 preyDir = Vector3.Normalize(prey.position - transform.position);

        if(Vector3.Distance(prey.position, transform.position) > proximityAlert)
        enemyRB.AddForce(preyDir * forceAmt);


    }
}
