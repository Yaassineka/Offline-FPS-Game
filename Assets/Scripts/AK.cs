using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AK : MonoBehaviour
{
    KillCounter killCounterScript;

    [SerializeField] private Animator animator;

    [SerializeField] Text ammotxt;
    [SerializeField] Text maxAmmotxt;
    public static int maxAmmo = 240;
    [SerializeField] int reloadAmmo = 0;
    [SerializeField] int numAmmo;
    bool isRealoading = false;


    [SerializeField] float damage = 10f;
    [SerializeField] float range = 100f;
    [SerializeField] float fireRate = 15f;
    [SerializeField] Camera cam;

    private float nextTimeToShoot = 0f;

    private void Start()
    {
        killCounterScript = GameObject.Find("KKK").GetComponent<KillCounter>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        maxAmmotxt.text = "/" + maxAmmo;
        ammotxt.text = "" + numAmmo;

        if (maxAmmo <= 0)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SoundManager.PlaySound("NoReload");
            }
        }

        if (maxAmmo > 240)
        {
            maxAmmo = 240;
        }
        if (maxAmmo <= 0)
        {
            maxAmmo = 0;
        }
        if (numAmmo <= 0)
        {
            numAmmo = 0;
        }

        if (Input.GetMouseButtonDown(0) && numAmmo <= 0 && isRealoading == false)
        {
            SoundManager.PlaySound("OutOfAmmo");
        }

        if (Input.GetButton("Fire1") && Time.time >= nextTimeToShoot && numAmmo > 0 && isRealoading == false)
        {

            nextTimeToShoot = Time.time + 1f / fireRate;
            SoundManager.PlaySound("Shoot");
            numAmmo--;
            Shoot();
        }
        if (Input.GetButtonUp("Fire1"))
        {
            animator.SetBool("Fire", false);
        }
        if (Input.GetKeyDown(KeyCode.R) && maxAmmo > 0 && numAmmo < 33)
        {
            Reload();
            isRealoading = true;

            animator.SetBool("Fire", false);
            animator.SetBool("Reloading", true);
            SoundManager.PlaySound("Reload");

            if (numAmmo >= 33)
            {
                isRealoading = false;
            }
        }
    }
    void Shoot()
    {
        if (Input.GetButton("Fire1"))
        {
            RaycastHit hit;
            animator.SetBool("Fire", true);
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
            {
                Debug.Log(hit.transform.name);

                EnemyController enemy = hit.transform.GetComponent<EnemyController>();
                if (enemy != null)
                {
                    enemy.TakeDamage(damage);
                }

            }
        }
    }
    void Reload()
    {
        StartCoroutine(Realoding());

        IEnumerator Realoding()
        {
            if (maxAmmo > 0 && numAmmo < 33)
            {

                yield return new WaitForSeconds(1.5f);

                animator.SetBool("Reloading", false);

                reloadAmmo = 33 - numAmmo;
                numAmmo = reloadAmmo + numAmmo;
                maxAmmo = maxAmmo - reloadAmmo;
                isRealoading = false;
            }
        }
    }
}
