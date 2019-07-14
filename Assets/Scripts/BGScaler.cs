using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class BGScaler : MonoBehaviour {
    void Start() {
        var height = Camera.main.orthographicSize * 2f;
        var width = height * Screen.width / Screen.height;
        switch (gameObject.name) {
            case "Background":
                transform.localScale = new Vector3(width, height, 0);
                transform.position=new Vector3(0,0,0);
                break;
            case "Ground":
                transform.localScale = new Vector3(width + 3, 5, 0);
                transform.position=new Vector3(0,-6,-1);
                break;
        }
    }
}
