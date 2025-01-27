using Inventory;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputSystem : MonoBehaviour
{
    public event Action OnKeyDamage;
    public event Action OnKeyHeal;
    public event Action OnKeyPoints;
    public event Action OnKeyAddLevel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                OnKeyDamage?.Invoke();
                Debug.Log("Se ha presionado el 1, Damage");
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                OnKeyHeal?.Invoke();
                Debug.Log("Se ha presionado el 2, Heal");
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                OnKeyPoints?.Invoke();
                Debug.Log("Se ha presionado el 3, Points");
            }

            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                OnKeyAddLevel?.Invoke();
                Debug.Log("Se ha presionado el 4, AddLevel");
            }
        }
    }
}
