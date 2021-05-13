using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
	void Update()
	{	
		if ((Input.GetButtonDown("Fire1") && ammo != 0)) Shooting();
	}

	[SerializeField] private float ammo = 30.0f;
	[SerializeField] private float _weaponDamage = 50.0f;
	public float fireRate = 1.0f;
	public ParticleSystem flash;
	public Transform bulletSpawn;
	public AudioClip shotSFX;
	public AudioSource audioSourse;
	[SerializeField] private float _weaponRange = 15.0f;
    private new Camera camera;
    public float weaponForce = 155.0f;

    public Camera Camera { get => camera; set => camera = value; }

    void Shooting()
	{
		audioSourse.PlayOneShot(shotSFX);
		//Instantiate(flash, bulletSpawn.position, bulletSpawn.rotation);  плохо не использовать, много возни
		flash.Play(); //Лучше так)))
		RaycastHit hit;
		if (Physics.Raycast(Camera.transform.position, Camera.transform.forward, out hit, _weaponRange))
		{
			if (hit.rigidbody != null) hit.rigidbody.AddForce(-hit.normal * weaponForce);
		}
	}
}
