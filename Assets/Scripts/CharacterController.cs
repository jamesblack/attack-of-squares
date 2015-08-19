using UnityEngine;
using System.Collections;

public class CharacterController : MonoBehaviour {

	public float MoveSpeed = 1.0f;

	public Shooter Shooter;


	// Use this for initialization
	void Start () {
		Shooter = GetComponent<Shooter> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown (0)) {
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast(ray, out hit)) {
				if (hit.transform.tag != "Moveable") return;

				StopCoroutine("MoveTo");
				StartCoroutine("MoveTo", hit.point);			
			}
		}
	}
	
	IEnumerator MoveTo(Vector3 targetPosition) {


		while ((transform.position.x != targetPosition.x) && (transform.position.z != targetPosition.z)) {
			if (Shooter.Target == Vector3.zero) transform.LookAt (new Vector3(targetPosition.x, transform.position.y, targetPosition.z));
			transform.position = Vector3.MoveTowards(transform.position, new Vector3(targetPosition.x, transform.position.y, targetPosition.z), MoveSpeed * Time.deltaTime);
			yield return true;
		}
	}


}
