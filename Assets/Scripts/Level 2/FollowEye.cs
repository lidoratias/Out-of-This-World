using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowEye : TargetedLinearOperatableObject
{

    public Animator anim;
    private bool alreadyBlinked = false;

    public override void Operate()
    {
        if (!alreadyBlinked)
        {
            alreadyBlinked = true;
            anim.Play("Blinking Eye Blue");
            //anim.SetBool("blink", true);
            Invoke("Unblink", anim.GetCurrentAnimatorClipInfo(0)[0].clip.length);
        } else
        {
            Activate();
        }
    }

    void Unblink()
    {
        //anim.SetBool("blink", false);
        Invoke("Activate", 0.7f);
    }

    protected override void Disactivate()
    {
        lm.enabled = false;
    }
}
