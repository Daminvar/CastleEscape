
name("Dungeon 4") // The name of the map (eg. "Kitchen", "Main Hallway", etc.)
mapfile("dungeon_4.tmx") // The tmx map file being used
battleTexture("test-battle-background") // The texture for the background in battles

north("dungeon_2.js")
east("HallWay1.js")

var guard = newNPE() // New NPE creates a new NPE object.
guard.SetTexture("test-npe") // Sets the overworld texture for the NPE
//var demon = newNPE()
//demon.SetTexture("ghostie")

guard.SetPosition(19,7)

//if (getFlag("has-hat")) { //getFlag(<string>) returns true if the key is set, false otherwise
//	bob.SetPosition(21,16)
//} else {
//	bob.SetPosition(6, 9)
//}

guard.SetInteractFunc(function(player) { //Sets the interact function for the specified NPE
	if (getFlag("has-hat")) {
		dialogue("Oh, you must be the plumber!|What are you doing in the dungeon? Please, go on through!|You're needed in the kitchens.") // Pushes on a dialogue state with the selected text
		guard.SetPosition(17,11)
	} else {
		dialogue("Why are you out of your cell? Out, you!")
	}
})

// Adds an NPE to the room. It's important that you call this function.
//Otherwise, the NPE won't appear in the room.
addNPE(guard)

//var wormStore = newNPE()
//wormStore.SetTexture("snake")
//wormStore.SetPosition(5, 5)

//wormStore.SetInteractFunc(function(player) {
//	var items = [] //Create a Javascript array as such.
	//newItem() creates a new item object. Parameters are...
	// Item name, item description, health bonus, mana bonus, cost
//	items[0] = newItem("Bottle of Mead", "A tasty, tasty bottle of mead.", 100, 30, 10)
//	store(player, items) // Pushes on a store state. Parameters are the player and an array of items.
//})

//addNPE(wormStore)

//var spirits = []
//spirits[0] = newItem("Spirit's Spirit", "An aged bottle of wine.", 20, 20, 10)

var ghost = newEnemy("ghostie", "Ghost of Doom", 50, 7, 1, 1, 10, null)
var pauper = newEnemy("snake", "Pauper of Evil", 80, 7, 1, 1, 15, null)
//var spirit = newEnemy("ghostie", "Spirit", 85, 5, 1, 2, 17, spirit[])
addRandomEncounter(ghost) //Adds a random encounter to the room
addRandomEncounter(pauper)
//addRandomEncoutner(spirit)
