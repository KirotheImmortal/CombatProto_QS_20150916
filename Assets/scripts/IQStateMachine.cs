using UnityEngine;
using System.Collections;

public interface IQStateMachine
{
    void addState(string name, string prevname);
    void removeState(string name);

    void clearStateList();

    QStates getState(string name);

}
