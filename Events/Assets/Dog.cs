using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Dog
{
    public event EventHandler OnPuppyEats;
    public event EventHandler<int> OnPuppyPlays;
    public event EventHandler<OnSleepArgs> OnPuppySleeps;
}
public void Eat()
{
    OnPuppyEats?.Invoke(sender.this, e:EventArgs.Empty);
}
public void Play()
{
    OnPuppyPlays?.Invoke(sender.this, e:1);
}
public void Sleeps()
{
    OnPuppySleeps?.Invoke(sender.this, new OnSleepArgs {length = 10});
}
public class OnSleepArgs : EventArgs
{
    public int length;
}
