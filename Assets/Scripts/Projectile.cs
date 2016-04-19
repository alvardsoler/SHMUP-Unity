using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
	[SerializeField]
	private WeaponType _type;
	BoxCollider2D _collider;

	public WeaponType type {
		get {
			return (_type);
		}
		set {
			SetType (value);
		}
	}

	void Awake ()
	{
		_collider = GetComponent<BoxCollider2D> ();
		InvokeRepeating ("CheckOffscreen", 2f, 2f);
	}

	public void SetType (WeaponType eType)
	{
		_type = eType;
		WeaponDefinition def = Main.GetWeaponDefinition (_type);
		Renderer renderer = GetComponent<Renderer> ();
		renderer.material.color = def.projectileColor;
	}

	void CheckOffscreen ()
	{
		if (Utils.ScreenBoundsCheck (_collider.bounds, BoundsTest.offScreen) != Vector3.zero) {
			Destroy (this.gameObject);
		}
	}
}
