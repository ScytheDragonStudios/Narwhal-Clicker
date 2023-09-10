using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusParticleManager1 : MonoBehaviour
{

    [Header(" Elements ")]
    [SerializeField] private GameObject bonusParticlePrefab;

    private void Awake()
    {
        InputManager.onCarrotClickedPosition += CarrotClickedCallback;
    }

    private void OnDestroy()
    {
        InputManager.onCarrotClickedPosition -= CarrotClickedCallback;
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CarrotClickedCallback(Vector2 clickedPosition)
    {
        GameObject bonusParticleInstance = Instantiate(bonusParticlePrefab, clickedPosition, Quaternion.identity, transform);
        Destroy(bonusParticleInstance, 1);
    }
}
