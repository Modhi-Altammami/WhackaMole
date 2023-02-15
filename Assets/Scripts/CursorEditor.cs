using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Modhi.WhackAMole
{
    public class CursorEditor : MonoBehaviour
    {
        [SerializeField] Texture2D Hammer;
        [SerializeField] Texture2D HitHammer;
        
        private Vector2 cursorOffset;
        private AudioSource Pop;

        void Start()
        {
            cursorOffset = new Vector2(Hammer.width / 10, Hammer.height / 4);

            Cursor.SetCursor(Hammer, cursorOffset, CursorMode.ForceSoftware);

            Pop = GetComponent<AudioSource>();

        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Cursor.SetCursor(HitHammer, cursorOffset, CursorMode.ForceSoftware);
                Pop.Play();
            }

            if (Input.GetMouseButtonUp(0))
            {
                Cursor.SetCursor(Hammer, cursorOffset, CursorMode.ForceSoftware);
            }
        }

    }
}