
name("Dungeon 1") // The name of the map (eg. "Kitchen", "Main Hallway", etc.)
mapfile("dungeon_1.tmx") // The tmx map file being used
battleTexture("test-battle-background") // The texture for the background in battles

east("dungeon_2.js") // The map to the east.

var guard = newNPE() // New NPE creates a new NPE object.
guard.SetTexture("guard2_left") // Sets the overworld texture for the NPE

guard.SetPosition(5, 8)

guard.SetInteractFunc(function(player) { //Sets the interact function for the specified NPE
	if (getFlag("talked-to-guard")) {
		//dialogue("I have nothing more to say to you.") // Pushes on a dialogue state with the selected text
		dialogue("Basden: I said, stay in there! Don't make me force you!")
		var enemy = newEnemy("test-npe", "Disgruntled Guard Basden", 50, 5, 2, 1, 25, null)
		battle(player, enemy)
		setFlag("battled-guard")
		reloadMap()
	} else {
		dialogue("Basden: Get back in your cell, prisoner.")
		setFlag("talked-to-guard") // Sets a flag to "true"
		reloadMap() // Reloads the map
	}
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

var ghost = newEnemy("ghostie", "Ghost of Doom", 30, 7, 1, 1, 10, null)
var pauper = newEnemy("snake", "Pauper of Evil", 50, 5, 1, 1, 10, null)

addRandomEncounter(ghost) //Adds a random encounter to the room
addRandomEncounter(pauper)