
name("Children's Room")
mapfile("bedroom2.tmx")
battleTexture("test-battle-background") //TODO

east("bedroom1.js")
south("bedroom3.js")

var lillina = newNPE()
lillina.SetTexture("lady_front")
lillina.SetPosition(13, 3)

lillina.SetInteractFunc(function(player) {
	if (!getFlag("defeated-lillina-guard")) {
		dialogue("Lillina: What the god-damn hell are you doing in our rooms? I am the princess you know. P-R-I-N-C-E-S-S! As in, I can have you beheaded at any time! Now get out before my mood worsens!|Ludovic: <Kill her>|Jordan: Quiet you!|Lillina: What did you say to me?|Jordan: Ah, damn it.|Lillina: Guards!")
		setFlag("lillina-guard-attack")
		reloadMap()
		dialogue("Guard: How dare you threaten the princess. Die scum!")
		//TODO: Change sprite and stats
		var guard = newEnemy("test-npe", "Royal Guard", 100, 70, 1, 1, 10, null)
		battle(player, guard)
		setFlag("defeated-lillina-guard")
		reloadMap()
		dialogue("Lillina: Please don't kill me, I'll do anything!|Jordan: Er... I'll just go...") // TODO: Possible story event
	} else {
		dialogue("Lillina: Please don't kill me!")
	}
})

addNPE(lillina)

if (getFlag("lillina-guard-attack") && !getFlag("defeated-lillina-guard")) {
	var tempGuard = newNPE()
	tempGuard.SetTexture("guard-back")
	tempGuard.SetPosition(13, 5)
	addNPE(tempGuard)
}

var sign = newNPE()
sign.SetPosition(5, 2)

sign.SetInteractFunc(function(player) {
	dialogue("Don't play with the candles kids ~ The King")
})

addNPE(sign)

var essay = newNPE()
essay.SetPosition(8, 8)

essay.SetInteractFunc(function(player) {
	dialogue("It looks like an essay that one of the children started writing.")
})

addNPE(essay)
