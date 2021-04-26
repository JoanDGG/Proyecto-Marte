using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    // Variables globales
    public static string GamerTag;
    public static int nivelGlobal = 0;
    //          0 -> MenuPrincipal
    //          1 -> Nivel Nave
    //          2 -> Nivel Robot
    //          3 -> Nivel Coche
    //          4 -> Nivel Agro
    //          5 -> Colonia
    public static string[] preguntas = new string[16];
    public static string[] preguntasID = new string[16];
    public static List<string[]> opciones = new List<string[]>();
    public static string[] opciones_correctas = new string[16];
    public static string respuesta_actual;
    public static int pregunta_actual;
    public static bool correcta;
    public static int resena;

    // variables estáticas de nivel agropecuario
    public static bool primero = true;
    public static int tiempo = 0;
    public static int tiempoLimite = 60;
    public static bool evento = false;
    public static int tiempoEvento = 5;
    public static int reloj = tiempoLimite;
    public static bool[] resist = new bool[4];
    public static bool perder = false;
    public static int pagina = 0;
    public static int[] clima = new int[3];
    public static int[] genes = new int[3];
    public static int oleada = 1;
    public static bool respondido = false;
    public static string[] respuestas = new string[3];
    public static float puntuacion = 0.0f;

    // Variables estáticas de nivel industrial.
    // Precios.
    public static int precioCuerpo = 21;
    public static int precioLlantas = 10;
    public static int precioFrenos = 8;
    public static int precioSuspension = 5;
    public static int precioChasis = 10;
    public static int precioMotor = 8;
    public static int budget = 100 - (precioCuerpo + precioLlantas + precioFrenos + precioSuspension + precioChasis + precioMotor);// presupuesto con las partes más baratas en todas las categorías.

    // Índices de partes para reconstruir auto en escena distinta.
    public static int[] cuerpo = { 0, 0};
    public static int[] llantas = { 1, 0 };
    public static int[] frenos = { 2, 0 };
    public static int[] suspensiones = { 3, 0};
    public static int[] chasis = { 4, 0};
    public static int[] motor = { 5, 6};

    // Valores de cualidades asociados con las partes del automóvil.
    public static float volumen;
    public static float friccionLlantasEnHielo;
    public static float friccionLlantasArranque;
    public static float fuerzaFreno;
    public static float calidadAmortiguamiento;
    public static float resistencia;
    public static float fuerzaMotor;
    public static float velocidadMaxima;

    // Valores máximos de las cualidades para tener la referencia al establecer las cualidades.
    public static float volumenMaximo = 10f;
    public static float friccionLlantasEnHieloMaxima = 1f;
    public static float friccionLlantasArranqueMaxima = 600f;
    public static float fuerzaFrenoMaxima = -300f;
    public static float calidadAmortiguamientoMaxima = 0f;
    public static float resistenciaMaxima = 1f;
    public static float fuerzaMotorMaxima = 200f;
    public static float velocidadMaximaMaxima = 20f;

    // Número de items recolectados con automóvil.
    public static int itemsRecolectados = 0;

    // Si el auto está tocando el suelo con alguna de sus llantas.
    public static bool tocandoSueloLlantas;

    // El dano que recibe el auto (resistencia).
    public static float dano;

    // Los segundos que tardó.
    public static float numeroSegundos;

    // La puntuacion del nivel del carro.
    public static float puntuacionNivelCarro;
}
