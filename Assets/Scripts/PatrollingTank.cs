using UnityEngine;
using System.Collections;

public class PatrollingTank : BaseTank {
    [SerializeField]
    private Transform target;
    [SerializeField]
    private float attackDistance;

    [SerializeField]
    private Transform rayCaster;
    private Transform rightRayCaster;
    private Transform leftRayCaster;

   
    [SerializeField]
    private float forwardRaycastLength = 10f;
    [SerializeField]
    private float sideRaycastLength = 5f;
    [SerializeField]
    private float sideRaycastAngle = 30f;

	// Use this for initialization
  	void Start () {
        onStart();  
        createRayCasters();
             
	}
    void createRayCasters() 
    {
        rightRayCaster = (Transform)Instantiate(rayCaster);
        rightRayCaster.parent = transform;
        rightRayCaster.position = transform.position + transform.forward * 4f + transform.right * 2f;
        rightRayCaster.Rotate(Vector3.up * sideRaycastAngle);

        leftRayCaster = (Transform)Instantiate(rayCaster);
        leftRayCaster.parent = transform;
        leftRayCaster.position = transform.position + transform.forward * 4f - transform.right * 2f;
        leftRayCaster.Rotate(-Vector3.up * sideRaycastAngle);



    }
	// Update is called once per frame
	void Update () {

       
        RaycastHit hit;
        bool collision = false;
        if (rightRayCaster != null && leftRayCaster != null)
        {
            float quickTurn = Mathf.Abs(rotationSpeed) * (speed / 8);
            Debug.DrawRay(rightRayCaster.position, rightRayCaster.forward * sideRaycastLength, Color.green);
            if (Physics.Raycast(rightRayCaster.position, rightRayCaster.forward, out hit, sideRaycastLength))
            {
                if (hit.collider.tag == "Wall" || hit.collider.tag == "Player")
                {
                    TurnTank(-quickTurn);
                    collision = true;
                }
            }
            Debug.DrawRay(leftRayCaster.position, leftRayCaster.forward * sideRaycastLength, Color.red);
            if (Physics.Raycast(leftRayCaster.position, leftRayCaster.forward, out hit, sideRaycastLength))
            {
                if (hit.collider.tag == "Wall" || hit.collider.tag == "Player")
                {
                    
                    TurnTank(quickTurn);
                    collision = true;
                }
            }
        }
        Debug.DrawRay(transform.position, transform.forward * forwardRaycastLength, Color.cyan);
        if (Physics.Raycast(transform.position, transform.forward, out hit, forwardRaycastLength))
        {
            if (hit.collider.tag == "Wall" || hit.collider.tag == "Player")
            {
                TurnTank(rotationSpeed);
                collision = true;
            }



        }
        if (!collision)
        {
            MoveTank(1);
        }
       
        
        if (target != null)
        {
            TurnTurret(target);

            float dist = Vector3.Distance(transform.position, target.position);
            if (dist < attackDistance && coolDown <= 0)
            {
                Shoot();
            }
            onUpdate();
        }
     
      
        
	}
}
