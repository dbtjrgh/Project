using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeParent : MonoBehaviour {
	private Transform[] cubes;

	public Color[] colors;
	public int[] xPositions;
	public float[] scales;
	
	private void Awake() {
		
		cubes = new Transform[transform.childCount];
		
		for (int i =0; i < transform.childCount; i++) {
			cubes[i] = transform.GetChild(i);
		} 

	}

	private void Start() {
		
		for(int i=0; i< cubes.Length; i++) {
			cubes[i].GetComponent<Renderer>().material.color = colors[i];

			Vector3 localPosition = cubes[i].localPosition;
			localPosition.x = xPositions[i];
			cubes[i].localPosition = localPosition;

			cubes[i].localScale = Vector3.one * scales[i];
		}

	}

}
