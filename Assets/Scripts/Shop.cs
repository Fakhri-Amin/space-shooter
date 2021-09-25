using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public Sprite redShip;
    public Sprite blueShip;
    public Sprite greenShip;
    public Sprite orangeShip;

    private Player player;

    private void Start()
    {
        player = FindObjectOfType<Player>();
    }

    public void RedShip()
    {
        player.spriteRenderer.sprite = redShip;
    }

    public void BlueShip()
    {
        player.spriteRenderer.sprite = blueShip;
    }

    public void GreenShip()
    {
        player.spriteRenderer.sprite = greenShip;
    }

    public void OrangeShip()
    {
        player.spriteRenderer.sprite = orangeShip;
    }
}
