using UnityEngine;

namespace Cntrls
{
    public class DoorCntrl : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _destoryDoorParticleSystem;
        [SerializeField] private Transform _pointOfParticleSystem;
        
        private bool _isActivated;
        public void Open()
        {
            _isActivated = true;
            Instantiate(_destoryDoorParticleSystem, _pointOfParticleSystem.position, Quaternion.identity);
        }

        private void Update()
        {
            if (_isActivated)
            {
                transform.position = Vector3.MoveTowards(transform.position, transform.position - new Vector3(0, 100, 0),
                    Time.deltaTime);
            }
        }
    }
}
