using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoBar : MonoBehaviour
{
    public Image bar;
    public float fill;
    Weapon weapon;


    private void Start()
    {
        fill = (1.0f / 30.0f) * weapon.ammo;
    }

    private void Update()
    {
        bar.fillAmount = fill;
    }
}
