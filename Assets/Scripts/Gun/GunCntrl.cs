using Bullet;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using Random = UnityEngine.Random;

namespace Gun
{
    public class GunCntrl : MonoBehaviour
    {
        [SerializeField] private BulletCntrl _bulletPrefab;
        [SerializeField] private GameObject _bulletsHolder;
        [SerializeField] private Transform _bulletSpawnPoint;

        private XRGrabInteractable _grabInteractable;

        private void Start()
        {
            _grabInteractable = GetComponent<XRGrabInteractable>();
            _grabInteractable.activated.AddListener(Fire);
        }

        private void Fire(ActivateEventArgs eventArgs)
        {
            var bullet = Instantiate(_bulletPrefab, _bulletSpawnPoint.position, Quaternion.identity, _bulletsHolder.transform);
            bullet.GetComponent<Rigidbody>().velocity =
                Quaternion.AngleAxis(Random.Range(-3f, 3f), Vector3.up) * _bulletSpawnPoint.forward * 40 * -1;
        }
    }
}
