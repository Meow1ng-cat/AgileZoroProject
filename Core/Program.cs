using Zoro.Core;
using Zoro.Entities.UI;
using Zoro.Entities.Units;
using Zoro.Entities.Weapons;
using Zoro.Sprites;

GameMap GameMap = new GameMap(50, 209);
PlayerController PlayerController = new PlayerController();

GameEngineFacade.StartGame(GameMap, PlayerController);
GameEngineFacade.TestPatterns(GameMap, PlayerController);

