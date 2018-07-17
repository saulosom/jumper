using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class draganddrop : MonoBehaviour {

	public Vector3 screenPoint;
    public Vector3 offset;
    
    public Vector3 initialPosition;
    private bool onGameSection;

    public BoxCollider2D gameSectionCollider;
	void OnMouseDown() 
    {
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        initialPosition = transform.position;
    }

    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition;        
    }

    void OnCollisionEnter(Collision collision)
    {
        onGameSection = true;
        Debug.Log("entrou");
    }
    void OnCollisionExit(Collision collision)
    {
        onGameSection = false;
        Debug.Log("saiu");
    }

    void OnMouseUp()
    {
        if (!onGameSection)
            transform.position = initialPosition;
    }
}
