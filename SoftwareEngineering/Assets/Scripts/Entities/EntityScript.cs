using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityScript : MonoBehaviour
{
    /// Data Storage containers

    // Stores all the information for when the entity is attacked.    
    public struct SDamageInfo
    {
        public float RemainingHealth;
        public float DamageDealt;
        public bool KilledEntity;
        public bool AttackIgnored;
    }



    /// Public Variables

    // Represents if this entity is alive or not.
    public bool IsDead;

    // Determines if this entity can be hurt.
    public bool Invincible;

    // Determines how long this entity stays invonerable after being attaked.
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
    private bool Invonerable;

    

    /// Component Variables

    // A reference to the animator attached to this entity.
    private Animator Anim;

    // A reference to the character controller attached to this entity.
    private CharacterController Controller;

    

    /// Functions

	// Use this for initialization
	protected virtual void Start ()
    {
        Anim = GetComponent<Animator>();
        Controller = GetComponent<CharacterController>();

        if (!IsDead)
        {
            Health = MaxHealth;
        }
	}


    /// Attacking and Damaging

    // Damages this entity based on the imputted amount.
    // @param Amount - The amount of damage the attack will inflict onto this entity.
    // @return - A struct Representing the damage the entity applied along with how much health the entity has left after the attack.
    public SDamageInfo ApplyDamage(float Amount)
    {
        if (!IsDead && !Invincible && !Invonerable && Amount > 0.0f)
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

    // Incomplete function.
    // Adds a positive/negative effect to this entity.
    public void ApplyEffect()
    {
        // Test if the entity already has the effect.
            // If true, check to see the the new effect duration is longer than the old effect duration.
                // If true, set the old effect duration to be equal to the new effect duration.
                // If false, do nothing.
            // If false, Add the effect to the list of effects on this entity and start the duration timer.
    }


    // Incomplete function.
    // Removes a positive/negative effect from this entity.
    public void RemoveEffect()
    {
        // Checks if the entity has that specific effect.
            // If true, remove that effect.
            // If false, do nothing.
    }


    // Removes all positive effects on this entity.
    public void RemoveAllPositiveEffects()
    {
        // Goes through all positive effects and removes them from this entity (stopping all timers for their effects).
    }


    // Removes all negative effects on this entity.
    public void RemoveAllNegativeEffects()
    {
        // Goes through all negative effects and removes them from this entity (stopping all timers for their effects).
    }



    /// Movement
    
    public void MoveDirection(Vector3 Direction)
    {
        if (!IsDead && Controller)
        {
            Controller.Move(Direction * MovementSpeed * Time.deltaTime);
        }
    }


    
    public void Jump()
    {
        if (!IsDead && Controller && Controller.isGrounded)
        {
            Controller.Move(Vector3.up * JumpStrength);
        }
    }

  
    



    /// Timers

    private IEnumerator StartImmunityFrames()
    {
        Invonerable = true;
        yield return new WaitForSeconds(ImmunityFrameTime);
        Invonerable = false;
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
