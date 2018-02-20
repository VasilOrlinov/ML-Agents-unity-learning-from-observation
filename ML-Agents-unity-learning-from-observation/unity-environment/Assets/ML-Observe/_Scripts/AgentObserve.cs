using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AgentObserve : Agent
{
    public GameObject cube, sphere;
    public Text text1, text2, text3, text4, text5, text6;
    private int n1, n2, n3, n4, n5, n6 ;
    private float rand;

    public override List<float> CollectState()
    {
        List<float> state = new List<float>();

        return state;
    }

    public override void AgentStep(float[] act)
    {
        if (act[0] == 0)
        {
            if (cube.transform.position.x == -1)
            {
                reward = 0.2f;
                done = true;

                n3++;
                text3.text = "Guessed Left  " + n3.ToString();
            }
            else
            {
                reward = -0.1f;

                n5++;
                text5.text = "Not Guessed Left  " + n5.ToString();
            }
            n1++;
            text1.text = "Choose Left  " + n1.ToString();
        } else
        if (act[0] == 1)
        {
            if (cube.transform.position.x == 1)
            {
                reward = 0.2f;
                done = true;

                n4++;
                text4.text = "Guessed Right  " + n4.ToString();
            }
            else
            {
                reward = -0.1f;

                n6++;
                text6.text = "Not Guessed Right  " + n6.ToString();
            }
            n2++;
            text2.text = "Choose Right  " + n2.ToString();
        }
    }

    public override void AgentReset()
    {

        rand = Random.Range(0f, 1f);
        Debug.Log(rand);
        if (rand < 0.5f)
        {
            cube.transform.position = new Vector3(-1, 0, 0);
            sphere.transform.position = new Vector3(1, 0, 0);
        }
        else if (rand >= 0.5f)
        {
            cube.transform.position = new Vector3(1, 0, 0);
            sphere.transform.position = new Vector3(-1, 0, 0);
        }

    }
    public override void AgentOnDone()
    {
    }


}
