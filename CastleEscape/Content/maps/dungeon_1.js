
name("Dungeon 1") // The name of the map (eg. "Kitchen", "Main Hallway", etc.)
mapfile("dungeon_1.tmx") // The tmx map file being used
overworldMusic("dungeon-song")
randomBattleMusic("regular-battle-song")
battleTexture("stone-wall") // The texture for the background in battles

east("dungeon_2.js") // The map to the east.

var guard = newNPE() // New NPE creates a new NPE object.
guard.SetTexture("guard2_left") // Sets the overworld texture for the NPE

guard.SetPosition(5, 8)

guard.SetInteractFunc(function(player) { //Sets the interact function for the specified NPE
		dialogue("Basden: Who are you talking to?! Show yourself to me! Don't make me force you!!")
		var enemy = newEnemy("soldier1_battle", "Disgruntled Guard Basden", 50, 5, 2, 1, 25, null)
		battle(player, enemy, "regular-battle-song")
		setFlag("battled-guard")
		reloadMap()
})

// Adds an NPE to the room. It's important that you call this function.
if(getFlag("battled-guard"))
{
}
else
{
	addNPE(guard)
}

var saveOrb = newNPE()
saveOrb.SetTexture("orb-of-saving")
saveOrb.SetPosition(3, 14)

saveOrb.SetInteractFunc(function(player) {
	save(player) // Saves the game. Try to use this function only with the orb of saving.
	dialogue("Game has been saved.")
})

addNPE(saveOrb)

var ghost = newEnemy("ghost1_battle", "Ghost of Doom", 30, 7, 1, 1, 10, null)
var pauper = newEnemy("skeleton1_battle", "Skeleton of Evil", 50, 5, 1, 1, 10, null)

addRandomEncounter(ghost) //Adds a random encounter to the room
addRandomEncounter(pauper)