using UnityEngine;
using System.Collections;

public class TurnTurret : MonoBehaviour {
	public Camera camera;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		//Vector3 worldPos = camera.ScreenToWorldPoint(Input.mousePosition);
		Vector3 mousePos = Input.mousePosition;
		mousePos.z = camera.transform.position.y-1.5f;
		Vector3 worldPos = camera.ScreenToWorldPoint( mousePos);

		transform.LookAt(worldPos);
	}
}
