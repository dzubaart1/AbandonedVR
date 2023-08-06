using UnityEngine;

public class GhostCntrl : MonoBehaviour
{
    //TODO
    [SerializeField] private GameObject _player;
    private void Update()
    {
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(_player.transform.position - transform.position), Time.deltaTime * 1000);
    }
}
