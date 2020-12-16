using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaucerMot : MonoBehaviour
{
	Rigidbody rb;
	Vector3 fwd, bwd, lft, rgt, up, dwn;
	public float thrustAmt;
    // Start is called before the first frame update
    void Start()
    {
    	rb = GetComponent<Rigidbody>();
    	fwd = new Vector3(0f,0f,1f);
    	bwd = new Vector3(0f,0f,-1f);
    	lft = new Vector3(-1f,0f,0f);
    	rgt = new Vector3(1f,0f,0f);
    	up = new Vector3(0f,1f,0f);
    	dwn = new Vector3(0f,-1f,0f);
        
    }

    // Update is called once per frame
    void Update()
    {
    if(Input.GetKey(KeyCode.W)){
        rb.AddForce(fwd * thrustAmt);
    }
    if(Input.GetKey(KeyCode.S)){
        rb.AddForce(bwd * thrustAmt);
    }
    if(Input.GetKey(KeyCode.A)){
        rb.AddForce(lft * thrustAmt);
    }
    if(Input.GetKey(KeyCode.D)){
        rb.AddForce(rgt * thrustAmt);
    }
    if(Input.GetKey(KeyCode.E)){
        rb.AddForce(up * thrustAmt);
    }
    if(Input.GetKey(KeyCode.Q)){
        rb.AddForce(dwn * thrustAmt);
    }
    if(Input.GetKey(KeyCode.Space)){
        rb.velocity *= 0.95f;
    }
}

 void OnCollisionEnter(Collision myCol){
        Debug.Log("You have hit" + myCol.gameObject.name);
 }
}
