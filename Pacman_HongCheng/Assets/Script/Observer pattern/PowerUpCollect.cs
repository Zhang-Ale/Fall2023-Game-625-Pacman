using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpCollect : Observable
{
    public float _fireRate = 0.5f;
    public float _canFire = -1f;
    public Transform shootPosition;
    public GameObject _bulletPrefab;
    public float forceMultiplicator = 10;
    void Update()
    {
        Vector3 mouseInWorldSpace = Camera.main.ScreenToWorldPoint
            (new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.y));
        Vector3 direction = mouseInWorldSpace - transform.position;
        Debug.DrawRay(transform.position, direction);
        if (Input.GetMouseButtonDown(0))
        {
            ShootBullet(direction);
            Notify(Action.OnPlayerShoot);
        }
    }

    void ShootBullet(Vector3 direction)
    {
        _canFire = Time.time + _fireRate;
        GameObject bullet = Instantiate(_bulletPrefab, shootPosition.transform.position, Quaternion.identity);
        //bullet.GetComponent<Rigidbody>().velocity = Vector3.forward * 5f;
        bullet.GetComponent<Rigidbody>().velocity = direction * forceMultiplicator;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PowerUp")
        {
            Notify(Action.OnPowerUpCollect);
        }
    }

    private void Awake()
    {
        IObserver gm = GameObject.FindFirstObjectByType<PlayerActions>();
        AddObserver(gm);
    }

    private void OnDisable()
    {
        IObserver gm = GameObject.FindFirstObjectByType<PlayerActions>();
        RemoveObserver(gm);
    }
}
