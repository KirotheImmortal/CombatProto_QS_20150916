using UnityEngine;
using System.Collections;

public class Gravity : MonoBehaviour
{

   public float gpull;

    void OnTriggerStay(Collider c)
    {
        if (c.gameObject.GetComponent<Bullet>())
        {
           Vector3 bullet = c.gameObject.GetComponent<Transform>().forward;
           float distance = Vector3.Distance(transform.position, bullet);

            c.gameObject.GetComponent<Transform>().forward /= distance;
            print("somethinghappend");

        }

        

    }
    
}
