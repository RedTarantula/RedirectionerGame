﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariablesManager : MonoBehaviour
{
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

    public V2Int GetTargetCell(V2Int startCell, DirCompass dir)
    {
        int px = startCell.x;
        int py = startCell.y;

        switch (dir)
        {
            case DirCompass.N: py++;
                break;
            case DirCompass.NW: px--;py++;
                break;
            case DirCompass.W: px--;
                break;
            case DirCompass.SW: px--; py--;
                break;
            case DirCompass.S: py--;
                break;
            case DirCompass.SE: px++; py--;
                break;
            case DirCompass.E: px++;
                break;
            case DirCompass.NE: px++; py++;
                break;
            default: Debug.LogError("Impossible Direction");
                break;
        }
        return new V2Int(px,py);
    }

    internal DirCompass GetRandomDir()
    {
        int i = UnityEngine.Random.Range(0,8);
        switch (i)
        {
            case 0:
                return DirCompass.N;
            case 1:
                return DirCompass.NE;
            case 2:
                return DirCompass.NW;
            case 3:
                return DirCompass.E;
            case 4:
                return DirCompass.W;
            case 5:
                return DirCompass.S;
            case 6:
                return DirCompass.SE;
            case 7:
                return DirCompass.SW;
            default:
                return DirCompass.N;
        }
    }
}
[Serializable]
public struct V2Int
{
    public int x;
    public int y;

    public V2Int(int _x = 0, int _y = 0)
    {
        x = _x;
        y = _y;
    }

    public static explicit operator Vector2(V2Int v)
    {
        return new Vector2(v.x,v.y);
    }
}
public enum DirCompass {N=0,NW=45,W=90,SW=135,S=180,SE=225,E=270,NE=315};
