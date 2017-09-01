using UnityEngine;
using System.Collections;

public class AmmoPickup : PickupItem {

	[SerializeField]EWeaponType weaponType;
	[SerializeField]float respawnTime;
	[SerializeField]int amount;
	public GameObject player;
	WeaponReloader reloader;
	PlayerShoot playerShoot;
	AmmoCounter ammoCount;

	void Start() {

		reloader = gameObject.GetComponent<WeaponReloader>();

		if(!player)
			player = GameObject.Find("Player");

	}
	public override void OnPickup(Transform item)
	{
		var playerInventory = item.GetComponentInChildren<Container>();
		GameManager.Instance.Respawner.Despawn (gameObject, respawnTime);
		playerInventory.Put(weaponType.ToString(),amount);
		Debug.Log ("trying to find: " + weaponType.ToString ());
		//reloader.OnAmmoChanged ();
		item.GetComponent<Player> ().PlayerShoot.ActiveWeapon.Reloader.HandleOnAmmoChanged ();

	}
}
