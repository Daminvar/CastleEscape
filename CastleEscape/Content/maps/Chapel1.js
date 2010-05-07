name("Chapel")
mapfile("Chapel1.tmx")
battleTexture("test-battle-background")

east("Chapel2.js")
south("Graveyard1.js")

var churchgoer1 = newNPE()
churchgoer1.SetTexture("man_left")

churchgoer1.SetPosition(14,11)

churchgoer1.SetInteractFunc(function(player){
	dialogue("Matt: Church is the place to be when you need some holiness in your day! |Jordan: Sorry, I don't need that right now.")
})
	
addNPE(churchgoer1)

var saveOrb = newNPE()
saveOrb.SetTexture("orb-of-saving")
saveOrb.SetPosition(1, 2)

saveOrb.SetInteractFunc(function(player) {
	save(player) // Saves the game. Try to use this function only with the orb of saving.
	dialogue("Game has been saved.")
})

addNPE(saveOrb)

var churchgoer2 = newNPE()
churchgoer2.SetTexture("lady_front")

churchgoer2.SetPosition(7,12)

if(getFlag("aura-hidden"))
{
	churchgoer2.SetInteractFunc(function(player){
	dialogue("Ally: Enjoy your time in the Lord's House.")
	})
}
else
{
	churchgoer2.SetInteractFunc(function(player){
	dialogue("Ally: You're looking a bit pale... You should not enter in your current condition.")
	})
}
	
addNPE(churchgoer2)

var churchgoer3 = newNPE()
churchgoer3.SetTexture("guyHat-front")

churchgoer3.SetPosition(7,2)

churchgoer3.SetInteractFunc(function(player){
	dialogue("Disciple Eric: Some say you can solve problems just by visiting the church and talking to a priest...|Jordan: Great! Do you know where I could find one? |Disciple Eric: Priest Winston is over on the other side of the church, by the priest's table.")
})
	
addNPE(churchgoer3)

var churchgoer4 = newNPE()

if(getFlag("aura-hidden"))
{
	churchgoer4.SetTexture("guard1_left")

	churchgoer4.SetPosition(14,5)

	churchgoer4.SetInteractFunc(function(player){
		dialogue("Jordan: Excuse me, do you know where to find someone who can help me around here? |Dennis: Can't you see I'm busy? Bother somebody else.")
	})
}
else
{
	churchgoer4.SetTexture("guard1_front")
	churchgoer4.SetPosition(6,12)
	churchgoer4.SetInteractFunc(function(player){
	dialogue("Dennis: You're giving off a strange... aura, boy. Go purify yourself before you enter the Lord's house.")
	})
}

addNPE(churchgoer4)

if(!getFlag("aura-hidden"))
{
	var churchgoer5 = newNPE()
	churchgoer5.SetTexture("bGuard-front")
	churchgoer5.SetPosition(5,12)
	churchgoer5.SetInteractFunc(function(player){
		dialogue("Anthony: You are not welcome here.")
	} )
	addNPE(churchgoer5)
}