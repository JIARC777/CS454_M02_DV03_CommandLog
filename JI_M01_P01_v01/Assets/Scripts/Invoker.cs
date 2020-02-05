using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invoker
{ 
    public Command _command;
    private float _startTime;
    private float commandExecutionTime;

    public void SetCommand(Command command, float startTime)
    {
        _command = command;
        _startTime = startTime;
        CommmandLog.log.Enqueue(_command);
    }

    public void ExecuteCommand()
    {
        CommmandLog.log.Enqueue(_command);
        _command.Execute();
    }

    public void EndCommand(float EndTime)
    {
        commandExecutionTime = EndTime - _startTime;
        Debug.Log("Command executed for " + commandExecutionTime + " seconds");
    }
}

