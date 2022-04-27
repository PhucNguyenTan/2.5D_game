using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitdata
{
    public int Damage;
    public Vector3 hitpoint;
    public Vector3 hitNormal;
    public IHitDetector hitdetector;
    public IHurtbox hurtbox;

    public bool Validate()
    {
        if (hurtbox != null)
            if (hurtbox.CheckHit(this))
                if (hurtbox.HurtResponder == null || hurtbox.HurtResponder.CheckHit(this))
                    if (hitdetector.HitResponder == null || hitdetector.HitResponder.Checkhit(this))
                        return true;
        return false;
    }
}

public interface IHitResponder {
    int damage { get; }

    public bool Checkhit(Hitdata hitData);
    public void Response(Hitdata hitData);
}

public interface IHitDetector { 
    public IHitResponder HitResponder { get; set; }
    public void CheckHit();
}

public interface IHurtResponder {
    public bool CheckHit(Hitdata hitData);
    public void Response(Hitdata hitData);
}

public interface IHurtbox { 
    public bool Active { get; }
    public GameObject owner { get; }
    public Transform Transform { get; }

    public IHurtResponder HurtResponder { get; set; }
    public bool CheckHit(Hitdata hitData);
}


