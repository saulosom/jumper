using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class draganddrop : MonoBehaviour
{
    public GameObject prefab;
    private Vector3 screenPoint;
    private Vector3 offset;

    private Vector3 initialPosition;
    private bool onGameSection;

    public BoxCollider2D gameSectionCollider;

    void Awake()
    {
        initialPosition = transform.position;
    }
    void OnMouseDown()
    {
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition;
    }

    void OnMouseUp()
    {
        if (!onGameSection)
            transform.position = initialPosition;
        else
            InstantiateOther();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name == "Game section")
        {
            onGameSection = true;
            Debug.Log("entrou");
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name == "Game section")
        {
            onGameSection = false;
            Debug.Log("saiu");
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col.gameObject.name);
        if (col.gameObject.name == "Game section")
        {
            onGameSection = true;
            Debug.Log("entrou");
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        Debug.Log(col.gameObject.name);
        if (col.gameObject.name == "Game section")
        {
            onGameSection = false;
            Debug.Log("saiu");
        }
    }
    
    
    void InstantiateOther()
    {
        GameObject GO = Instantiate(prefab,transform.parent);
        GO.transform.position = initialPosition;

    }
}
