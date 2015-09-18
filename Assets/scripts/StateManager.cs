using UnityEngine;
using System.Collections;
using UnityEngine.Events;


public class StateManager : MonoBehaviour
{
    public QStateMachine FSM = new QStateMachine();


    public GameObject NextPlayer;

    public string init = "INIT";
    public string start = "START";
    public string main = "MAIN";
    public string end = "END";

    /// <summary>
    /// Getter/Setter For the Delegates of init,start,main,end QStates created in the Start code
    /// </summary>
    public QStates.IEnumeratorFunctionList initIeFunc
    {
        get
        {
            return FSM.getState(init).die_stateFunctions;
        }
        set
        {
            FSM.getState(init).die_stateFunctions = value;
        }
    }
    /// <summary>
    /// Getter/Setter For the Delegates of init,start,main,end QStates created in the Start code
    /// </summary>
    public QStates.IEnumeratorFunctionList startIeFunc
    {
        get
        {
            return FSM.getState(start).die_stateFunctions;
        }
        set
        {
            FSM.getState(start).die_stateFunctions = value;
        }

    }
    /// <summary>
    /// Getter/Setter For the Delegates of init,start,main,end QStates created in the Start code
    /// </summary>
    public QStates.IEnumeratorFunctionList mainIeFunc
    {
        get
        {
            return FSM.getState(main).die_stateFunctions;
        }
        set
        {
            FSM.getState(main).die_stateFunctions = value;
        }
    }
    /// <summary>
    /// Getter/Setter For the Delegates of init,start,main,end QStates created in the Start code
    /// </summary>
    public QStates.IEnumeratorFunctionList endIeFunc
    {
        get
        {
            return FSM.getState(end).die_stateFunctions;
        }
        set
        {
            FSM.getState(end).die_stateFunctions = value;
        }
    }

    /// <summary>
    /// Getter/Setter For the Delegates of init,start,main,end QStates created in the Start code
    /// </summary>
    public QStates.VoidFunctionList initVfunc
    {
        get
        {
            return FSM.getState(init).dv_stateFunctions;

        }
        set
        {
            FSM.getState(init).dv_stateFunctions = value;

        }
    }
    /// <summary>
    /// Getter/Setter For the Delegates of init,start,main,end QStates created in the Start code
    /// </summary>
    public QStates.VoidFunctionList startVfunc
    {
        get
        {
            return FSM.getState(start).dv_stateFunctions;

        }
        set
        {
            FSM.getState(start).dv_stateFunctions = value;

        }
    }
    /// <summary>
    /// Getter/Setter For the Delegates of init,start,main,end QStates created in the Start code
    /// </summary>
    public QStates.VoidFunctionList mainVfunc
    {
        get
        {
            return FSM.getState(main).dv_stateFunctions;

        }
        set
        {
            FSM.getState(main).dv_stateFunctions = value;

        }
    }
    /// <summary>
    /// Getter/Setter For the Delegates of init,start,main,end QStates created in the Start code
    /// </summary>
    public QStates.VoidFunctionList endVfunc
    {
        get
        {
            return FSM.getState(end).dv_stateFunctions;

        }
        set
        {
            FSM.getState(end).dv_stateFunctions = value;
        }
    }

    /// <summary>
    /// Establishes the FSM QStates this script uses
    /// </summary>
    [ContextMenu("Start")]
    void Start()
    {
        FSM.addState(init, null);
        FSM.addState(start, init);
        FSM.addState(main, start);
        FSM.addState(end, null);




        if (NextPlayer.GetComponent<StateManager>().FSM.getState(init) == null)
            FSM.nextState = FSM.getState(init);
        else
        {
            if (NextPlayer.GetComponent<StateManager>().FSM.currentState != NextPlayer.GetComponent<StateManager>().FSM.getState(init))
                FSM.nextState = FSM.getState(init);
            else
                FSM.nextState = FSM.getState(end);
        }


        endVfunc += TurnChange;


       // print("Start finished");
    }

    /// <summary>
    /// Changes State based on state param
    /// </summary>
    /// <param name="state">Name of state</param>
    [ContextMenu("Invoke End")]
    public void EndState()
    {
        StateShift(end);
    }

    public void StateShift(string state)
    {
        print(gameObject.name + state);
        FSM.nextState = FSM.getState(state);
        
    }

    void TurnChange()
    {
        NextPlayer.GetComponent<StateManager>().StateShift(init);
        //print("Turn Changed");
    }

}
