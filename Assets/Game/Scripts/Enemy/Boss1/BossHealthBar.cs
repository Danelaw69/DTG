using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MyGame.bulletHellen;
public class BossHealthBar : MonoBehaviour
{
    public Slider healthBar;
    public BulletHellen BulletHellen;
    private void Start()
    {
        BulletHellen = GameObject.FindGameObjectWithTag("Boss").GetComponent<BulletHellen>();
        healthBar = GetComponent<Slider>();
        healthBar.maxValue = BulletHellen.BossMaxHealth;
        healthBar.value = BulletHellen.BossMaxHealth;
        GameObject.Find("Boss Health Bar").transform.localScale = new Vector2(0, 0);
    }
    public void SetBossHealth(float hp)
    {
        healthBar.value = hp;
    }
}