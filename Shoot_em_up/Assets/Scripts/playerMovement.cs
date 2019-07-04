using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float Xincrement;
    public float Yincrement;
    public float speed;
    public Vector2 max;
    public Vector2 min;
    public Vector2 TargetPos;
    public Laser L;
    public HomingMissileLauncher HML;
    public Vulcan V;
    public ArmePrincipal ArmeP;
    public Arme myArme;
    public int life = 50;
    public GameObject bouclier;
    public GameObject DestructiveAura;
    public Transform weaponPos;
    bool switchedWeapon;
    public float bonusDuration;
    float startBonusDuration;
    // Start is called before the first frame update




    private void OnEnable()
    {
        GlobalEventNotifier.PickupABonus += OnBonusPickedUp;
    }
    void Start()
    {
        TargetPos = new Vector2(-11, 0);
        bouclier.SetActive(false);
        startBonusDuration = bonusDuration;
    }

    // Update is called once per frame
    void Update()
    {
        myArme.transform.position = weaponPos.position;
        if (life <= 0)
        {
            Destroy(gameObject);
        }

        if(life> 100)
        {
            life = 100;
        }
        transform.position = Vector2.MoveTowards(transform.position, TargetPos, speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.UpArrow) && transform.position.y < max.y)
        {
            TargetPos = new Vector2(transform.position.x, transform.position.y + Yincrement);
        } else if (Input.GetKey(KeyCode.DownArrow) && transform.position.y > min.y)
        {
            TargetPos = new Vector2(transform.position.x, transform.position.y - Yincrement);
        }

        if (Input.GetKey(KeyCode.RightArrow) && transform.position.x < max.x)
        {
            TargetPos = new Vector2(transform.position.x + Xincrement, transform.position.y);
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x > min.x)
        {
            TargetPos = new Vector2(transform.position.x - Xincrement, transform.position.y);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            myArme.Shoot();
        }
        
        if(Input.GetKeyDown(KeyCode.S))
        {
            bouclier.SetActive(true);
            bouclier.GetComponent<shield>().Initialize();
            

        }
        if(Input.GetKeyDown(KeyCode.A) && !DestructiveAura.activeInHierarchy)
        {
            DestructiveAura.SetActive(true);
        }
        if (switchedWeapon)
        {
            bonusDuration -= Time.deltaTime;
        }
        if(bonusDuration <= 0)
        {
            myArme = ArmeP;
            switchedWeapon = false;
            bonusDuration = startBonusDuration;
        }

    }

    public void  OnBonusPickedUp(enums.BonusType b)
    {

        
        switch (b)
        {
            
            case enums.BonusType.Laser: myArme = L; switchedWeapon = true;
                break;
            case enums.BonusType.Blaster: myArme = V; switchedWeapon = true;
                break;
            case enums.BonusType.HomingMissile: myArme = HML; switchedWeapon = true;
                break;
            case enums.BonusType.Life: if (life < 100) { life += 10; }
                break;
                case enums.BonusType.None:
                return;

        }
    }

    public void takeDamage(int damage)
    {
        life -= damage;
    }
    
}
