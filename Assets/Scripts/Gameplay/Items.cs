using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Items : MonoBehaviour
{
    public GameObject hand;
    public List<GameObject> items;
    public GameObject stdHand;
    public GameObject parent;

    private AttackController wep;
    public int numberItems = 1;

    void Awake()
    {
        wep = transform.gameObject.AddComponent<AttackController>();

        if (stdHand == null) {
            stdHand = new GameObject();
        }

        items = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hand == null) {
            equip(stdHand);
        }

        if (wep.weapon != hand) {
            wep.weapon = hand;
        }

        if (Input.GetKeyDown(KeyCode.Q) && items.Count > 0) {
            cycle();
        }

        if (Input.GetKeyDown(KeyCode.F) && hand != null && hand != stdHand) {
            drop(hand);
        } 
    }

    public bool pick(GameObject item) {
        if(items.Count < numberItems) {
                GameObject obj = GameObject.Instantiate(item, parent.transform);
                if (hand == stdHand) {
                    equip(obj);
                } else {
                    obj.SetActive(false);
                    items.Add(obj);
                }
                return true;
            }
        return false;
    }

    private void equip(GameObject item) {
        wep.enabled = false;
        hand = item;
        hand.SetActive(true);
        wep.weapon = hand;
        wep.enabled = true;
    }

    private void cycle() {
        hand.SetActive(false);
        items.Add(hand);
        equip(items[0]);
        items.Remove(hand);
        items.TrimExcess();
    }

    public void drop(GameObject item) {
        GameObject obj = GameObject.Instantiate(hand.GetComponent<Attacks>().item, hand.transform.position, Quaternion.identity);
        obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 100));
        items.Remove(hand);
        items.TrimExcess();
        Destroy(hand);
    }

}
