using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    

    public float speed;
    public float MaxDistance;
    public float Damage;

    Vector3 startpos;

    public bool live;
    

    
    void Start()
    {
        updateLocation();

        StartCoroutine(UpdatePos());
    }

    public void updateLocation()
    {
       startpos = transform.position;
    }

    public float Hit()
    {
        live = false;
        return Damage;
    }


    void Expload()
    {
        Destroy(gameObject);
    }

    IEnumerator UpdatePos()
    {
        while (live)
        {
            transform.position += transform.forward * speed;

            if (Vector3.Distance(startpos, transform.position) > MaxDistance)
                live = false;

            yield return null;
        }

        print("Detonated");

        Expload();

    }

}
