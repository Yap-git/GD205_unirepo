using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CycleMove : MonoBehaviour
{
	//Need to specify these variables for the Gas Indication
	public TextMeshProUGUI countText;
	private int count;

	Animator motorAnim;
    
    void Start()
    {
        motorAnim = GetComponent<Animator>();

        SetCountText();
        count = 0;
    }

    // Code here changes character animations through movestates
    void Update()
    {
        motorAnim.SetInteger("moveState", 0);
        if (Input.GetKey(KeyCode.W)){
        	motorAnim.SetInteger("moveState", 1);
        }
        if (Input.GetKey(KeyCode.Space)){
        	motorAnim.SetInteger("moveState", 2);
        }
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W)){
        	motorAnim.SetInteger("moveState", 3);
        }
        if (Input.GetKey(KeyCode.Q)){
        	motorAnim.SetInteger("moveState", 8);
        }
        if (Input.GetKey(KeyCode.E)){
        	motorAnim.SetInteger("moveState", 9);
        }
        if (Input.GetKey(KeyCode.D)){
        	motorAnim.SetInteger("moveState", 10);
        }
        if (Input.GetKey(KeyCode.A)){
        	motorAnim.SetInteger("moveState", 11);
        }
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.D)){
        	motorAnim.SetInteger("moveState", 12);
        }
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.A)){
        	motorAnim.SetInteger("moveState", 13);
        }
    }

    void SetCountText(){

    	//Code here sets up TMPro to be constantly updated to reflect amount of Canisters collected

    	countText.text = "Gas Collected: " + count.ToString();


    }

    private void OnTriggerEnter(Collider other){

    	// This Code is meant to detect whenever the player walks into an object
    	//that has a collider, and with CompareTag, we can find the exact object(s)
    	//without making a new variable

    	if (other.gameObject.CompareTag("GasCanister")){


    		other.gameObject.SetActive(false);
    		count = count + 1;

    		SetCountText();

    	}
    }
}
