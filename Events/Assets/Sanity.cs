using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Sanity
{
    private int sanityLevel;

    // Default constructor
    public Sanity()
    {
        sanityLevel = 100; // Assuming sanity starts at a maximum level of 100
    }

    // Constructor with Player parameter to subscribe to events
    public Sanity(Player player)
    {
        sanityLevel = 100;
        player.OnPlayerStressed += Player_OnPlayerStressed;
    }

    // Event handler for when the player experiences stress
    private void Player_OnPlayerStressed()
    {
        Debug.Log("Player experienced stress. Sanity decreased!");
        DecreaseSanity(10); // Decrease sanity by a fixed amount, adjust as needed
    }

    // Method to decrease sanity level
    private void DecreaseSanity(int amount)
    {
        sanityLevel -= amount;
        sanityLevel = Mathf.Clamp(sanityLevel, 0, 100); // Keep sanity within 0-100 range
        CheckSanityStatus();
    }

    // Method to check sanity level and log different states
    private void CheckSanityStatus()
    {
        if (sanityLevel <= 0)
        {
            Debug.Log("Player has lost all sanity and is in a critical mental state.");
            // Additional logic for zero sanity (e.g., game effects or restrictions) can be added here
        }
        else if (sanityLevel < 30)
        {
            Debug.Log("Player's sanity is very low! They are close to breaking.");
        }
        else if (sanityLevel < 70)
        {
            Debug.Log("Player's sanity is somewhat stable, but signs of stress are showing.");
        }
        else
        {
            Debug.Log("Player's sanity is stable.");
        }
    }

    // Method to unsubscribe from player events
    public void Unsubscribe(Player player)
    {
        player.OnPlayerStressed -= Player_OnPlayerStressed;
    }
}
