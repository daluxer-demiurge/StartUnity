using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
	public float ammo = 30.0f;
	[SerializeField] private int _weaponDamage = 50;
	public float fireRate = 2.0f;
	public ParticleSystem flash;
	public ParticleSystem smoke;
	public Transform bulletSpawn;
	public AudioClip shotSFX;
	public AudioSource audioSourse;
	[SerializeField] private float _weaponRange = 50.0f;
	public Camera camera;
	[SerializeField] private float weaponForce = 10.0f;
	private float nextFireTime = 0f;
	[SerializeField] private GameObject lootBox;
	public Enemy enemy;
	
	


	void Update()
	{
		if (Input.GetButtonDown("Fire1") && PauseMenu.GameIsPaused != true && Time.time > nextFireTime && ammo != 0) 
		{
			nextFireTime = Time.time + 1f / fireRate;
			Shooting();
			ammo -= 1;
		}

		if (Input.GetKeyDown(KeyCode.E))
		{
			PickUp();
		}
	}

	void PickUp()
    {
		RaycastHit hit;
		if (Physics.Raycast(Camera.transform.position, Camera.transform.forward, out hit, _weaponRange))
        {
			Loot loot = hit.collider.GetComponent<Loot>();
			loot.Hurt(_weaponDamage);
			{
				ammo += 10.0f;
								
			}

		}

	}

    public Camera Camera { get => camera; set => camera = value; }

    void Shooting()
	{
		audioSourse.PlayOneShot(shotSFX);
		flash.Play(); 
		smoke.Play();
		RaycastHit hit;
		if (Physics.Raycast(Camera.transform.position, Camera.transform.forward, out hit, _weaponRange))
		{
			Debug.Log("оноюдюмхе б - " + hit.collider);
			if (hit.rigidbody != null) hit.rigidbody.AddForce(-hit.normal * weaponForce);
			Enemy enemyHealth = hit.collider.GetComponent<Enemy>();
			enemyHealth.Hurt(_weaponDamage);
				
			
		}
	}
}
