using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogHealth
{
    private int healthPoints = 100;

    public void SubscribeToDogEvents(Dog dog)
    {
        dog.OnPuppyEats += Dog_OnPuppyEats;
        dog.OnPuppyPlays += Dog_OnPuppyPlays;
        dog.OnPuppySleeps += Dog_OnPuppySleeps;
    }

    private void Dog_OnPuppyEats(object sender, EventArgs e)
    {
        Debug.Log("The puppy ate and regained some health!");
        healthPoints += 10;
    }

    private void Dog_OnPuppyPlays(object sender, int playAmount)
    {
        Debug.Log("The puppy played and used some energy.");
        healthPoints -= playAmount;
    }

    private void Dog_OnPuppySleeps(object sender, Dog.OnSleepArgs e)
    {
        Debug.Log("The puppy slept and regained health!");
        healthPoints += e.length * 2;
    }

    private void OnDisable()
    {
        // Make sure to unsubscribe from events when the object is disabled
    }
}
