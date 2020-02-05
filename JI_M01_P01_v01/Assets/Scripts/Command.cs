using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command
{
    public string name;
    public abstract void Execute();
}

class MoveLeft: Command
{
    Rigidbody _player;
    float _force;
    // pass any variables needed into constructor and store into private variables
    public MoveLeft(Rigidbody player, float force)
    {
        _player = player;
        _force = force;
        name = "Move Left";
    }
    public override void Execute()
    {
        // Same line of code with rigidbody  and adding force 
        _player.AddForce(-_force * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
    }
}


class MoveRight: Command
{
    Rigidbody _player;
    float _force;
    // pass any variables needed into constructor and store into private variables
    public MoveRight(Rigidbody player, float force)
    {
        _player = player;
        _force = force;
        name = "Move Right";
    }
    public override void Execute()
    {
        // Same line of code with rigidbody  and adding force 
        _player.AddForce(_force * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
    }

}