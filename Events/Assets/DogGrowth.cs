using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogGrowth : MonoBehaviour
{
    private int growthLevel = 0;

    public void SubscribeToDogEvents(Dog dog)
    {
        dog.OnPuppyEats += Dog_OnPuppyEats;
        dog.OnPuppyPlays += Dog_OnPuppyPlays;
        dog.OnPuppySleeps += Dog_OnPuppySleeps;
    }

    private void Dog_OnPuppyEats(object sender, EventArgs e)
    {
        Debug.Log("The puppy ate and is growing stronger!");
        growthLevel += 2;
        CheckGrowth();
    }

    private void Dog_OnPuppyPlays(object sender, int playAmount)
    {
        Debug.Log("The puppy played and is developing well!");
        growthLevel += playAmount;
        CheckGrowth();
    }

    private void Dog_OnPuppySleeps(object sender, Dog.OnSleepArgs e)
    {
        Debug.Log("The puppy slept well and is growing!");
        growthLevel += e.length / 2; // Longer sleep adds to growth, but at a lower rate
        CheckGrowth();
    }

    private void CheckGrowth()
    {
        // Here, you can define different levels of growth based on the growthLevel value
        if (growthLevel >= 20)
        {
            Debug.Log("The puppy has reached an adolescent stage!");
            // Adjust appearance, size, or behaviors here
        }
        else if (growthLevel >= 50)
        {
            Debug.Log("The puppy has grown into an adult dog!");
            // Further adjustments as it reaches adulthood
        }
    }

    private void OnDisable()
    {
        // Ensure to unsubscribe from events when the object is disabled
    }
}
