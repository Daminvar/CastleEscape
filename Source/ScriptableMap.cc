#include "ScriptableMap.hh"

#include <iostream>
#include <string>
using namespace std;

#include <lua.hpp>
#include <luabind/luabind.hpp>
#include <luabind/object.hpp>

#include "GameData.hh"
#include "NPE.hh"

namespace CastleEscape {

const string MAP_DIRECTORY = "Content/Maps/";
ScriptableMap* self;

ScriptableMap::ScriptableMap() :
	state(lua_open()) {
}

ScriptableMap::~ScriptableMap() {
}

int ScriptableMap::GetMapWidth() {
	return tmxMap.GetMapWidth();
}

int ScriptableMap::GetMapHeight() {
	return tmxMap.GetMapHeight();
}

int ScriptableMap::GetTileSize() {
	return tmxMap.GetTileSize();
}

string ScriptableMap::GetMapName() {
	return mapName;
}

void ScriptableMap::LoadMap(string filename) {
	loadMapAndScript(filename);
}

void ScriptableMap::loadMapAndScript(string filename) {
	scriptFilename = filename;
	parseScriptFile(filename);
	tmxMap.ParseTMXFile(MAP_DIRECTORY + tmxMapFilename);
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
	open(state.get());
	module(state.get())[
	                    def("getFlag", &GameData::GetFlag),
	                    class_<NPE>("NPE")
							.def("SetPosition", &NPE::SetPosition)
							.def("SetTexture", &NPE::SetTexture),
						class_<ScriptableMap>("ScriptableMap")
							.def("test", &ScriptableMap::lua_test)
	                    ];

	object global = globals(state.get());
	global["self"] = this;
	luaL_dofile(state.get(), filename.c_str());
	mapName = object_cast<string>(global["name"]);
	tmxMapFilename = object_cast<string>(global["mapfile"]);
}

void ScriptableMap::lua_test() {
	cout << "Heyo!" << endl;
}

} // namespace CastleEscape
