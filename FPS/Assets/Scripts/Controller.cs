using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
	public Char charContr;

	private void FixedUpdate()
	{
		charContr.MoveUpdate();
	}
}
