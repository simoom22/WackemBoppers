using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	private Transform trans;
	private Rigidbody rb;
	public int speed = 1;
	
	//control stuff- platform detection
	
	// Use this for initialization
	void Start () {
		trans = transform;
		rb = trans.rigidbody;
	}
	
	// Update is called once per frame
	void Update () {
		
		
	}
	
	void FixedUpdate () {
		//directed movement - mouse only
		var cam = Camera.main;
		if (Input.GetMouseButton(1)) {
			Ray inputRay = cam.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(inputRay.origin, inputRay.direction, out hit)) {
				var dir = (hit.point - trans.position).normalized;
				//dir.y = trans.position.y;
				rb.AddForce(dir, ForceMode.Impulse);
				
//				var point = hit.point;
//				point.y = 1;
//				var step = speed * Time.deltaTime;
//				trans.position = Vector3.Lerp(trans.position, point, step);
			}
		}
	}
}
