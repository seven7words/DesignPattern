using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public    class GameFacade
{
    private static GameFacade _instance = new GameFacade();
    public static GameFacade Instance { get { return _instance; } }
    private GameFacade()
    {
        
    }
    private bool mIsGameOver = false;

    public bool isGameOver
    {
        get { return mIsGameOver; }
    }
        public void Init()
        {
            
        }

        public void Update()
        {
            
        }

        public void Release()
        {
            
        }
    }

