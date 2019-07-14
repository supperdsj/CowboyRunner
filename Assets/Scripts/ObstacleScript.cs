using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ObstacleScript : MonoBehaviour {
    float speed = -4f;
    Rigidbody2D myBody;

    void Awake() {
        myBody = GetComponent<Rigidbody2D>();
    }

    void Update() {
        myBody.velocity=new Vector2(speed,0);
    }
}
