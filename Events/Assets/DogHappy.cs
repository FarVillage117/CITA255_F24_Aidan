using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogHappy
{
    private int happinessLevel = 0;

    public void SubscribeToDogEvents(Dog dog)
    {
        dog.OnPuppyEats += Dog_OnPuppyEats;
        dog.OnPuppyPlays += Dog_OnPuppyPlays;
        dog.OnPuppySleeps += Dog_OnPuppySleeps;
    }

    private void Dog_OnPuppyEats(object sender, EventArgs e)
    {
        Debug.Log("The puppy ate and is happy!");
        happinessLevel += 5;
    }

    private void Dog_OnPuppyPlays(object sender, int playAmount)
    {
        Debug.Log("The puppy played and gained happiness!");
        happinessLevel += playAmount;
    }

    private void Dog_OnPuppySleeps(object sender, Dog.OnSleepArgs e)
    {
        Debug.Log("The puppy slept and feels refreshed!");
        happinessLevel += e.length;
    }

    private void OnDisable()
    {
        // Make sure to unsubscribe from events when the object is disabled
    }
}