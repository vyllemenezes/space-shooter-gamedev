using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {
    
    public static float initialSpeed = 0.05f;
    public static float startPosY = 7.0f;

    public static float speed = 0.05f;
    public static Rigidbody2D rb2d;

    void Start() {
        rb2d = GetComponent<Rigidbody2D>();
        ResetPosition();

        Invoke("GoAsteroid", 1);
    }

    void LevelUp() {
        ResetPosition();
        BumpSpeed();
    }

    void OnCollisionEnter2D (Collision2D coll) {
        if(coll.collider.CompareTag("Player")) {
            Stop();
            ResetPosition();
            GameManager.Crash();
            
            Invoke("GoAsteroid", 1);
        }
    }

    private void GoAsteroid() {
        speed = initialSpeed;
        rb2d.AddForce(new Vector2(RandomSpeedX(1.5f), -speed));
    }

    private float RandomSpeedX(float baseSpeed) {
        float side = Random.Range(0, 2);
        float forceX = baseSpeed * Random.Range(5.5f, 10.5f);

        if (side < 1) {
            return -forceX;
        } else {
            return forceX;
        }
    }

    public static void ResetPosition() {
        Vector2 pos;
        pos.x = 0;
        pos.y = startPosY;
        rb2d.transform.position = pos;
    }

    public static void Stop() {
        rb2d.velocity = Vector2.zero;
    }

    private void BumpSpeed() {
        float bumpY = RandomSpeedX(0.02f);
        float bumpX = RandomSpeedX(0.2f);
        Debug.Log("bumpY: " + bumpY + "Speed: " + speed + " bumpX: " + bumpX + "velo: " + rb2d.velocity.x + "velo2: " + rb2d.velocity.y);
        rb2d.AddForce(new Vector2(bumpX, -bumpY));
    }
}
