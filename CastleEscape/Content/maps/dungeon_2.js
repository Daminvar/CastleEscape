
name("Dungeon 2") // The name of the map (eg. "Kitchen", "Main Hallway", etc.)
mapfile("dungeon_2.tmx") // The tmx map file being used
battleTexture("test-battle-background") // The texture for the background in battles

west("dungeon_1.js") 
north("dungeon_3.js")
south("dungeon_4.js")

var ghost = newEnemy("ghostie", "Ghost of Doom", 50, 7, 1, 1, 10, null)
var pauper = newEnemy("snake", "Pauper of Evil", 80, 7, 1, 1, 15, null)
addRandomEncounter(ghost) //Adds a random encounter to the room
addRandomEncounter(pauper)
