using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject mag;
    public GameObject muzzle;
    public int times;

    void FixedUpdate()
    {
        Vector2 mousePos = Input.mousePosition;

        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        if (Input.GetMouseButtonDown(0) && times > 0)
        {
            times--;
            GameObject bull = Instantiate(mag, muzzle.transform.position, Quaternion.identity);
            bull.GetComponent<Rigidbody2D>().AddForce(gameObject.transform.right * 500f, ForceMode2D.Force);
        }
    }
}
