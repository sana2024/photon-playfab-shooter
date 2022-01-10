using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class  Weapon : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        WeaponStart();
    }

    // Update is called once per frame
    void Update()
    {
        WeaponUpdate();
    }

    public abstract void WeaponUpdate();
    public abstract void WeaponStart();
}
