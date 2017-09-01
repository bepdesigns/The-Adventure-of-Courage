using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

	[SerializeField]float rateOfFire;
	[SerializeField]Projectile projectile;
	[SerializeField]Transform hand;
	[SerializeField]AudioController audioReload; 
	[SerializeField]AudioController audioFire;
	[SerializeField]Transform aimTarget;




	public WeaponReloader Reloader;
	private ParticleSystem muzzleFireParticleSystem;
	private ParticleSystem tupperParticleSystem;



	float nextFireAllowed;
	Transform muzzle;
	Transform tupper;

	public bool canFire; 

	public void Equip(){
		transform.SetParent (hand);
		transform.localPosition = Vector3.zero;
		transform.localRotation = Quaternion.identity;

	}

	void Awake(){

		muzzle = transform.Find ("Model/Muzzle");
		tupper = transform.Find ("Model/Tupper");
		Reloader = GetComponent<WeaponReloader> (); 
		muzzleFireParticleSystem = muzzle.GetComponentInChildren<ParticleSystem> ();
		//tupperParticleSystem = tupper.GetComponentInChildren<ParticleSystem> ();

	}
	public void Reload(){
		if (Reloader == null)
			return;
		Reloader.Reload ();
		audioReload.Play ();
	}

	void FireEffect()
	{
		if (muzzleFireParticleSystem == null)
			return;
		muzzleFireParticleSystem.Play ();

		if (tupperParticleSystem == null)
			return;
		tupperParticleSystem.Play ();
	}

	public virtual void Fire() {

		canFire = false;

		if (Time.time < nextFireAllowed)
			return;

		if (Reloader != null) {
			if (Reloader.IsReloading)
				return;
			if (Reloader.RoundsRemainingInClip == 0)
				return;

			Reloader.TakeFromClip (1);
		}

		nextFireAllowed = Time.time + rateOfFire;

		muzzle.LookAt (aimTarget);
		FireEffect ();

		//instantiate the projectile;
		Instantiate(projectile, muzzle.position, muzzle.rotation);
		audioFire.Play ();
		//print ("Firing! :"+ Time.time);
		canFire = true;


	}

}
