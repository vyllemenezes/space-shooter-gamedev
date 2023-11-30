using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipControls : MonoBehaviour {

    public KeyCode moveUp = KeyCode.W;
    public KeyCode moveDown = KeyCode.S;
    public KeyCode moveLeft = KeyCode.A;
    public KeyCode moveRight = KeyCode.D;

    public float speed = 10.0f;
    public float boundY = 4.0f;
    public float boundX = 8.5f;

    public float initialPosX = 0.0f;
    public float initialPosY = -3.0f;

    private Rigidbody2D rb2d;

    void Start() {
        rb2d = GetComponent<Rigidbody2D>();
        Reset();
    }

    void Update() {
        var vel = rb2d.velocity;
        vel.y = GetSpeedVertical();
        vel.x = GetSpeedHorizontal();
        rb2d.velocity = vel;

        var pos = transform.position;
        pos.y = GetPositionVertical();
        pos.x = GetPositionHorizontal();
        transform.position = pos;
    }

    void Reset() {
        var pos = Vector2.zero;
        pos.x = initialPosX;
        pos.y = initialPosY;
        transform.position = pos;
    }

    private float GetSpeedVertical() {
        if (Input.GetKey(moveUp)) {
            return speed;
        } else if (Input.GetKey(moveDown)) {
            return -speed;
        } else {
            return 0.0f;
        }
    }

    private float GetSpeedHorizontal() {
        if (Input.GetKey(moveLeft)) {
            return -speed;
        } else if (Input.GetKey(moveRight)) {
            return speed;
        } else {
            return 0.0f;
        }
    }

    private float GetPositionVertical() {
        if (transform.position.y > boundY) {
            return boundY;
        } else if (transform.position.y < -boundY) {
            return -boundY;
        } else {
            return transform.position.y;
        }
    }

    private float GetPositionHorizontal() {
        if (transform.position.x > boundX) {
            return boundX;
        } else if (transform.position.x < -boundX) {
            return -boundX;
        } else {
            return transform.position.x;
        }
    }
}
