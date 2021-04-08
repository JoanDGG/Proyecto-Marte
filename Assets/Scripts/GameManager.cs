using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    public static bool primero = true;
    public static int tiempo = 0;
    public static int tiempoLimite = 15;
    public static bool evento = false;
    public static int tiempoEvento = 5;
    public static int reloj = tiempoLimite;
    public static bool resFrio = false;
    public static bool resCalor = false;
    public static bool resTor = false;
    public static bool resSeq = false;
    public static bool resFrioAux = false;
    public static bool resCalorAux = false;
    public static bool resTorAux = false;
    public static bool resSeqAux = false;
    public static bool perder = false;
    public static int pagina = 0;
    public static int clima = 0;
    public static int[] genes = new int[3];
    // variables estáticas de nivel industrial, indican las partes escogidas del automovil.
    public static Sprite spriteCuerpo;
    public static Sprite spriteLlantas;
    public static Sprite spriteFrenos;
    public static Sprite spriteSuspensiones;
    public static Sprite spriteChasis;
    public static Sprite spriteMotor;
}
