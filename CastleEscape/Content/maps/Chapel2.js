name("Chapel")
mapfile("Chapel2.tmx")
battleTexture("test-battle-background")

west("Chapel1.js")

var priest= newNPE()
priest.SetTexture("waiter_front")

priest.SetPosition(3,3)

priest.SetInteractFunc(function(player){
	if(!getFlag("winston-first-talk"))
	{
	dialogue("Priest Winston: Welcome!|Have you come to take part in today's services or something else?|Jordan: I need to get to the armory.|Priest Windston: If you really want to go there, I guess I can give you a special item to pass the guard.|However, you'll have to answer a question first.|Which king saved Euphor from dire peril with his diplomatic skills?")
	setFlag("winston-first-talk")
	}
	else if(!getFlag("holy-water"))
		dialogue("Any luck with finding out which king saved Euphor from dire peril with his diplomatic skills?")
		
else{
		dialogue("Priest Winston: Make good use of that holy water!")
		return
	}
	if(getFlag("pierre-grave-read"))
	{
		dialogue("Jordan:  That was King Pierre, who saved Euphor during dark times. |Priest Winston: Why yes! You seem to be well versed in Euphor's history. Have this holy water as a reward!")
		setFlag("holy-water")
	}
	else	
		dialogue("Jordan: I have no idea.|Priest Winston: Come back when you have paid your respects for the dead.")

})
	

addNPE(priest)

var churchgoer21 = newNPE()
churchgoer21.SetTexture("bGuard-back")

churchgoer21.SetPosition(2,9)

churchgoer21.SetInteractFunc(function(player){
	dialogue("Anthony: Mind your manners in church!")
})
	
addNPE(churchgoer21)

var churchgoer22 = newNPE()
churchgoer22.SetTexture("bGuard-back")

churchgoer22.SetPosition(14,4)

churchgoer22.SetInteractFunc(function(player){
	dialogue("Tyler: Those books on the shelves over there are some of the oldest books I've ever seen. |Jordan: Do any of them even have any useful information in them? |Tyler: EXCUSE ME? Those books are the priest's books! Show some respect, boy.")
})
	

addNPE(churchgoer22)


