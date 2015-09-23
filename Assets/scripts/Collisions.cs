using UnityEngine;
using System.Collections;

public class Collisions : MonoBehaviour
{
    bool canCollide = false;
	void OnTriggerEnter(Collider c)
    {
        if (canCollide)
        {
            print("Collision");
            if (c.gameObject/*.GetComponent<Coroutine_Bullet>()*/ != null)
            {
                Destroy(c.gameObject);
                gameObject.GetComponent<Stats>().health -= 25;
                canCollide = false;
            }
        }
    }
    void OnTriggerExit(Collider c)
    {
        canCollide = true;
    }
}
