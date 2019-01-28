﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityScript : MonoBehaviour
{
    /// Data Storage containers

    // Stores all the information for when an entity is attacked.    
    public struct SDamageInfo
    {
        // The amount of health the attacked entity has left after the attack.
        public float RemainingHealth;

        // The total amount of damgae that was applied to the target.
        public float DamageDealt;

        // Is true if the attacked entity died from the attack.
        public bool KilledEntity;

        // Is true if the attack was ignored in any way (or dealt no damage).
        public bool AttackIgnored;
    }



    /// Public Variables

    // Represents if this entity is alive or not.
    public bool IsDead;

    // Determines if this entity can be Damaged.
    public bool Invincible;

    // Determines how long this entity stays invulnerable after being attaked.
    public float ImmunityFrameTime = 0.8f;

    // The maximum health this entity can have.
    public float MaxHealth = 100.0f;

    // How fast this entity moves in the world.
    public float MovementSpeed = 10.0f;

    // How high this entity can jump.
    public float JumpStrength = 5.0f;


    /// Protected Variables
    
    
    
    /// Internal Variables

    
    
    /// Private Variables

    // The current amount of HP this entity has.
    private float Health;

    // Represents if the entity has been damaged (cannot be damaged when active).
    private bool Invulnerable;

    // Holds the information on the velocity going up/down.
    private float JumpVal;

    

    /// Component Variables

    // A reference to the animator attached to this entity.
    private Animator Anim;

    // A reference to the character controller attached to this entity.
    private CharacterController Controller;

    

    /// Functions

	// Use this for initialization
	protected virtual void Start()
    {
        Anim = GetComponent<Animator>();
        Controller = GetComponent<CharacterController>();

        if (!IsDead)
        {
            Health = MaxHealth;
        }
	}


    protected virtual void FixedUpdate()
    {
        // Apply gravity.
        if (Controller && !Controller.isGrounded)
        {
            JumpVal -= -Physics.gravity.y * Time.deltaTime;
            Controller.Move(Vector3.up * JumpVal);
        }
    }



    /// Attacking and Damaging

    // Damages this entity based on the imputted amount.
    // @param Amount - The amount of damage the attack will inflict onto this entity.
    // @return - A struct Representing the damage the entity applied along with how much health the entity has left after the attack.
    public SDamageInfo ApplyDamage(float Amount)
    {
        if (!IsDead && !Invincible && !Invulnerable && Amount > 0.0f)
        {
            SDamageInfo Info;
            Info.DamageDealt = DamageCalculation(Amount);
            Info.AttackIgnored = false;

            Health -= Info.DamageDealt;
            Info.RemainingHealth = Health;

            if (Health <= 0.0f)
            {
                IsDead = true;
                Info.KilledEntity = true;
                // Play Death Sound
                // Play Death animation

                // Drop held items (if any)
            }
            else
            {
                // Play Hurt Sound
                // Play hurt animation
                StartCoroutine(StartImmunityFrames());
                Info.KilledEntity = false;
            }
            return Info;
        }
        else
        {
            SDamageInfo Info;
            Info.KilledEntity = false;
            Info.DamageDealt = 0.0f;
            Info.RemainingHealth = Health;
            Info.AttackIgnored = true;
            return Info;
        }
    }


    public float ApplyHeal(float Amount, bool IsRevive = false)
    {
        if (IsDead)
        {
            if (IsRevive)
            {
                IsDead = false;
                Health += Amount;

                // Play Revive sound or heal sound
                // Play heal particle effect
                // Play revive animation
            }
        }
        else
        {
            Health += Amount;
            // Play heal sound
            // Play heal particle effect
        }

        return Health;
    }

    public virtual float DamageCalculation(float RawValue)
    {
        return RawValue;
    }



    /// Effects

    // Adds a positive/negative effect to this entity.
    // @return Returns a reference of the added component (or pre-existing component).
    public T ApplyEffect<T>() where T : Effect
    {
        T Comp = GetComponent<T>();

        // Check if this entity already has this effect.
        if (Comp)
        {
            Comp.ResetEffect();
            return Comp;
        }
        else
        {
            // If the entity doesn't have this component add it.
            return gameObject.AddComponent<T>();
        }
    }


    // Removes a positive/negative effect from this entity.
    // @return - Returns true if the component was successfully removed (false if the entity didn't have that effect attached).
    public bool RemoveEffect<T>() where T : Effect
    {
        T Comp = GetComponent<T>();
        if (Comp)
        {
            Destroy(Comp);
            return true;
        }
        return false;
    }


    // Removes all positive effects on this entity.
    public void RemoveAllPositiveEffects()
    {
        Effect[] Effects = GetComponents<Effect>();
        for (int i = 0; i < Effects.Length; ++i)
        {
            if (Effects[i].Type == EEffectType.Positive)
            {
                Destroy(Effects[i]);
            }
        }
    }


    // Removes all negative effects on this entity.
    public void RemoveAllNegativeEffects()
    {
        Effect[] Effects = GetComponents<Effect>();
        for (int i = 0; i < Effects.Length; ++i)
        {
            if (Effects[i].Type == EEffectType.Negative)
            {
                Destroy(Effects[i]);
            }
        }
    }


    // Removes all effects on this entity.
    public void RemoveAllEffects()
    {
        Effect[] Effects = GetComponents<Effect>();
        for (int i = 0; i < Effects.Length; ++i)
        {
            Destroy(Effects[i]);
        }
    }



    /// Movement
    
    // Moves the entity in a direction at their current movement speed.
    public void MoveDirection(Vector3 Direction)
    {
        if (!IsDead && Controller)
        {
            Controller.Move(Direction * MovementSpeed * Time.deltaTime);
        }
    }


    // makes the entity jump.
    public void Jump()
    {
        if (!IsDead && Controller && Controller.isGrounded)
        {
            JumpVal = JumpStrength * Time.deltaTime;
            RemoveAllEffects();
        }
    }



    /// Timers

    private IEnumerator StartImmunityFrames()
    {
        Invulnerable = true;
        yield return new WaitForSeconds(ImmunityFrameTime);
        Invulnerable = false;
    }


    /// Setters / Getters

    // Getter for the current health of this entity.
    public float CurrentHealth
    {
        get
        {
            return Health;
        }
    }
}
