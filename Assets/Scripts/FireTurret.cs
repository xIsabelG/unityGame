using UnityEngine;
using System.Collections;

public class FireTurret : MonoBehaviour {
	public GameObject bullet;
	private PlaySound soundScript;
	private Light flash;
	private float startIntensity;
	[SerializeField]
	private int coolDownFrames = 100;
	private int coolDown;

    [SerializeField]
    private int AI;//0 player, 1 distance
    [SerializeField]
    private Transform AItarget;
    [SerializeField]
    private float attackDistance;
	// Use this for initialization
	void Start () {
		coolDown = coolDownFrames;
		soundScript = this.gameObject.GetComponent<PlaySound>();
		flash = this.gameObject.GetComponent<Light>();
		if(flash!=null)startIntensity = flash.intensity;


        if (AI == 1 && AItarget == null) print("No AI target referenced for selected AI");
	}
    private void HandlePlayerShot() 
    {
        if (Input.GetMouseButtonDown(0) && coolDown == 0)
        {
            Shoot();
        }    
    }
    private void HandleDistanceAI() 
    {

        float dist = Vector3.Distance(transform.position, AItarget.transform.position);
        if (dist < attackDistance && coolDown == 0) 
        {
            Shoot();        
        }    
    }
    private void Shoot() 
    {
        coolDown = coolDownFrames;
        GameObject b = GameObject.Instantiate(bullet) as GameObject;
        b.transform.position = transform.position;
        b.transform.rotation = transform.rotation;
        b.GetComponent<ParticleSystem>().Play();

        if (soundScript != null) soundScript.PlayRandomSound();

        if (flash != null)
        {
            flash.intensity = startIntensity;
            flash.enabled = true;
        }
        else
        {
            print("Add Light Component");
        }
    }
	// Update is called once per frame
	void Update () {
		if(coolDown > 0)coolDown--;

        switch(AI)
        {
            case 0:
                HandlePlayerShot();
                break;
            case 1:
                if(AItarget!=null)HandleDistanceAI();
                break;
        }
        if (flash.enabled)
        {
            flash.intensity -= 0.2f;
            if (flash.intensity <= 0)
            {
                flash.enabled = false;
            }
        }

		
	}
}
