using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {


	public float gravity;
	public Transform target;
	public float throwAngle = 45;

	public void Initialize()
	{

		StartCoroutine(SimulatePhisycs());
	}


	IEnumerator SimulatePhisycs()
    {
        yield return new WaitForSeconds(0.05f);
              
        float distanceToTarget = Vector3.Distance(transform.position, target.position);
        float molotovInitialSpeed = Mathf.Sqrt((gravity * distanceToTarget) / (Mathf.Sin(2 * throwAngle * Mathf.Deg2Rad)));
 

        float Vx = molotovInitialSpeed * Mathf.Cos(throwAngle * Mathf.Deg2Rad);
        float Vy = molotovInitialSpeed * Mathf.Sin(throwAngle * Mathf.Deg2Rad);
 
        float flightTime = distanceToTarget / Vx;
   
        transform.rotation = Quaternion.LookRotation(target.position - transform.position);
       
        float timeFlying = 0;
 
        while (timeFlying < flightTime)
        {
            transform.Translate(0, (Vy - (gravity * timeFlying)) * Time.deltaTime, Vx * Time.deltaTime);
           
            timeFlying += Time.deltaTime;
 
            yield return null;
        }
    }  

}
