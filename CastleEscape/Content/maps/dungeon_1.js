
name("Dungeon 1") // The name of the map (eg. "Kitchen", "Main Hallway", etc.)
mapfile("starting_location.tmx") // The tmx map file being used
battleTexture("test-battle-background") // The texture for the background in battles

east("dungeon_2.js") // The map to the east.
//west("blah")
//etc...

var guard = newNPE() // New NPE creates a new NPE object.
guard.SetTexture("test-npe") // Sets the overworld texture for the NPE
var demon = newNPE()
demon.SetTexture("ghostie")
demon.SetPosition(1,14)

if (getFlag("talked-to-guard")) { //getFlag(<string>) returns true if the key is set, false otherwise
	bob.SetPosition(21,16)
} else {
	bob.SetPosition(6, 9)
}

guard.SetInteractFunc(function(player) { //Sets the interact function for the specified NPE
	if (getFlag("talked-to-guard")) {
		//dialogue("I have nothing more to say to you.") // Pushes on a dialogue state with the selected text
	} else {
		dialogue("Get back in your cell, prisoner.")
		//newEnemy() creates a new enemy object. Parameters are...
		//texture name, enemy name, health, attack, defense, speed, exp, array of items
		//var enemy = newEnemy("test-npe", "Bob: The Monarch of Entropy", 50000, 70, 1, 1, 10, null)
		//battle(player, enemy) //Starts a battle with the player and the enemy
		setFlag("talked-to-guard") // Sets a flag to "true"
		reloadMap() // Reloads the map
	}
})

demon.SetInteractFunc(function(player) { //Sets the interact function for the specified NPE
	if (getFlag("talked-to-demon")) {
		//dialogue("I have nothing more to say to you.") // Pushes on a dialogue state with the selected text
	} else {
		dialogue("This empty shell looks like a great body to take over!||||Hahaha! Here I go!")
		//newEnemy() creates a new enemy object. Parameters are...
		//texture name, enemy name, health, attack, defense, speed, exp, array of items
		//var enemy = newEnemy("test-npe", "Bob: The Monarch of Entropy", 50000, 70, 1, 1, 10, null)
		//battle(player, enemy) //Starts a battle with the player and the enemy
		setFlag("talked-to-demon") // Sets a flag to "true"
		reloadMap() // Reloads the map
	}
})

// Adds an NPE to the room. It's important that you call this function.
//Otherwise, the NPE won't appear in the room.
addNPE(guard)

if(getFlag("talked-to-guard") && !getFlag("talked-to-demon")) {
	addNPE(ghostie)
}

if(getFlag("talked-to-demon))
{
	dialogue("What?|This body is still... alive?|||...||||.....||||.........||||NOOOOOOOOOOOOO!|This means...|I'm trapped!")
}

var saveOrb = newNPE()
saveOrb.SetTexture("orb-of-saving")
saveOrb.SetPosition(2, 15)

saveOrb.SetInteractFunc(function(player) {
	save(player) // Saves the game. Try to use this function only with the orb of saving.
	dialogue("Game has been saved.")
})

addNPE(saveOrb)

//var wormStore = newNPE()
//wormStore.SetTexture("snake")
//wormStore.SetPosition(15, 1)

/*wormStore.SetInteractFunc(function(player) {
	var items = [] //Create a Javascript array as such.
	//newItem() creates a new item object. Parameters are...
	// Item name, item description, health bonus, mana bonus, cost
	items[0] = newItem("Bottle of Mead", "A tasty, tasty bottle of mead.", 100, 30, 10)
	store(player, items) // Pushes on a store state. Parameters are the player and an array of items.
})*/

//addNPE(wormStore)

var ghost = newEnemy("ghostie", "Ghost of Doom", 50, 7, 1, 1, 1000, null)
var pauper = newEnemy("snake", "Pauper of Evil", 80, 5, 1, 1, 1000, null)

if(getFlag("talked-to-demon")) {
	addRandomEncounter(ghost) //Adds a random encounter to the room
	addRandomEncounter(pauper)
}
