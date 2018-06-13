using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
public class GameManager : IInitializable, ITickable
{
    [Inject] Settings _settings = null;

    private Enemy.Factory _enemiesFactory = null;
    private List<Enemy> _enemies = new List<Enemy>();

    private Player _player = null;

    private EndGameScreen _endGameScreen = null;

    private enum GameState
    {
        WON,
        LOSE,
        PLAYING
    }

    public GameManager(Enemy.Factory enemiesFactory, Player player, EndGameScreen endGameScreen)
    {
        _enemiesFactory = enemiesFactory;
        _player = player;
        _endGameScreen = endGameScreen;
    }

    public void Initialize()
    {
        for(int i = 0; i < _settings.EnemiesCount; i++)
        {
            _enemies.Add(_enemiesFactory.Create());
        }
    }

    public void Tick()
    {
        GameState gameState = HandleGameOver();
        if(gameState != GameState.PLAYING)
        {
            _endGameScreen.Display(gameState.ToString());
        }
    }
 

    private GameState HandleGameOver()
    {
        if(_player.IsDead)
        {
            return GameState.LOSE;
        }
        else if(AreEnemiesDead())
        {
            return GameState.WON;    
        }

        return GameState.PLAYING;

    }

    private bool AreEnemiesDead()
    {
        foreach (Enemy enemy in _enemies)
        {
            if (!enemy.IsDead)
            {
                return false;
            }
        }

        return true;
    }
    
    [Serializable]
    public class Settings
    {
        public int EnemiesCount;
    }
}
