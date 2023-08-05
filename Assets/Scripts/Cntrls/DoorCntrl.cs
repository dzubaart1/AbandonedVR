using UnityEngine;
using Vector3 = UnityEngine.Vector3;
public class DoorCntrl : MonoBehaviour
{
    private bool _isActivated;
    public void Open()
    {
        _isActivated = true;
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
