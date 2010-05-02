
name("Dungeon 1") // The name of the map (eg. "Kitchen", "Main Hallway", etc.)
mapfile("dungeon_1.tmx") // The tmx map file being used
battleTexture("test-battle-background") // The texture for the background in battles

east("dungeon_2.js") // The map to the east.

var guard = newNPE() // New NPE creates a new NPE object.
guard.SetTexture("guard2_left") // Sets the overworld texture for the NPE

guard.SetPosition(5, 8)

var block = newNPE()

block.SetPosition(1,13)

block.SetInteractFunc(function(player) {
	if(getFlag("intro-dialogue")) {
	}
	else {
		setFlag("intro-dialogue")
		dialogue("Jordan: ...Ugh...|(Wh... where am I...?)|(So... hungry...)||???: What? How are you still conscious?!||Jordan: (Woah! Where is that voice coming from?!)||???: You've been lying here without food for a week! I was sure you'd be dead by now!!||Jordan: Who's there?|Ludovic: I'm Ludovic, a demon, and I've taken over your body.|I kind of was hoping you were a bit more DEAD, though...||Jordan: Gee, thanks...|Ludovic: You don't have to talk aloud, you know. I can hear your thoughts. And that guard over there is looking suspicious.|Anyway, we have to get out of this castle.||Jordan: (What is going on here?!)")
		reloadMap()
	}
} )

if(getFlag("intro-dialogue"))
{}
else
{
	addNPE(block)
}

guard.SetInteractFunc(function(player) { //Sets the interact function for the specified NPE
	if (getFlag("talked-to-guard")) {
		//dialogue("I have nothing more to say to you.") // Pushes on a dialogue state with the selected text
		dialogue("Basden: I said, stay in there! Don't make me force you!")
		var enemy = newEnemy("test-npe", "Disgruntled Guard", 100, 5, 1, 1, 25, null)
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

var ghost = newEnemy("ghostie", "Ghost of Doom", 50, 7, 1, 1, 10, null)
var pauper = newEnemy("snake", "Pauper of Evil", 80, 5, 1, 1, 10, null)

addRandomEncounter(ghost) //Adds a random encounter to the room
addRandomEncounter(pauper)