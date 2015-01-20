using UnityEngine;
using System.Collections;

public class SelfDestruct : MonoBehaviour {
    private ParticleSystem ps;
    private Light light;

	// Use this for initialization
	void Start () {
        ps = this.gameObject.GetComponent<ParticleSystem>();
        light = this.gameObject.GetComponent<Light>();

	}
	
	// Update is called once per frame
	void Update () {

        if(light.intensity>0)light.intensity -= 0.5f;
        if (ps.isStopped) Destroy(this.gameObject);
	}
}
