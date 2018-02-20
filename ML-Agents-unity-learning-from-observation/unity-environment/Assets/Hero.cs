using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : Agent {
    private Rigidbody rigid;
    public float strenght =100;
    public Transform rewardcube;
    private float lastdist;
    private float x = 1.5f;
    public GameObject miniplatform;

    public override List<float> CollectState()
    {
        List<float> state = new List<float>();

        state.Add(transform.position.x);
        state.Add(transform.position.y);
        state.Add(transform.position.z);
        Vector3 velocity = GetComponent<Rigidbody>().velocity;
        state.Add(rewardcube.position.z);
        state.Add(rewardcube.position.x);
        state.Add(rewardcube.position.y);
        state.Add(Vector3.Distance(transform.position, rewardcube.position));
        state.Add(velocity.x);
        state.Add(velocity.y);
        state.Add(velocity.z);

        return state;
    }

    public override void AgentStep(float[] act)
    {
        reward = -0.01f;
        if(act[0] == 1)
        {
            rigid.AddForce(Vector3.left * strenght);
        }
        if (act[0] == 2)
        {
            rigid.AddForce(Vector3.right  * strenght);
        }
        if (act[0] == 3)
        {
            rigid.AddForce(Vector3.forward  * strenght);
        }
        if (act[0] == 4)
        {
            rigid.AddForce(Vector3.back * strenght);
        }

        if (act[0] == 5)
        {
            rigid.velocity = Vector3.zero;
        }


    }


    public override void AgentReset()
    {

        rigid = GetComponent<Rigidbody>();
        rigid.velocity = Vector3.zero;
        transform.localPosition = new Vector3(Random.Range(-x, x), 1f, Random.Range(-x, x));
        rewardcube.transform.localPosition = new Vector3(Random.Range(-x, x), 1f, Random.Range(-x, x));
    }
    public override void AgentOnDone()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            Debug.Log("hitted ground");
            reward = -1;
            done = true;
            miniplatform.transform.localScale = miniplatform.transform.localScale / 1.1f;
            x = x - 0.1f;

        }

        if (collision.gameObject.tag == "CubeReward")
        {
            reward = 1;
            done = true;
            Debug.Log("hitted cubereward");
            miniplatform.transform.localScale = miniplatform.transform.localScale * 1.1f;
            x = x + 0.1f;

        }
    }
}
