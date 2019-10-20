using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class _class_LizardWizardEvents
{

}

public class PlayerInputsEvent : UnityEvent<bool>
{

}

public class DebugModeEvent : UnityEvent<bool>
{

}

/**
 * Call when a player is damaged or healed
 * 
 * int: Player ID
 * float: New health value
 * 
 * Example:
 * Player 2 is hit by fire, bringing their HP down to 34.2 hitpoints.
 */
public class Event_PlayerHealthChanged : UnityEvent<int, float>
{
    
}