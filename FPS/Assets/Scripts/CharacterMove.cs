using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour {

	public Animator anim;

	public float vertical;
	public float horizontal;
	public float moveAmount;

	public void MoveUpdate()
	{
		vertical = Input.GetAxis("Vertical");
		horizontal = Input.GetAxis("Horizontal");
		moveAmount = Mathf.Clamp01(Mathf.Abs(vertical) + Mathf.Abs(horizontal));
		
		anim.SetFloat("vertical",vertical,0.15f, Time.deltaTime);
	}
}
