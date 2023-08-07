using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGunSelector : MonoBehaviour
{
    #region Variables
    [SerializeField] private GunType gun;
    [SerializeField] private Transform gunParent;
    [SerializeField] private List<GunConfiguration> guns;
    public GunConfiguration activeGun;
    //[SerializeField] private PlayerIK inverseKinematics;
    #endregion

    #region Monobehaviour Callbacks
    void Start()
    {
        GunConfiguration Gun = guns.Find( Gun => Gun.type == gun);  

        if (Gun == null){
            Debug.LogError($"No GUnConfiguration Object found for GunType: {Gun}");
            return;
        }

        activeGun = Gun;
        Gun.Spawn(gunParent, this);

    }

    #endregion

    
}
