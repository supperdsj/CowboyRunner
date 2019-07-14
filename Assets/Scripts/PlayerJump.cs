using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerJump : MonoBehaviour {
    [SerializeField] AudioClip jumpClip;
    // [SerializeField]
    float jumpForce = 12f, forwardForce = 0f;
    Rigidbody2D myBody;
    bool canJump;
    Button jumpButton;

    void Awake() {
        myBody = GetComponent<Rigidbody2D>();
        jumpButton = GameObject.Find("JumpButton").GetComponent<Button>();
        jumpButton.onClick.RemoveAllListeners();
        jumpButton.onClick.AddListener(()=>Jump());
    }

    void Update() {
        if (Mathf.Abs(myBody.velocity.y) == 0) {
            canJump = true;
        }
        else {
            if (transform.position.x < 0) {
                forwardForce = 1f;
            }
            else {
                forwardForce = 0f;
            }
            myBody.AddForce(new Vector2(forwardForce,0));
        }
    }

    public void Jump() {
        if (canJump) {
            canJump = false;
            // AudioSource.PlayClipAtPoint(jumpClip,transform.position);
            myBody.velocity=new Vector2(forwardForce,jumpForce);
        }
    }
}
