
name("Test Map 1")
mapfile("testmap.tmx")

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
		dialogue("Hi, it's nice to meet you.")
		setFlag("talked-to-bob")
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

addRandomEncounter("ghostie", "Ghost of Doom", 500, 50, 50, 10, 10, null)
addRandomEncounter("ghostie", "Pauper of Evil", 800, 50, 50, 10, 10, null)
