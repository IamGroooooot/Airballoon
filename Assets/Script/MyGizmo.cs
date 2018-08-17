using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyGizmo : MonoBehaviour {

	public Color _color = Color.yellow;
	public float _radius = 0.1f;

	void OnDrawGizmos()
	{
		//기즈모색 설정
		Gizmos.color = _color;
		//구체 모양의 기즈모생성
		Gizmos.DrawSphere(transform.position, _radius);
	}
}
