using UnityEngine;
using System.Collections;
using UnityEngine.Events;


public class StateManager : MonoBehaviour
{
    //  public QStateMachine FSM = new QStateMachine();

    public string init = "INIT";
    public string start = "START";
    public string main = "MAIN";
    public string end = "END";

    public delegate void InitList();
    public delegate void StartList();
    public delegate void MainList();
    public delegate void EndList();
    /// <summary>
    /// Init Void Delegate
    /// </summary>
    public InitList initList;
    /// <summary>
    /// Start Void Delegate
    /// </summary>
    public StartList startList;
    /// <summary>
    /// Main Void Delegate
    /// </summary>
    public MainList mainList;
    /// <summary>
    /// End Void Delegate
    /// </summary>
    public EndList endList;

    QStates s_Init;
    QStates s_Start;
    QStates s_Main;
    QStates s_End;

    QStates currentState;

    string playState
    {
        set
        {
            if (value == init)
            {
                if (initList != null)
                {
                    initList();
                   // print(gameObject.name + init);
                }
            }
            else if (value == start)
            {
                if (startList != null)
                {
                    startList();
                   // print(gameObject.name + start);
                }
            }
            else if (value == main)
            {
                if (mainList != null)
                {
                    mainList();
                 //   print(gameObject.name + main);
                }
            }
            else if (value == end)
            {
                if (endList != null)
                {
                    endList();
                  //  print(gameObject.name + end);
                }
            }


        }
    }

    QStates nextState
    {
        set
        {
            if (currentState != null)
            {
                if (currentState.sname == value.sprev || value.sprev == null)
                {
                    currentState = value;
                    playState = value.sname;
                }
            }
            else
            {
                currentState = value;
                playState = value.sname;
            }
        }
    }


    /// <summary>
    /// Establishes all QStates
    /// based on init,start,main strings
    /// </summary>
    void Awake()
    {

        s_Init = new QStates(init, null);
        s_Start = new QStates(start, init);
        s_Main = new QStates(main, start);
        s_End = new QStates(end, null);

    }
    /// <summary>
    /// Starts the State Manager
    /// </summary>
    void Start()
    {
        InvokeStateshift();
    }


    /// <summary>
    /// Jumps to End State
    /// </summary>
    public void EndState()
    {
        nextState = s_End;
    }
    //public void StateShift(string state)
    //{
    //    print(gameObject.name + state);
    //    FSM.nextState = FSM.getState(state);

    //}
    /// <summary>
    /// Goes to next State when called;
    /// 
    /// this process automaticly starts delegates
    /// 
    /// </summary>
    public void InvokeStateshift()
    {
        if (currentState != null)
        {
            if (currentState == s_Init)
            {
                nextState = s_Start;
            }
            else if (currentState == s_Start)
            {
                nextState = s_Main;

            }
            else if (currentState == s_Main)
            {
                nextState = s_End;

            }
            else if (currentState == s_End)
            {
                nextState = s_Init;
            }
        }
        else
            nextState = s_Init;
    }

}