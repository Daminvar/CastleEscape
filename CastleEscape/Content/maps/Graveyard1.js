name("Graveyard")
mapfile("Graveyard1.tmx")
overworldMusic("graveyard-song")
randomBattleMusic("regular-battle-song")
battleTexture("graveyard-bg")

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

var grave1 = newNPE()
grave1.SetPosition(4, 8)

grave1.SetInteractFunc(function(player) {
	dialogue("Here lies Eugene Nason, who died after attempting to drink fifteen bottles of mead in ten minutes...")
})

addNPE(grave1)

var grave2 = newNPE()
grave2.SetPosition(6, 9)

grave2.SetInteractFunc(function(player) {
	dialogue("Here lies Raphael Marchand, who died in a freak penguin attack. He will always be missed.")
})

addNPE(grave2)

var grave3 = newNPE()
grave3.SetPosition(7, 8)

grave3.SetInteractFunc(function(player) {
	dialogue("Here lies Maxime Lesueur. His death was mostly uneventful...")
})

addNPE(grave3)

var grave4 = newNPE()
grave4.SetPosition(12, 7)

grave4.SetInteractFunc(function(player) {
	dialogue("Here lies Pascal Jacquemin. A true gentleman in both manner and spirit.")
})

addNPE(grave4)

var grave5 = newNPE()
grave5.SetPosition(14, 7)

grave5.SetInteractFunc(function(player) {
	dialogue("HELP, I'M TRAPPED IN A GRAVE CARVING FACTORY!")
})

addNPE(grave5)

var grave6 = newNPE()
grave6.SetPosition(12, 3)

grave6.SetInteractFunc(function(player) {
	dialogue("Here lies Dion Jaillet, who died from injuries after single-handedly defeating eight assassins from the kingdom of Orrz.")
})

addNPE(grave6)

var grave7 = newNPE()
grave7.SetPosition(13, 3)

grave7.SetInteractFunc(function(player) {
	dialogue("Here lies Dion Jaillet's testicles, which were too large to fit in a single casket.")
})

addNPE(grave7)

function fadedGrave(player) {
	dialogue("The text is too faded to read.")
}

var grave8 = newNPE()
grave8.SetPosition(16, 2)
grave8.SetInteractFunc(fadedGrave)
addNPE(grave8)

var grave9 = newNPE()
grave9.SetPosition(17, 9)
grave9.SetInteractFunc(fadedGrave)
addNPE(grave9)

var grave10 = newNPE()
grave10.SetPosition(18, 3)
grave10.SetInteractFunc(fadedGrave)
addNPE(grave10)