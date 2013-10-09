using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	private Camera cam;
	private RuntimePlatform platform;
	private Rigidbody rb;
	private Transform trans;
	
	public int speed = 1;
	
	// Use this for initialization
	void Start () {
		cam = Camera.main;
		platform = Application.platform;
		Debug.Log(platform);
		trans = transform;
		rb = trans.rigidbody;
	}
	
	void FixedUpdate () {
		switch (platform) {
		case RuntimePlatform.Android:
			TouchControl();			
			break;
		default:
			MouseControl();
			break;
		}
	}
	
	private void MouseControl() {
		if (Input.GetMouseButton(1)) {
			MoveGuy(Input.mousePosition);
		}
	}
	
	private void TouchControl() {
		if (Input.touchCount > 0) {
			MoveGuy(Input.GetTouch(0).position);
		}
	}
	
	private void MoveGuy(Vector3 toPosition) {
		Ray inputRay = cam.ScreenPointToRay(toPosition);
		RaycastHit hit;
		if (Physics.Raycast(inputRay.origin, inputRay.direction, out hit)) {
			var dir = (hit.point - trans.position).normalized;
			//dir.y = trans.position.y;
			rb.AddForce(dir, ForceMode.Impulse);
		}
	}
}
