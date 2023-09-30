using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterStats : MonoBehaviour
{
    private bool dead = false;      
    public bool Dead {
        get {
            return dead;
        }
    }
    [SerializeField] public int health = 6;
    [SerializeField] public Healthbar hpbar;
    [SerializeField] public bool vulnerable = true;
    [Range(0, 5.0f)][SerializeField] public float invulnerabilityTimeDS = 0.1f;
    private Rigidbody2D body;
    private bool noDmg = false;
    private float noDmgTimer = 0;
   

    [Header("Events")]
	[Space]
    public UnityEvent onDeath;


    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        
        if (onDeath == null) {
            onDeath = new UnityEvent();
        } 
        if (hpbar != null) {
            hpbar.setMaxHealth(health);
        }
    }

    void Update() {
        if (hpbar != null) {
            hpbar.setHealth(health);
        }        
        if (health <= 0) {
            kill();
        } else if (noDmg) {
            GetComponent<SpriteRenderer>().color = Color.red;
        } else {
            GetComponent<SpriteRenderer>().color = Color.white;
        }

        //invulnerability period timer
        if (noDmg) {
            noDmgTimer += Time.deltaTime;
            if (noDmgTimer > invulnerabilityTimeDS) {
                noDmgTimer -= invulnerabilityTimeDS;
                noDmg = false;
            }
        }
        
    }

    public void damage(int damage, Vector2 kback) {
        if (!dead && !noDmg) {
            health -= damage;
            if (kback != new Vector2(0,0)) {
                body.velocity = (kback + new Vector2(0, 3));
            }
            noDmg = true;
        }
    }


    public void kill() {
        if (!dead) {
            health = 0;
            Vector3 scale = transform.localScale;
			scale.y *= -1;
			transform.localScale = scale;
			dead = true;
			body.AddForce(new Vector2(0f, 6));
            onDeath.Invoke();
            GetComponent<SpriteRenderer>().color = Color.red;
        }
    }

}
