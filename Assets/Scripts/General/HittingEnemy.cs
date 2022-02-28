using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HittingEnemy : MonoBehaviour
{

    public int damage = 10;

    protected virtual void Update() { }

    // Start is called before the first frame update
    public int getDamage()
    {
        return this.damage;
    }

    public void setDamage(int damage)
    {
        this.damage = damage;
    }
}
