using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Enemy/Actions/Chase")]
public class EnemyChase : EnemyAction
{
    public override void Act(EnemyStateData data)
    {
        Vector2 vel = data.rb2d.velocity;
        float direction = Mathf.Sign((data.currentTarget.position - data.transform.position).x);
        vel.x =  direction * data.moveSpeed;
        data.anim.SetBool("Walking", true);
        data.anim.SetBool("FacingRight", direction > 0);
        data.rb2d.velocity = vel;
    }
}
