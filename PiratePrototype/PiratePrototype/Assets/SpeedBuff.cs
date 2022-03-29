using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/SpeedBuff")]
public class SpeedBuff : PowerUpEffect
{
    public float amount;
    public float buffTimer;
    public float buffTime;
    public override void Apply(GameObject target)
    {
        //Trigger timer
        target.GetComponent<PlayerMovement>().Speed = amount;           
    }
}
