#include "ScriptableMap.hh"

#include <iostream>
#include <string>
using namespace std;

#include <lua.hpp>
#include <luabind/luabind.hpp>

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
	self = this;
	using namespace luabind;
	open(state.get());
	module(state.get())[
	                    def("name", &ScriptableMap::js_name),
	                    def("mapfile", &ScriptableMap::js_mapfile)

	                    ];
	luaL_dofile(state.get(), filename.c_str());
}

void ScriptableMap::js_name(string name) {
	cout << "Name: " << name << endl;
	self->mapName = name;
}

void ScriptableMap::js_mapfile(string mapfile) {
	cout << "Mapfile: " << mapfile << endl;
	self->tmxMapFilename = mapfile;
}

} // namespace CastleEscape
