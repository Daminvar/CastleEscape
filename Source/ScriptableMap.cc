#include "ScriptableMap.hh"

#include <iostream>
#include <string>
using namespace std;

#include <lua.hpp>
#include "luabind/luabind.hpp"
#include "luabind/object.hpp"

#include "GameData.hh"
#include "NPE.hh"

namespace CastleEscape {

const string MAP_DIRECTORY = "Content/Maps/";
ScriptableMap* self;

ScriptableMap::ScriptableMap() :
	state_(lua_open()) {
}

ScriptableMap::~ScriptableMap() {
}

int ScriptableMap::GetMapWidth() {
	return tmxMap_.GetMapWidth();
}

int ScriptableMap::GetMapHeight() {
	return tmxMap_.GetMapHeight();
}

int ScriptableMap::GetTileSize() {
	return tmxMap_.GetTileSize();
}

string ScriptableMap::GetMapName() {
	return mapName_;
}

void ScriptableMap::LoadMap(string filename) {
	loadMapAndScript(filename);
}

void ScriptableMap::loadMapAndScript(string filename) {
	scriptFilename_ = filename;
	parseScriptFile(filename);
	tmxMap_.ParseTMXFile(MAP_DIRECTORY + tmxMapFilename_);
}

void ScriptableMap::ReloadMap() {
	//TODO
}

bool ScriptableMap::ChangeMap(Directions direction) {
	//TODO
	return false;
}

void ScriptableMap::parseScriptFile(string filename) {
	using namespace luabind;
	open(state_.get());
	module(state_.get()) [
		def("getFlag", &GameData::GetFlag),
		class_<NPE>("NPE")
			.def(constructor<>())
			.def("SetPosition", &NPE::SetPosition)
			.def("SetTexture", &NPE::SetTexture),
		class_<ScriptableMap>("ScriptableMap")
			.def("addNPE", &ScriptableMap::addNPE)
	];
	object global = globals(state_.get());
	global["self"] = this;
	luaL_dofile(state_.get(), filename.c_str());
	mapName_ = object_cast<string>(global["name"]);
	tmxMapFilename_ = object_cast<string>(global["mapfile"]);
}

void ScriptableMap::addNPE(NPE* npe) {
	NPEs_.push_back(npe);
}

} // namespace CastleEscape
