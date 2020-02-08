using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSelf : MonoBehaviour
{
    public DirCompass RotateSprite(Transform tf, DirCompass dir)
    {
        DirCompass newDir = NextDirection(dir);
        tf.localRotation = Quaternion.Euler(0f,0f,(float)dir-45f);
        return newDir;
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
