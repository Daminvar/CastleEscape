
name("Dungeon 3") // The name of the map (eg. "Kitchen", "Main Hallway", etc.)
mapfile("dungeon_3.tmx") // The tmx map file being used
battleTexture("test-battle-background") // The texture for the background in battles

south("dungeon_2.js")

var drunkenGuard = newNPE() // New NPE creates a new NPE object.
drunkenGuard.SetTexture("guard1_front") // Sets the overworld texture for the NPE

drunkenGuard.SetPosition(18,3)

//if (getFlag("talked-to-guard")) { //getFlag(<string>) returns true if the key is set, false otherwise
//	bob.SetPosition(21,16)
//} else {
//	bob.SetPosition(6, 9)
//}

drunkenGuard.SetInteractFunc(function(player) { //Sets the interact function for the specified NPE
	if (getFlag("has-hat")) {
		dialogue("Marim: uuuuggghhhh...||||Jordan: (Good riddance.)") // Pushes on a dialogue state with the selected text
	} else {
		dialogue("Marim: Uuugghhh... my head...|Hey, who're you...?|||Jordan: ...No one important...|(I need to find an exit somewhere!)|||Marim: ...ain't you that prishoner...?||||Jordan: (No! He's really drunk... maybe I can fool him!)|No, I'm... a janitor!|||Marim: ...get backta yer cell!")
		var drunkItems = []
		drunkItems[0] = newItem("Bottle of Mead", "A tasty, tasty bottle of mead.", 100, 30, 10)
		var enemy = newEnemy("test-npe", "Drunken Guard Marim", 60, 6, 3, 0, 30, null)
		battle(player, enemy) //Starts a battle with the player and the enemy
		dialogue("The guard was holding a very bright red hat, which Jordan picks up.")
		setFlag("has-hat") // Sets a flag to "true"
		reloadMap() // Reloads the map
	}
})

// Adds an NPE to the room. It's important that you call this function.
//Otherwise, the NPE won't appear in the room.
addNPE(drunkenGuard)

var bar = newNPE()
bar.SetTexture("waiter_left")
bar.SetPosition(4, 4)

bar.SetInteractFunc(function(player) {
	var items = [] //Create a Javascript array as such.
	//newItem() creates a new item object. Parameters are...
	// Item name, item description, health bonus, mana bonus, cost
	items[0] = newItem("Bottle of Mead", "A tasty, tasty bottle of mead.", 100, 30, 10)
	store(player, items) // Pushes on a store state. Parameters are the player and an array of items.
})

addNPE(bar)

var spirits = []
spirits[0] = newItem("Spirit's Spirit", "An aged bottle of wine.", 20, 20, 10)

var ghost = newEnemy("ghostie", "Ghost of Doom", 50, 7, 1, 1, 10, null)
var pauper = newEnemy("snake", "Pauper of Evil", 80, 7, 1, 1, 15, null)
var spirit = newEnemy("ghostie", "Spirit", 85, 5, 1, 2, 17, spirits)
addRandomEncounter(ghost) //Adds a random encounter to the room
addRandomEncounter(pauper)
addRandomEncounter(spirit)
