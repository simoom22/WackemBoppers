using UnityEngine;
using System.Collections.Generic;
using System;

public class Main : MonoBehaviour {
	
	public static Main instance;
	public GameObject playerPrefab;
	public GameObject targetPrefab;
	
	
	void Awake () {
		if (instance != null) {
			throw new Exception("Attempted to create more than one instance of Main");
		}
		instance = this;
	}
	
	// Use this for initialization
	void Start () {
//		if (playerPrefab != null) {
//			GameObject.Instantiate(playerPrefab);
//		}
//		if (targetPrefab != null) {
//			GameObject.Instantiate(targetPrefab);
//		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public static Main Get() {
		return instance;
	}
	
}
