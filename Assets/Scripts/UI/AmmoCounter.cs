using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoCounter : MonoBehaviour
{
	[SerializeField]Text text;
	public WeaponReloader reloader;
	PlayerShoot playerShoot;
	AmmoPickup pickup;



	void Awake ()
	{
		GameManager.Instance.OnLocalPlayerJoined += HandleOnLocalPLayerJoined;
		//HandleOnAmmoChanged ();
	
	}


	void HandleOnLocalPLayerJoined (Player player)
	{
		playerShoot = player.PlayerShoot;
		reloader = playerShoot.ActiveWeapon.Reloader;
		playerShoot.OnWeaponSwitch += HandleOnWeaponSwitch;
		HandleOnAmmoChanged ();

		reloader = playerShoot.ActiveWeapon.Reloader;
		reloader.OnAmmoChanged += HandleOnAmmoChanged;
	}

	void HandleOnWeaponSwitch (Shooter activeWeapon)
	{
		reloader = activeWeapon.Reloader;
		reloader.OnAmmoChanged += HandleOnAmmoChanged;
		HandleOnAmmoChanged ();
	}

	void HandleOnAmmoChanged ()
	{
		Debug.Log ("handling ammo change");
		var amountInInventory = reloader.RoundsRemainingInInventory;
		var amountInClip = reloader.RoundsRemainingInClip;
		text.text = string.Format("{0}/{1}", amountInClip, amountInInventory);
	}
	
	// Update is called once per frame
	void Update ()
	{

	}
}
