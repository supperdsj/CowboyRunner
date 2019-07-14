using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationScript : MonoBehaviour {
    Animator anim;

    void Awake() {
        anim = GetComponent<Animator>();
    }

    void OnCollisionEnter2D(Collision2D target) {
        if (target.gameObject.tag == "Obstacle") {
            anim.Play("Idle");
        }
    }

    void OnCollisionExit2D(Collision2D target) {
        if (target.gameObject.tag == "Obstacle") {
            anim.Play("Run");
        }
    }
}
