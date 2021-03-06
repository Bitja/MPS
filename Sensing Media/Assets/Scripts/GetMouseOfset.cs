﻿using UnityEngine;
using System.Collections;

public class GetMouseOfset : MonoBehaviour {

    private Vector3 offsetmousePosition;
    public float moveSpeed = 1.0f;
    private Vector3 mouseOffset;
	public bool offsetOn = false;


	public void toggleOffset(){
		if (offsetOn == false) {
			offsetOn = true;
			if(RightORLeft.isRightHand == true){
				mouseOffset = new Vector3(-60.0f, 0.0f, 0.0f);
				
			}
			else if(RightORLeft.isRightHand == false){
				mouseOffset = new Vector3(60.0f, 0.0f, 0.0f);		
			}
		} 
		else
			offsetOn = false;
	}

    void Update() {
		//Debug.Log (offsetOn);
		if (offsetOn == true) {
			if (Input.GetMouseButton (0)) {

				offsetmousePosition = (Input.mousePosition + mouseOffset);
				//Debug.Log (Input.mousePosition+ " : "+offsetmousePosition);
				offsetmousePosition = Camera.main.ScreenToWorldPoint (offsetmousePosition);
				transform.position = Vector2.Lerp (transform.position, offsetmousePosition, moveSpeed);

			}
		} 
		else {
			if (Input.GetMouseButton (0)){
				offsetmousePosition = Input.mousePosition;
				offsetmousePosition = Camera.main.ScreenToWorldPoint (offsetmousePosition);
				transform.position = Vector2.Lerp (transform.position, offsetmousePosition, moveSpeed);
			}
		}

	}
}
