using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    

    public float speed;

    public bool live;

    
    void Start()
    {
       

        StartCoroutine(UpdatePos());
    }

    IEnumerator UpdatePos()
    {
        while (live)
        {
            transform.position += transform.forward * speed;
            yield return null;
        }

        print("Detonated");

        Destroy(gameObject);

    }

}
