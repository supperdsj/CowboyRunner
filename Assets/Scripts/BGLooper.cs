using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGLooper : MonoBehaviour {
    public float speed = .1f;
    Vector2 offset=Vector2.zero;
    Material mat;

    void Start() {
        mat = GetComponent<Renderer>().material;
        offset = mat.GetTextureOffset("_MainTex");
    }

    void Update() {
        offset.x += speed * Time.deltaTime;
        mat.SetTextureOffset("_MainTex",offset);
    }
}
