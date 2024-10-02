using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GridManager gridManager;
    public int level;
    public Enemigos enemigos;
    public Inventory playerItems;
    public GameObject[] dragons;
    public GameObject dragonBoss;
    public GameObject spawnPoint;
    public PlayerMovement playerMov;
    public PlayerAttack playerAtk;
    public PlayerPrefs playerPrefs;
    public HUD_Dragons hud_D;
    public All_HUD hud;
    public HUD_Upgrades hud_U;
    public Animator player_anim;
    public bool isGaming;
    public bool isUpgrading;
    public AudioSource audioSource;
    public AudioClip[] pasos;
    public AudioClip[] atk_Dragon;
    public AudioClip[] atk_pj;
    public AudioClip[] block_pj;
    public AudioClip[] golpe_Roca;
    public AudioClip[] dano_Player;
    public AudioClip piedra_Woosh, piedra_Impacto, rockDestroy, oro_Caido, oro_Recolectado, player_dead, garra, mordida, pisada, sadMusic, winMusic;
    void Awake()
    {
        Instance = this;

    }
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public IEnumerator StartLevel()
    {
        if (level <= 0)
        {
            gridManager.GenerateGrid();
        }
        hud_U.SetMejoras();
        audioSource.Stop();
        isUpgrading = false;
        yield return new WaitForSeconds(.5f);
        level++;
        yield return new WaitForSeconds(.5f);
        dragonBoss = Instantiate(dragons[Random.Range(0,dragons.Length)],spawnPoint.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(.5f);
        enemigos = FindObjectOfType<Enemigos>();
        PlaySound(enemigos.self_Dragon_Rugido);
        yield return new WaitForSeconds(.5f);
        enemigos.maxHP = 100 + (level * 500) / 2;
        yield return new WaitForSeconds(.5f);
        enemigos.currentHP = enemigos.maxHP;
        yield return new WaitForSeconds(1f);
        hud_D.dragon = dragonBoss.GetComponent<Enemigos>();
        yield return new WaitForSeconds(.1f);
        playerAtk.dragon = dragonBoss.GetComponent<Enemigos>();
        yield return new WaitForSeconds(.1f);
        playerMov.isMoving = false;
        yield return new WaitForSeconds(.1f);
        hud_D.lifebarEase.value = 0.01f;
        hud_D.lifebarEase.maxValue = enemigos.maxHP;
        yield return new WaitForSeconds(.1f);
        hud_D.lifebarEase_1.value = 0.01f;
        hud_D.lifebarEase_1.maxValue = enemigos.maxHP;
        yield return new WaitForEndOfFrame();
        hud_D.lifebar.maxValue = enemigos.maxHP;
        hud_D.lifebar.value = 0.01f;
        yield return new WaitForEndOfFrame();
        hud_D.lifebar_1.value = 0.01f;
        hud_D.lifebar_1.maxValue = enemigos.maxHP;
        yield return new WaitForSeconds(1f);
        isGaming = true;
        PlaySound(enemigos.self_Music);
    }

    public IEnumerator FinishLevel()
    {
        hud.ToogleHUD();
        yield return new WaitForEndOfFrame();
        audioSource.Stop();
        yield return new WaitForEndOfFrame();
        PlaySound(winMusic);
    }
    public IEnumerator DeathPlayer()
    {
        audioSource.Stop();
        GameManager.Instance.isGaming = false;
        playerPrefs.isdeath = false;
        yield return new WaitForEndOfFrame();
        PlaySound(sadMusic);
        player_anim.SetBool("Death", true);
        PlaySound(player_dead);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartCoroutine(StartLevel());
        }
    }
    public IEnumerator DeathDragon()
    {
        isGaming = false;
        yield return new WaitForEndOfFrame();
        PlaySound(dragonBoss.GetComponent<Enemigos>().self_Dragon);
        enemigos.anim.SetTrigger("Death");
        yield return new WaitForSeconds(3.5f);
        Destroy(dragonBoss);
        playerAtk.stats.gold += enemigos.valor_Dragon;
        StartCoroutine(FinishLevel());
        isUpgrading = true;
    }
    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip,.5f);
    }
}
