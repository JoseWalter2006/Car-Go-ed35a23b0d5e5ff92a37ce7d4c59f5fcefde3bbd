using UnityEngine;

public class Gun : MonoBehaviour
{
    public Bullet bullet;

    public Transform firePointCenter;
    public Transform firePointLeft;
    public Transform firePointRight;

    public void Shoot()
    {
        ShootFrom(firePointCenter);
        ShootFrom(firePointLeft);
        ShootFrom(firePointRight);
    }

    void ShootFrom(Transform fp)
    {
        GameObject go = Instantiate(bullet.gameObject, fp.position, fp.rotation);

        Bullet b = go.GetComponent<Bullet>();
        b.direction = fp.up; // dirección correcta
    }
}