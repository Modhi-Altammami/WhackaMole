using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorEditor : MonoBehaviour
{
    [SerializeField] Texture2D Hammer;
    [SerializeField] Texture2D HitHammer;
    private Vector2 cursorOffset;

    void Start()
    {
         cursorOffset = new Vector2(Hammer.width / 5, Hammer.height / 4);

        Cursor.SetCursor(Hammer, cursorOffset, CursorMode.ForceSoftware);

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Cursor.SetCursor(HitHammer, cursorOffset, CursorMode.ForceSoftware);
        }

        if (Input.GetMouseButtonUp(0))
        {
            Cursor.SetCursor(Hammer, cursorOffset, CursorMode.ForceSoftware);
        }
    }
    
}
