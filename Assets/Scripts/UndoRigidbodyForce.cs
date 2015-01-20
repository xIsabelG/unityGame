using UnityEngine;
using System.Collections;

public class UndoRigidbodyForce : MonoBehaviour {
	Rigidbody rb;
	// Use this for initialization
	void Start () {
		rb = this.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(rb.velocity != Vector3.zero)rb.velocity=Vector3.zero;
	}
}
