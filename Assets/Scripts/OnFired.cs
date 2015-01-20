using UnityEngine;
using System.Collections;

public class OnFired : MonoBehaviour {
	[SerializeField]
	private int life = 10;
	// Use this for initialization

	void OnCollisionEnter(Collision collision)
	{
		GameObject b = collision.gameObject;
		if(b.tag == "Bullet")
		{
			//Destroy(b);
			life--;
			if(life==0)
			{
				Destroy(this.gameObject);
			}
		}
	
	}
}
