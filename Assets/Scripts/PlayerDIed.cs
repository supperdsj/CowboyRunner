using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDied : MonoBehaviour {
    public delegate void EndGame();

    public static event EndGame endGame;

    void PlayerDiedEndgame() {
        if (endGame != null) {
            endGame();
        }
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D target) {
        if (target.tag == "Collector") {
            PlayerDiedEndgame();
        }
    }

    void OnCollisionEnter2D(Collision2D target) {

        if (target.gameObject.tag == "Zombie") {
            PlayerDiedEndgame();
        }
    }
}
