using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    [SerializeField]
    Transform target;

    const float DISTANCE = 3f;//車との距離
    const float FOLLOWRATE =0.1f;
    Vector3 offset = new Vector3(-DISTANCE, -0.3f, 0.8f);//カメラの場所設定
    Vector3 lookDown = new Vector3(20f, -10f, 0f);//カメラの見る角度設定

    void Start(){
        transform.position = target.TransformPoint(offset);
        transform.LookAt(target, Vector3.up);
    }

    void Update(){
        Vector3 desiredPosition = target.TransformPoint(offset);
        Vector3 lerp = Vector3.Lerp(transform.position, desiredPosition, DISTANCE);
        Vector3 toTarget = target.position - lerp;
        toTarget *= DISTANCE;//大きさが1なので、距離分掛ける
        transform.position = target.position - toTarget;
        transform.LookAt(target, Vector3.up);
        transform.Rotate(lookDown);
        
    }
}