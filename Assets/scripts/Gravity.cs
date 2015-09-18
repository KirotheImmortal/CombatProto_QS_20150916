using UnityEngine;
using System.Collections;

public class Gravity : MonoBehaviour
{

    public float gpull;
   // float angleOfEntry;

    void OnTriggerStay(Collider c)
    {
        if (c.gameObject.GetComponent<Bullet>())
        {
           Vector3 center = transform.position;
           Vector3 bullet = c.gameObject.GetComponent<Transform>().forward - center;
            
           float dis = Vector3.Distance(center, bullet);

           

            // // c.gameObject.GetComponent<Transform>().forward -= new Vector3((distance * gpull)/100, 0 , (distance * gpull)/100);
            // // print("somethinghappend");

            // float dis = Vector2.Distance(new Vector2(bullet.x,bullet.z), new Vector2(transform.position.x, transform.position.z));
             float Hyp = Mathf.Sqrt((dis * dis) + (dis * dis));
            float angleOfEntry = Mathf.Sin(Hyp/dis);

            

            bullet.x = (center.x + dis * Mathf.Sin(angleOfEntry));
            bullet.z = (center.z + dis * Mathf.Cos(angleOfEntry));
            //c.gameObject.GetComponent<Transform>().position = center + new Vector3(bullet.x  + (center.x + gpull), 0, bullet.z + (center.z + gpull));
            //c.gameObject.GetComponent<Transform>().forward += new Vector3(bullet.x, 0, bullet.z);

        }

        

    }
    
}
