using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	public Rigidbody2D PlayerRB;
	public float Speed;
	
	// Private / Hidden variables.
	private float DistanceToMove;

	private void Update()
	{
		DistanceToMove = Input.GetAxisRaw("Horizontal") * Speed * Time.deltaTime * 1.5f;
		PlayerRB.velocity = new Vector2(DistanceToMove, 0f);
	}
}
