using System.Collections;
using UnityEngine;

public class DisappearanceItemCntrl : MonoBehaviour
{
    [SerializeField] private ParticleSystem _activateParticleSystem;

    private const float MAX_WAIT_BEFORE_DESTROY = 3;
    
    public void ActivateItem()
    {
        StartCoroutine(DestroyObject());
    }

    private IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(MAX_WAIT_BEFORE_DESTROY);
        
        Instantiate(_activateParticleSystem, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
