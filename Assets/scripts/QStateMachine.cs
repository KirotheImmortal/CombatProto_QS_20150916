using UnityEngine;
using System.Collections;
using System.Collections.Generic;


// Prefixes:
// Q     :     Quinton
// d    :     Delegate
// dv_   :     Void
// die_  :     IEnumerator
// s_    :     String
// s     :     State
// ls_   :     List of States
// 
// 
// Suffixes:

    /// <summary>
    /// State Object
    /// </summary>
public class QStates
{
    public QStates(string name, string prev)
    {
        sname = name;
        sprev = prev;
    }
    /// <summary>
    /// This State Name
    /// </summary>
    public string sname;
    /// <summary>
    /// State that this state can begin from
    /// </summary>
    public string sprev;

    public delegate void VoidFunctionList();
    /// <summary>
    /// Delegates of void Function()
    /// </summary>
    public VoidFunctionList dv_stateFunctions;

    public delegate IEnumerator IEnumeratorFunctionList();
    /// <summary>
    /// Delagates of IEnumerator Function()
    /// </summary>
    public IEnumeratorFunctionList die_stateFunctions;


}

/// <summary>
/// Premade State Manager
/// </summary>
public class QStateMachine
{
    /// <summary>
    /// List of all the QStates
    /// </summary>
    List<QStates> ls_States = new List<QStates>();
    private QStates cur;
    private QStates nex;

    /// <summary>
    /// State currently in.
    /// When Modified the state will play its delegates if delegates have functions stored
    /// </summary>
    QStates current
    {
        get
        { return cur; }
        set
        {
            cur = value;
            if (current.dv_stateFunctions != null)
            {
                current.dv_stateFunctions();
            }
            if (current.die_stateFunctions != null)
            {
                current.die_stateFunctions();
            }
        }
    }
    /// <summary>
    /// State intended to change to. If allowed the current state will be changed to the value the nextState was changed to.
    /// </summary>
    public QStates nextState
    {
        get
        { return nex; }
        set
        {
            nex = value;
            if (current == null)
                current = value;
            else if (current.sname == current.sprev || nextState.sprev == null)
            {
                current = value;
            }

        }

    }

    public void addState(string name, string prevname)
    {
        ls_States.Add(new QStates(name, prevname));
    }
    public void removeState(string name)
    {
        foreach (QStates s in ls_States)
        {
            if (s.sname == name)
                ls_States.Remove(s);
        }
    }
    public void changeState(string name)
    {
        foreach (QStates s in ls_States)
            if (s.sname == name)
            {
                nextState = s;
                return;
            }
    }
    public void clearStateList()
    {
        ls_States.Clear();
    }
    public QStates getState(string name)
    {
        foreach (QStates s in ls_States)
            if (s.sname == name)
                return s;

        return null;
        
    }


    

}

