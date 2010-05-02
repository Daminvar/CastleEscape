name("Graveyard")
mapfile("Graveyard1.tmx")
battleTexture("test-battle-background")

north("Chapel1.js")
south("Courtyard2.js")
east("Graveyard2.js")

var axelle = newNPE()
axelle.SetTexture("witch-down")
axelle.SetPosition(9, 2)

axelle.SetInteractFunc(function(player) {
	if (!getFlag("aura-hidden")) {
		dialogue("Axelle: Possessed, aren't you? You have a demonic aura... I don't know who you are, but I'd advise that you leave the castle. The priests don't take kindly to the possessed, and neither do the guards.|Jordan: I've been trying to get out of here for ages! There are guards nearly everywhere around here.|Axelle: Too bad about that. I'll not inquire as to why you're here. Messing in demon affairs is certainly not for me. However, if you're looking to get into the chapel, I'll give you a bit of help.|*Fwoosh*|Axelle: There, I masked your aura. The priests shouldn't be able to sense that you're possessed.|Jordan: Er, thanks.|Axelle: Don't mention it. Now get away, I hate being around the possessed.|Ludovic: <Well, we can get into the chapel now, I suppose. I'm not sure if there's an exit there, however. This castle looks like it's been designed by a drunken Escher.>")
		setFlag("aura-hidden")
	} else {
		dialogue("Axelle: Shoo! Your presence is disturbing the aether streams.")
	}
})

addNPE(axelle)