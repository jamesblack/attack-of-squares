using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

	public Vector3 Target;
	public float Range = 5f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		TargetNearest ();
		
		if (Target != Vector3.zero) transform.LookAt(Target);
	}

	void TargetNearest() {
		GameObject[] potentialTargets = GameObject.FindGameObjectsWithTag ("Enemy");
		
		GameObject target = null;
			
		for (var i = 0; i < potentialTargets.Length; i++) {
			if (Vector3.Distance(transform.position, potentialTargets[i].transform.position) > Range) continue;
			if (!target) target = potentialTargets[i];
			
			if (Vector3.Distance(transform.position, potentialTargets[i].transform.position) < Vector3.Distance(transform.position, target.transform.position)){
				target = potentialTargets[i];
			}
		}

		if (target) this.Target = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);
	}


}
