using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    #region Varialbles
    [SerializeField] private PlayerGunSelector gunSelector;
    #endregion

    #region MonoBehaviour Callbacks
    void Update()
    {
        if(Input.GetMouseButton(0) && gunSelector.activeGun != null)
            gunSelector.activeGun.Shoot();
    }
    #endregion
}
