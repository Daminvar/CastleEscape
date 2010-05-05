
name("Royal Study")
mapfile("bedroom4.tmx")
battleTexture("test-battle-background")

east("bedroom3.js")

var librarian = newNPE()
librarian.SetTexture("librarian")
librarian.SetPosition(6, 3)

librarian.SetInteractFunc(function(player) {
	if (!getFlag("defeated-librarian-and-got-pendant")) {
		dialogue("Head Librarian: I remember you! You're that thief who tried to rob the castle of its precious treasures! Your life is mine, scum!|Jordan: Damn it!|Ludovic: <He doesn't look like he'd be able to do all that much to you. Take him out quickly so he doesn't have time to call for backup.>")
		var enemy = newEnemy("test-npe", "Head Librarian", 500, 30, 1, 1, 1000, null) //TODO
		battle(player, enemy)
		setFlag("defeated-librarian-and-got-pendant")
		dialogue("Head Librarian: Ugh... |Ludovic: <Hm. It looks like you only knocked him out... Hey, he's from House Yalsdred! Take that pendant he's wearing; a sign of nobility will probably help you get to more areas of the castle.>|Jordan: Well, that's as good a plan as any.")
	} else {
		dialogue("Head Librarian: ...|Jordan: I guess he's still knocked out...")
	}
})

addNPE(librarian)