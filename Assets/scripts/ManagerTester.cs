using UnityEngine;
using System.Collections;

public class ManagerTester : MonoBehaviour
{
    QStateMachine fsm = new QStateMachine();
    [ContextMenu("Start")]
    void Start()
    {
        fsm.addState("first", null);
        fsm.addState("second", "first");

        fsm.getState("first").dv_stateFunctions += firstFunction;
        fsm.getState("second").dv_stateFunctions += secondFunction;

    }

    // Update is called once per frame
    [ContextMenu("TestFirst")]
    public void testFirst()
    {
        fsm.changeState("first");
    }
    [ContextMenu("TestSecond")]
    public void testSecond()
    {
        fsm.changeState("second");
    }


    void firstFunction()
    {
        print("State One: On");
    }
    void secondFunction()
    {
        print("State Two: On");
    }

}
