using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    private Rigidbody rigid;
    public float speed = 50f;
    // Use this for initialization
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        rigid.velocity = -Vector3.forward * Time.deltaTime * speed;
    }
}
