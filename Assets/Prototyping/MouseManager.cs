using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MouseManager : MonoBehaviour
{
    //What Objects are clickable
    public LayerMask clickableLayer;

    //Swap cursors per objects # Icons
    public Texture2D pointer; // Normal Pointer
    public Texture2D target; // Cursor for clickable objects like the world
    public Texture2D doorway; // Cursor for foorways
    public Texture2D combat; // Cursor for combat actions

    public EventVector3 OnClickEnviroment; // creamos un evento del tipo de la clase que hereda de UnityEvent

    void Update()
    {
        RaycastHit hit;
        float maxDistance = 50;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, maxDistance, clickableLayer.value))
        {
            bool door = false;
            if (hit.collider.gameObject.tag == "Doorway")
            {
                Cursor.SetCursor(doorway, new Vector2(16, 16), CursorMode.Auto);
                door = true;
            }
            else
            {
                Cursor.SetCursor(target, new Vector2(16, 16), CursorMode.Auto);
            }

            if (Input.GetMouseButtonDown(0)) // left button mouse
            {
                OnClickEnviroment.Invoke(hit.point); // Invocamos el evento
            }
        }
        else // raycast not found
        {
            Cursor.SetCursor(pointer, Vector2.zero, CursorMode.Auto);
        }
    }
}

[System.Serializable] // Permite al editor interpretar la clase como un atributo interno.
public class EventVector3 : UnityEvent<Vector3> { }; // Creamos una clase que hereda de UnityEvent 
                                                     //Pasandole por template el parametro que necesitamos