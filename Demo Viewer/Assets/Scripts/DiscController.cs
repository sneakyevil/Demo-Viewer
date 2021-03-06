﻿/**
 * Zzenith 2020
 * Date: 19 April 2020
 * Purpose: Control Disc position and rotation
 */

using UnityEngine;

public class DiscController : MonoBehaviour
{
	//Sent 
	public Vector3 discPosition;
	public Quaternion discRotation;
	public Vector3 discVelocity;
	//public ArrayList isGrabbed = new ArrayList() { false, false, new int[2]{ -1, -1 } };
	//public GameObject playerHolding;

	public Transform child;
	private Transform rForeArm;
	private Transform lForeArm;



	// Update is called once per frame
	void Update()
	{

		//Todo- make this code work with new skeleton
		/*if((bool)isGrabbed[0])
        {
            if((bool)isGrabbed[1])
            {
                rForeArm = playerHolding.transform.GetChild(2).
                    transform.GetChild(0).
                    transform.GetChild(1).
                    transform.GetChild(1).
                    transform.GetChild(0).
                    transform.GetChild(0).
                    transform.GetChild(0).
                    transform;
                transform.rotation = rForeArm.rotation;
            }
            else
            {
                lForeArm = playerHolding.transform.GetChild(2).
                    transform.GetChild(0).
                    transform.GetChild(1).
                    transform.GetChild(1).
                    transform.GetChild(2).
                    transform.GetChild(0).
                    transform.GetChild(0).
                    transform;
                transform.rotation = lForeArm.rotation;
            }
        } else*/
		{
			if (discRotation != null)
			{
				transform.rotation = discRotation;
			}
			else
			{
				//Make it the right rotation (Mostly subjective)
				Vector3 upVector = new Vector3(19 - discVelocity.magnitude, discVelocity.magnitude, 0).normalized;
				transform.LookAt(discVelocity.normalized + transform.position, upVector);
			}
			//Make it spin based on speed
			child.Rotate(Vector3.up, 40 * discVelocity.magnitude * Time.deltaTime);
		}
		//set position
		transform.position = discPosition;
	}
}
