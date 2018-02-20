using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero2 : Agent
{
    private Rigidbody rigid;
    public float strenght = 100;
    public Transform enemy;
    public float x = 3.5f;
    public GameObject bullet;
    private float timer;
    public bool canShoot = true;
    public float enemyspeed;
    public GameObject miniplatform;

    public override List<float> CollectState()
    {
        List<float> state = new List<float>();

        Vector3 velocity = GetComponent<Rigidbody>().velocity;
        Vector3 velocityenemy = enemy.GetComponent<Rigidbody>().velocity;

        state.Add(transform.position.x);
        state.Add(transform.position.z);
        state.Add(transform.localPosition.x);
        state.Add(transform.localPosition.z);

        state.Add(enemy.position.z);
        state.Add(enemy.position.x);
        state.Add(enemy.localPosition.z);
        state.Add(enemy.localPosition.x);

        state.Add(velocity.x);
        state.Add(velocity.z);
        state.Add(velocityenemy.x);
        state.Add(velocityenemy.z);


        return state;
    }

    public override void AgentStep(float[] act)
    {
        reward = -0.01f;
        if (act[0] == 1)
        {
           rigid.velocity = (Vector3.left  * strenght);
        }
        if (act[0] == 2)
        {
            rigid.velocity = (Vector3.right * strenght);
        }
        if (act[0] == 3)
        {
            Shoot();
        }
        if (act[0] == 4)
        {
            rigid.velocity = Vector3.zero;
        }




    }
    public void Shoot()
    {
        if(canShoot == true)
        {
            Instantiate(bullet, transform.position, transform.rotation);
            canShoot = false;
            StartCoroutine(Timer());        }
    }
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(0.5f);
        canShoot = true;
        
    }
    public override void AgentReset()
    {
        GameObject[] bullets = GameObject.FindGameObjectsWithTag("Bullet");
        for (int i = 0; i < bullets.Length; i++)
        {
            Destroy(bullets[i].gameObject);
        }
        rigid = GetComponent<Rigidbody>();
        rigid.velocity = Vector3.zero;
        enemy.transform.localPosition = new Vector3(Random.Range(-x, x),0.5f, 8f);
        transform.localPosition = new Vector3(Random.Range(-x, x), 1f, -8f);
        enemy.GetComponent<Rigidbody>().velocity = -Vector3.forward * Time.deltaTime * enemyspeed;

    }
    public override void AgentOnDone()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Debug.Log("hitted ground");
            reward = -1;
            done = true;
            miniplatform.transform.localScale = miniplatform.transform.localScale / 0.1f;
            x = x - 0.1f;

        }

    }
    }
