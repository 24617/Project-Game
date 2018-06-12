﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallaxing : MonoBehaviour {

    public Transform[] Backgrounds;
    private float[] parallaxScales;
    public float smoothing;

    private Vector3 previousCameraPosition;
	
	void Start () {
        previousCameraPosition = transform.position;

        parallaxScales = new float[Backgrounds.Length];
        for (int i = 0; i < parallaxScales.Length; i++)
        {
            parallaxScales[i] = Backgrounds[i].position.z * -1;
        }
    }
	
	
	void LateUpdate () {
		for (int i = 0;i < Backgrounds.Length; i++)
        {
            Vector3 parallax = (previousCameraPosition - transform.position) * (parallaxScales[i] / smoothing);

            Backgrounds[i].position = new Vector3(Backgrounds[i].position.x + parallax.x, Backgrounds[i].position.y + parallax.y, Backgrounds[i].position.z);
        }

        previousCameraPosition = transform.position;
    }
}
