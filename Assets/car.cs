using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class car : MonoBehaviour {
    const float ACCELERATION = 0.05f;//加速度
    const float DECELERATION = -0.005f;//減速度
    const float MAX_SPEED = 0.5f;//マックススピード
    const float MAX_BACK_SPEED = -0.3f;//バック時のマックススピード
    const float ROT_SPEED = 1f;//回転スピード
    
    Rigidbody rb;
    float speed;//車のスピード
    float backspeed; 
    float rotspeed;
    Vector3 move;

    // Use this for initialization
    void Start() {
        speed = 0;
        move = Vector3.zero;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {

        //上キーが押されたときかつ、車のスピードがマックススピードより遅かったら
        if (Input.GetKey(KeyCode.UpArrow))  {
            if (speed < MAX_SPEED) {
                speed += ACCELERATION;
            }
        }
        else {//上キーが押されていなかったら減速していく
            if (speed > 0) {
                speed += DECELERATION;
            }
            else {
                speed = 0;
            }
        }

        //上キーと同様
        if (Input.GetKey(KeyCode.DownArrow)){
            if (backspeed > MAX_BACK_SPEED) {
                backspeed += DECELERATION;
            }
        }
        else {
            if (backspeed < 0){
                backspeed += ACCELERATION;
            }
            else {
                backspeed = 0;
            }
        }

        move = transform.right * speed;//青軸にスピードを掛けている
        rb.MovePosition(rb.position + move);//計算して出したスピード

        if (Input.GetKey(KeyCode.RightArrow)) {
            Quaternion turnRotation = Quaternion.Euler(0f, ROT_SPEED, 0f);
            rb.MoveRotation(rb.rotation * turnRotation);
        }

        if (Input.GetKey(KeyCode.LeftArrow)) {
            Quaternion turnRotation = Quaternion.Euler(0f, -ROT_SPEED, 0f);
            rb.MoveRotation(rb.rotation * turnRotation);
        }
    }
}
