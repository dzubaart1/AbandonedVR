using Canvases;
using Enemy;
using UnityEngine;

namespace Bullet
{
    public class BulletCntrl : MonoBehaviour
    {
        [SerializeField] private HitCanvasCntrl _hitCanvas;
        [SerializeField] private float _damageAmount;
        
        private const float MAX_LIFE_TIME = 10f;
        private float _currentLifeTime;
        private Vector3 _startPoint;

        private void Awake()
        {
            _startPoint = transform.position;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.GetComponent<EnemyHealth>() is not null)
            {
                collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(_damageAmount);
                var hitCanvas = Instantiate(_hitCanvas, collision.transform.position + new Vector3(0,1,0), Quaternion.LookRotation(_startPoint - transform.position));
                hitCanvas.ChangeHitText(_damageAmount);
            }
            
            Destroy(gameObject);
        }

        private void Update()
        {
            _currentLifeTime += Time.deltaTime;
            if (_currentLifeTime > MAX_LIFE_TIME)
            {
                Destroy(gameObject);
            }
        }
    }
}
