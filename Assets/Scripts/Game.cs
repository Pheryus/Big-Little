using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum RequestAction { none, pressZ, pressX };

public enum GameState { menu, level, death, gameover};

public static class Game {
    public static float minX = -2.3f, maxX = 2.3f;

    public static float objectSpeed = 4;

    public static float maxZoomValue = 1.5f;

    public const string obstacleTag = "Obstacle", rewardTag = "Reward";

    public static bool onRequestAction = false, tutorialActive = true;

    public static int level = 0;

    public static GameState state;

    public static int deaths = 0;

    public static bool CanMove() {
        return state == GameState.level;
    }


}
