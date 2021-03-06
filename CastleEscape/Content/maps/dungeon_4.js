
name("Dungeon 4") // The name of the map (eg. "Kitchen", "Main Hallway", etc.)
mapfile("dungeon_4.tmx") // The tmx map file being used
overworldMusic("dungeon-song")
randomBattleMusic("regular-battle-song")
battleTexture("stone-wall") // The texture for the background in battles

north("dungeon_2.js")
east("HallWay1.js")

var guard = newNPE() // New NPE creates a new NPE object.
guard.SetTexture("guard1_left") // Sets the overworld texture for the NPE
//var demon = newNPE()
//demon.SetTexture("ghostie")

if(getFlag("go-to-kitchen"))
{
	guard.SetPosition(18,6)
}
else
{
	guard.SetPosition(19,7)
}

guard.SetInteractFunc(function(player) { //Sets the interact function for the specified NPE
	if (getFlag("has-hat")) {
		dialogue("Ceyol: Oh, you must be the plumber! What are you doing in the dungeon? Please, go on through! You're needed in the kitchens.|Jordan: (That was... easier than expected.)") // Pushes on a dialogue state with the selected text
		setFlag("go-to-kitchen")
		reloadMap()
	} else {
		dialogue("Ceyol: Why are you out of your cell? Out, you!|Jordan: (Ack! I better get out of here before I get thrown into a cell again!!)")
	}
})

addNPE(guard)

var saveOrb = newNPE()
saveOrb.SetTexture("orb-of-saving")
saveOrb.SetPosition(4, 13)

saveOrb.SetInteractFunc(function(player) {
	save(player) // Saves the game. Try to use this function only with the orb of saving.
	dialogue("Game has been saved.")
})

addNPE(saveOrb)


var ghost = newEnemy("ghost1_battle", "Ghost of Doom", 30, 30, 1, 1, 10, null)
var pauper = newEnemy("skeleton1_battle", "Skeleton of Evil", 50, 25, 1, 1, 10, null)

addRandomEncounter(ghost) //Adds a random encounter to the room
addRandomEncounter(pauper)
