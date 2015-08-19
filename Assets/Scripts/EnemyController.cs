using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	public Transform Player;
	public float Speed;
	public bool Alive;

	// Use this for initialization
	void Start () {
		Alive = true;
		StartCoroutine ("ChasePlayer");

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator ChasePlayer() {

		while (Alive) {
			transform.position = Vector3.MoveTowards(transform.position, new Vector3(Player.position.x, transform.position.y, Player.position.z), Speed * Time.deltaTime);
			yield return true;
		}
	}
}
