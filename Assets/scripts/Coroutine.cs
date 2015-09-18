using UnityEngine;
using System.Collections;

public class Coroutine : MonoBehaviour
{
    public float smoothing = 1f;
    public Vector3 Target
    {
        get { return target; }
        set
        {
            target = value;

            StopCoroutine("Movement");
            StartCoroutine("Movement", target);
        }
    }

    private Vector3 target;
    IEnumerator Movement(Vector3 target)
    {

        while (Vector3.Distance(transform.position, target) > 0.05f && GetComponent<Stats>().currentFuel > 0)
        {
            transform.forward -= transform.forward - Vector3.Lerp(transform.forward, target - transform.position, smoothing * Time.deltaTime);
            transform.position = Vector3.Lerp(transform.position, target, smoothing * Time.deltaTime);

            GetComponent<Stats>().currentFuel--; //GetComponent<Stats>().maxFuel / GetComponent<Stats>().fuelEfficiency;
            print(GetComponent<Stats>().currentFuel);

            yield return null;
        }
    }
}
