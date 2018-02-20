using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaskoWall : MonoBehaviour {
    public Agent agent;
    public Hero2 hero2;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            Debug.Log("enemy");
            agent.done = true;
            agent.reward = -1f;
            hero2.miniplatform.transform.localScale = hero2.miniplatform.transform.localScale / 1.1f;
            hero2.x = hero2.x - 0.1f;

        }
    }
}
