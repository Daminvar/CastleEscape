
name("Dungeon 2") // The name of the map (eg. "Kitchen", "Main Hallway", etc.)
mapfile("dungeon_2.tmx") // The tmx map file being used
overworldMusic("dungeon-song")
randomBattleMusic("regular-battle-song")
battleTexture("stone-wall") // The texture for the background in battles

west("dungeon_1.js") 
north("dungeon_3.js")
south("dungeon_4.js")

var ghost = newEnemy("ghost1_battle", "Ghost of Doom", 30, 7, 1, 1, 10, null)
var pauper = newEnemy("skeleton1_battle", "Skeleton of Evil", 50, 5, 1, 1, 10, null)
addRandomEncounter(ghost) //Adds a random encounter to the room
addRandomEncounter(pauper)
