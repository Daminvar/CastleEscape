
name("Test Map 1")
mapfile("testmap.tmx")
battleTexture("test-battle-background")

east("testmap2.js")

var bob = newNPE()
bob.SetTexture("test-npe")

if (getFlag("talked-to-bob")) {
	bob.SetPosition(5, 5)
} else {
	bob.SetPosition(12, 11)
}

bob.SetInteractFunc(function(player) {
	if (getFlag("talked-to-bob")) {
		dialogue("I have nothing more to say to you.")
	} else {
		dialogue("Hi, it's nice to meet you. Let's fight!")
		var enemy = newEnemy("test-npe", "Bob: The Monarch of Entropy", 50000, 70, 1, 1, 10, null)
		battle(player, enemy)
		setFlag("talked-to-bob")
		reloadMap()
	}
})

addNPE(bob)

var saveOrb = newNPE()
saveOrb.SetTexture("orb-of-saving")
saveOrb.SetPosition(1, 8)

saveOrb.SetInteractFunc(function(player) {
	save(player)
	dialogue("Game has been saved.")
})

addNPE(saveOrb)

var wormStore = newNPE()
wormStore.SetTexture("snake")
wormStore.SetPosition(15, 1)

wormStore.SetInteractFunc(function(player) {
	var items = []
	items[0] = newItem("Bottle of Mead", "A tasty, tasty bottle of mead.", 100, 30, 10)
	store(player, items)
})

addNPE(wormStore)

var ghost = newEnemy("ghostie", "Ghost of Doom", 50, 7, 1, 1, 10, null) //texture, name, health, atk, def, speed, exp, items
var pauper = newEnemy("snake", "Pauper of Evil", 80, 5, 1, 1, 10, null)
addRandomEncounter(ghost) 
addRandomEncounter(pauper)
