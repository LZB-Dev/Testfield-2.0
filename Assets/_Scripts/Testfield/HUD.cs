using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour //bap
{
    [SerializeField] private GameObject player;
    [SerializeField] private TextMeshProUGUI speedometer;
    [SerializeField] private TextMeshProUGUI ammo;
    [SerializeField] private Rigidbody playerRB;

    private void Start()
    {
        playerRB.GetComponent<Rigidbody>();
    }

    private void SpeedUpdate(TextMeshProUGUI speedometer, Rigidbody playerRB)
    {
        speedometer.SetText($" {Mathf.RoundToInt(playerRB.linearVelocity.magnitude * 2.237f)} km/h");
    }

    private void UIColorChange(TextMeshProUGUI element, Color color)
    {
        element.color = color;
    }

    private void AmmoUpdate(TextMeshProUGUI ammo)
    {
        PlayerController_InputSystem Info = player.GetComponent<PlayerController_InputSystem>();
        ammo.SetText($"[{Info.ammoCurrent}/{Info.ammoMagazine}]");
        if (Info.ammoCurrent > 19) { UIColorChange(ammo, Color.white); }
        else if (Info.ammoCurrent <= 19 && Info.ammoCurrent > 0) { UIColorChange(ammo, Color.yellow); }
        else if (Info.ammoCurrent == 0) { UIColorChange(ammo, Color.red); }
    }

    private void HPBar()
    {

    }


    void Update()
    {
        SpeedUpdate(speedometer, playerRB);
        AmmoUpdate(ammo);
    }
}
