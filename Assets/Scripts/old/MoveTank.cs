using UnityEngine;
using System.Collections;

public class MoveTank : MonoBehaviour {
	private float rSpeed = 90;
	[SerializeField]
	private float MaxSpeed = 30;
	private float mSpeed;

    private ParticleSystem exParticles;
	// Use this for initialization
	void Start () {
		mSpeed = 0;
        exParticles = this.gameObject.GetComponentInChildren<ParticleSystem>();
        
        
	}
	// Update is called once per frame
	void Update () {
		int horDirection = 0;
		int verDirection = 0;

		if(Input.GetKey(KeyCode.W))
		{
			verDirection = 1;
		}
		if(Input.GetKey(KeyCode.S))
		{
			verDirection = -1;
		}
		if(Input.GetKey(KeyCode.A))
		{
			horDirection = 1;
		}
		if(Input.GetKey(KeyCode.D))
		{
			horDirection = -1;
		}
		

        if(mSpeed > 0)mSpeed--;
		if(verDirection!=0 && mSpeed < MaxSpeed)mSpeed += 2;

        if (exParticles != null) HandleExhaust();
        transform.Translate(verDirection * Vector3.forward * mSpeed * Time.deltaTime);
        transform.Rotate(horDirection * -Vector3.up * rSpeed * Time.deltaTime);

	}

	void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.tag == "Wall")
		{
			mSpeed = 0;

		}
	
	}
    void HandleExhaust() 
    {
        exParticles.emissionRate = 8 + mSpeed;
        exParticles.startSize = 14 + mSpeed;
     
    }

}
