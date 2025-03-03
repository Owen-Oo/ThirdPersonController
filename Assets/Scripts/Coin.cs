using UnityEngine;
using UnityEngine.Events;

public class Coin : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;

    public UnityEvent CoinCollected = new UnityEvent();

    void Update()
    {
        transform.Rotate(new Vector3(0f, rotationSpeed, 0f));
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            CoinCollected?.Invoke();
            Debug.Log("Coin Collected!");
            Destroy(gameObject);
        }
    }
}
