using UnityEngine;
using System.Collections;

public class StaticTank : BaseTank {
    [SerializeField]
    private Transform target;
    [SerializeField]
    private float attackDistance = 50f;
	// Use this for initialization
	void Start () {
        onStart();
        if (target == null)print("No target referenced for static tank");
	}
	
	// Update is called once per frame
	void Update () {

       // MoveTank(1);
      
        if(target != null)
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
