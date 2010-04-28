
name("Dungeon 3") // The name of the map (eg. "Kitchen", "Main Hallway", etc.)
mapfile("dungeon_3.tmx") // The tmx map file being used
battleTexture("test-battle-background") // The texture for the background in battles

south("dungeon_2.js")
//east("hallway1.js")

var drunkenGuard = newNPE() // New NPE creates a new NPE object.
drunkenGuard.SetTexture("test-npe") // Sets the overworld texture for the NPE
//var demon = newNPE()
//demon.SetTexture("ghostie")

drunkenGuard.SetPosition(18,3)

//if (getFlag("talked-to-guard")) { //getFlag(<string>) returns true if the key is set, false otherwise
//	bob.SetPosition(21,16)
//} else {
//	bob.SetPosition(6, 9)
//}

drunkenGuard.SetInteractFunc(function(player) { //Sets the interact function for the specified NPE
	if (getFlag("talked-to-drunk")) {
		dialogue("uuuuggghhhh...") // Pushes on a dialogue state with the selected text
	} else {
		dialogue("Uuugghhh... my head...|Hey, who're you...?|||...ain't you that prishoner...?||||...hey, get backta yer cell!")
		newEnemy() //creates a new enemy object. Parameters are...texture name, enemy name, health, attack, defense, speed, exp, array of items
		var drunkItems = []
		drunkItems[0] = newItem("Bottle of Mead", "A tasty, tasty bottle of mead.", 100, 30, 10)
		drunkItems[1] = newItem("Red hat", "This looks familiar...", 0, 0, 0)
		var enemy = newEnemy("test-npe", "Drunken Guard", 200, 12, 3, 0, 30, drunkItems)
		battle(player, enemy) //Starts a battle with the player and the enemy
		setFlag("talked-to-guard") // Sets a flag to "true"
		reloadMap() // Reloads the map
	}
})

// Adds an NPE to the room. It's important that you call this function.
//Otherwise, the NPE won't appear in the room.
addNPE(drunkenGuard)

//if(getFlag("talked-to-guard")) {
//	addNPE(ghostie)
//}

//var saveOrb = newNPE()
//saveOrb.SetTexture("orb-of-saving")
//saveOrb.SetPosition(2, 15)

//saveOrb.SetInteractFunc(function(player) {
//	save(player) // Saves the game. Try to use this function only with the orb of saving.
//	dialogue("Game has been saved.")
//})

//addNPE(saveOrb)

var wormStore = newNPE()
wormStore.SetTexture("snake")
wormStore.SetPosition(5, 5)

wormStore.SetInteractFunc(function(player) {
	var items = [] //Create a Javascript array as such.
	//newItem() creates a new item object. Parameters are...
	// Item name, item description, health bonus, mana bonus, cost
	items[0] = newItem("Bottle of Mead", "A tasty, tasty bottle of mead.", 100, 30, 10)
	store(player, items) // Pushes on a store state. Parameters are the player and an array of items.
})

addNPE(wormStore)

var spirits = []
spirits[0] = newItem("Spirit's Spirit", "An aged bottle of wine.", 20, 20, 10)

var ghost = newEnemy("ghostie", "Ghost of Doom", 50, 7, 1, 1, 10, null)
var pauper = newEnemy("snake", "Pauper of Evil", 80, 7, 1, 1, 15, null)
var spirit = newEnemy("ghostie", "Spirit", 85, 5, 1, 2, 17, spirits)
addRandomEncounter(ghost) //Adds a random encounter to the room
addRandomEncounter(pauper)
addRandomEncounter(spirit)

setFlag("has-hat") //REMOVE THIS WHEN DOING MAPS FO REALS.
