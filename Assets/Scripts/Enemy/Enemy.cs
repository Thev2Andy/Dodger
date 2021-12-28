using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public GameObject HitFX;

	// Private / Hidden variables.
	private bool IsDead;

	private void OnCollisionEnter2D(Collision2D c)
	{
		if(c.gameObject.CompareTag("Player") && !IsDead)
		{
			if(c.gameObject.GetComponent<HealthSystem>() != null) c.gameObject.GetComponent<HealthSystem>().Die();
			if(c.gameObject.GetComponent<Rigidbody2D>() != null) {
				this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, Mathf.Abs(c.gameObject.GetComponent<Rigidbody2D>().velocity.y * 1.25f));
				this.GetComponent<Rigidbody2D>().angularVelocity = -35;
			}

			IsDead = true;

			if(HitFX != null) Instantiate(HitFX, new Vector3(c.GetContact(0).point.x, c.GetContact(0).point.y, 0), Quaternion.identity);
			HitFX = null;
		}

		if(c.gameObject.CompareTag("Bounds") && !IsDead) {
			Destroy(gameObject);
		}
	}

	private void Update() {
		if(this.transform.position.y <= -70f) Destroy(gameObject, 0.75f);
	}
}
