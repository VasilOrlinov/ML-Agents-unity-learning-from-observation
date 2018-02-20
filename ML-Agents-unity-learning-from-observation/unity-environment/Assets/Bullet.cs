using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    private Rigidbody rigid;
    public float speed = 100f;
    public Agent agent;
    public Hero2 hero2;
	// Use this for initialization
	void Start () {
        rigid = GetComponent<Rigidbody>();
        rigid.velocity = Vector3.forward*Time.deltaTime*speed;
        Destroy(gameObject, 10f);
    }

    private void OnTriggerEnter(Collider other)
    {
        Agent agent = GameObject.Find("Agent").GetComponent<Hero2>();
        hero2 = GameObject.Find("Agent").GetComponent<Hero2>();
        if (other.tag == "Enemy")
        {
            agent.reward = 1f;
            agent.done = true;
            hero2.miniplatform.transform.localScale = hero2.miniplatform.transform.localScale * 1.1f;
            hero2.x = hero2.x + 0.1f;

        }
    }
}
