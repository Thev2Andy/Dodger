using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour {

	public Rigidbody2D PlayerRB;
	public GameObject HitFX;
	public Vector2 DeathLinearVelocity;
	public float DeathAngularVelocity;
	[HideInInspector] public bool IsDead;

	private void OnCollisionEnter2D(Collision2D c) {
		if(c.gameObject.CompareTag("Enemy")) {
			if(HitFX != null) Instantiate(HitFX, new Vector3(c.GetContact(0).point.x, c.GetContact(0).point.y, 0), Quaternion.identity);
			HitFX = null;
		}
	}

	private void Update()
	{
	   if(Input.GetKeyDown(KeyCode.R)) Die();

	   if(IsDead && this.transform.position.y <= -70f) Destroy(gameObject, 0.75f);
	}
	
	public void Die()
	{
		if(!IsDead)
		{
			if(PlayerRB.GetComponent<Movement>() != null)
			{
				Destroy(PlayerRB.GetComponent<Movement>());
			}

			IsDead = true;

			PlayerRB.gravityScale = 1f;
			PlayerRB.constraints = RigidbodyConstraints2D.None;
			PlayerRB.velocity += DeathLinearVelocity;
			PlayerRB.angularVelocity += DeathAngularVelocity;

			UIController.Instance.DeathUI();

			Destroy(EnemySpawner.Instance);
		}
	}
}