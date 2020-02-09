using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSelf : MonoBehaviour
{
    public Sprite spriteE;
    public Sprite spriteN;
    public Sprite spriteNE;
    public Sprite spriteNW;
    public Sprite spriteS;
    public Sprite spriteSE;
    public Sprite spriteSW;
    public Sprite spriteW;

    public DirCompass RotateSprite(Transform tf, DirCompass dir,bool next = true)
    {
        DirCompass newDir = dir;
        
        SpriteRenderer spriteR= GetComponentInChildren<SpriteRenderer>();
        if (next)
        {
            newDir = NextDirection(dir);
        }
        if (tf != null)
        {
            if (spriteR != null)
            {
                tf.localRotation = Quaternion.Euler(0f,0f,0f);
                UpdateSpriteOnDirection(newDir,spriteR);
            }
            else
            {
                tf.localRotation = Quaternion.Euler(0f,0f,(float)dir - 45f);
            }
        }
        return newDir;
    }
    void UpdateSpriteOnDirection(DirCompass dir,SpriteRenderer sr)
    {
        switch (dir)
        {
            case DirCompass.N: sr.sprite = spriteN;
                break;
            case DirCompass.NW: sr.sprite = spriteNW;
                break;
            case DirCompass.W: sr.sprite = spriteW;
                break;
            case DirCompass.SW: sr.sprite = spriteSW;
                break;
            case DirCompass.S: sr.sprite = spriteS;
                break;
            case DirCompass.SE: sr.sprite = spriteSE;
                break;
            case DirCompass.E: sr.sprite = spriteE;
                break;
            case DirCompass.NE: sr.sprite = spriteNE;
                break;
            default:
                break;
        }
    }

    public DirCompass NextDirection(DirCompass d)
    {
        switch (d)
        {
            case DirCompass.N:
                return DirCompass.NE;
            case DirCompass.NW:
                return DirCompass.N;
            case DirCompass.W:
                return DirCompass.NW;
            case DirCompass.SW:
                return DirCompass.W;
            case DirCompass.S:
                return DirCompass.SW;
            case DirCompass.SE:
                return DirCompass.S;
            case DirCompass.E:
                return DirCompass.SE;
            case DirCompass.NE:
                return DirCompass.E;
            default:
                return DirCompass.N;
        }
    }
}
