using UnityEngine;
using UnityEngine.Events;

public class CollectionCntrl : MonoBehaviour
{
    private int _collectionSize = 0;

    private const int COUNT_TO_COMPLETE_COLLENCTION = 3;

    public UnityEvent OnCompleteCollect = new();
    
    public void CollectItem()
    {
        _collectionSize++;
        Debug.Log(_collectionSize);
        if (_collectionSize == COUNT_TO_COMPLETE_COLLENCTION)
        {
            OnCompleteCollect.Invoke();
        }
    }
}
