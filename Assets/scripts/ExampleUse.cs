using UnityEngine;
using System.Collections;

public class ExampleUse : MonoBehaviour
{

    bool play = true;
    void forceInvoke()
    {
        gameObject.GetComponent<StateManager>().InvokeStateshift();
    } //Quick hand function to call the InvokeStateShift() in the StateManager for this object
    void Start()
    {
        gameObject.GetComponent<StateManager>().initList  += forceInvoke; //Adds the forceInvoke to init delegate
        gameObject.GetComponent<StateManager>().startList += forceInvoke; //Adds the forceInvoke to start delegate
        gameObject.GetComponent<StateManager>().mainList  += Movement; //Adds Movement() to the main Delegate
    }
    void movement()
    {
        print("random bullshit");
    }
    void Movement()
    {
        StartCoroutine(Move());
    } //Starts the IEnumerator as a Coroutine

    IEnumerator Move()
    {
        while (play)
        {
            if (Input.GetKeyDown(KeyCode.W))
                transform.position += Vector3.forward;

            else if (Input.GetKeyDown(KeyCode.Space))
                play = false;

            yield return null;
        }
        forceInvoke();
    }



}
