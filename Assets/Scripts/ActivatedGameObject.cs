using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatedGameObject : MonoBehaviour
{

    protected bool isPhasingOut = false;
    protected bool isPhasingIn = false;

    public void SetActive(bool setActive)
    {
        gameObject.SetActive(setActive);
    }

    public virtual void phaseOut() { }
    public virtual void phaseIn() { }

    public bool getIsPhasingOut()
    {
        return this.isPhasingOut;
    }

    public bool getIsPhasingIn()
    {
        return this.isPhasingIn;
    }

    public void setIsPhasingOut(bool phaseOut)
    {
        this.isPhasingOut = phaseOut;
    }

    public void setIsPhasingIn(bool phaseIn)
    {
        this.isPhasingIn = phaseIn;
    }
}
