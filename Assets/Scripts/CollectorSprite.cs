using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectorSprite : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D target) {
        if (target.tag == "Zombie" || target.tag == "Obstacle") {
            target.gameObject.SetActive(false);
        }
    }
}
