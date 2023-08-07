using Globals;
using UnityEngine;
using UnityEngine.Events;

namespace Enemy
{
    public class EnemyHealth : MonoBehaviour
    {
        [SerializeField] private float _maxHealth;

        private float _currentHealth;
        private float _midHealth;
        private int _deathScore;
        
        public UnityEvent<HealthInfo> OnTakeDamage = new();

        private void Start()
        {
            _currentHealth = _maxHealth;
            _midHealth = _currentHealth / 2;
        }
        
        public void TakeDamage(float damage)
        {
            _currentHealth -= damage;
            
            if (_currentHealth <= 0)
            {
                Die();
                return;
            }

            if (_currentHealth <= _midHealth)
            {
                OnTakeDamage.Invoke(new HealthInfo(){IsDead = false,IsLowHealth = true});
                return;
            }
            
            OnTakeDamage.Invoke(new HealthInfo(){IsDead = false,IsLowHealth = false});
        }

        private void Die()
        {
            OnTakeDamage.Invoke(new HealthInfo(){IsDead = true,IsLowHealth = true});
            ThirdLevelEveneManager.Instance().SendDieEnemySignal();
            Destroy(gameObject);
        }

    }
    public class HealthInfo
    {
        public bool IsDead;
        public bool IsLowHealth;
    }
}