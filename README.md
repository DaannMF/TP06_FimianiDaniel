# Trabajo Práctico N°06

- Fecha de Inicio: 28/10/2024 19:00:00
- Fecha de Fin: 18/11/2024 23:59:59

Contenidos que se repasarán:

- ScriptableObjects.
- Audio.
- Animaciones.
- Canvas World.
- Scenes.
- Publicación.

Crear un juego de estilo Platformer 2D con jugabilidad similar a:

1. [Hollow Knight](https://www.youtube.com/watch?v=G1atkq4C1KU)
2. [Timespinner](https://youtu.be/sJX72amMDqM?t=3577)

## Platformer 2D

### General

- ✅ Crear un nuevo repositorio con nombre: “TP06_ApellidoNombre”.
- ✅ Crear un proyecto de Unity con el mismo nombre.
- ✅ Hay al menos 2 escenas: 1-MainMenu, 2-GamePlay.
- El juego debe estar publicado en Itchio y ser presentable (Entregar ambos links en BB).

### Jugador

- ✅ Puede moverse hacia la derecha y hacia la izquierda.
- ✅ Debe poder dañar de alguna manera a enemigos.
- ✅ Debe poder saltar.
- ✅ Posee barra de vida.
- ✅ Posibilidad de curarse.
- Todas sus acciones están animadas y con sonido.

### Enemigos

- ✅ Le quitan vida al Jugador.
- ✅ Poseen barra de vida.
- ✅ El jugador les puede quitar vida de alguna manera.
- ✅ Feedback visual al morir. (Partículas o algo).
- Todas sus acciones están animadas y con sonido.

### Pickables

- ✅ El jugador se cura.
- ✅ El jugador aumenta el daño.
- El jugador no puede recibir daño durante 10 segundos.
- Monedas.

### Sonido

- ✅ Audio Mixer: Master, Music, FX, Ui.
- ✅ Al menos 3 deben poder ser modificados por sliders en Settings.
- Toda acción del juego debe reflejarse en sonido.

### Datos

- Todas las configuraciones del juego / Nivel deben estar en un “ScriptableObject".
- Los datos de la partida deben guardarse en “PlayerPrefs” (Máximo score alcanzado, Monedas,
etc).

### Extras

- ✅ El juego se puede jugar a través de la Web sin descargar (Build WebGL).
- ✅ El jugador posee Doble Salto.
- ✅ El jugador posee Triple Salto a través de un power up.
- Tienda: Con las Monedas se pueden comprar cosas (Ej: Chaleco, +Daño, +VidaMax, etc).
