#include "TMXMap.hh"

#include <string>
#include <vector>
using namespace std;

#include "tinyxml/tinyxml.h"

namespace CastleEscape {

TMXMap::TMXMap() {
	//TODO: Constructor
}

const MapVector& TMXMap::GetBaseLayers() {
	return baseLayers;
}

const MapVector& TMXMap::GetTopLayers() {
	return topLayers;
}

int TMXMap::GetMapWidth() {
	return mapWidth;
}

int TMXMap::GetMapHeight() {
	return mapHeight;
}

int TMXMap::GetTileSize() {
	return tilesize;
}

void TMXMap::ParseTMXFile(string filename) {
	TiXmlDocument doc(filename);
	doc.LoadFile();
	TiXmlHandle handle(&doc);

	TiXmlHandle map = handle.FirstChild("map");
	map.ToElement()->QueryIntAttribute("width", &mapWidth);
	map.ToElement()->QueryIntAttribute("height", &mapHeight);
	map.ToElement()->QueryIntAttribute("tilewidth", &tilesize);

	baseLayers.clear();
	topLayers.clear();
	collisionRects.clear();

	TiXmlElement* layers = handle.FirstChild("map").FirstChild("layer").ToElement();
	for (; layers; layers = layers->NextSiblingElement()) {
		string name = layers->Attribute("name");
		TiXmlNode* layerData = layers->FirstChild();
		if (name == "base")
			baseLayers.push_back(parseLayer(layerData));
		else if (name == "top")
			topLayers.push_back(parseLayer(layerData));
	}
	//TODO: Get collision data
}

LayerVector TMXMap::parseLayer(TiXmlNode* node) {
	LayerVector layer;
	layer.resize(mapHeight);
	TiXmlElement* curTile = node->FirstChild()->ToElement();
	for (int i = 0; i < layer.size(); i++) {
		layer[i].resize(mapWidth);
		for (int j = 0; j < layer[i].size(); j++) {
			curTile->QueryIntAttribute("gid", &layer[i][j]);
			layer[i][j]--;
			curTile = curTile->NextSiblingElement();
		}
	}
	return layer;
}

bool TMXMap::IsCollisionAt(int x, int y) {
	//TODO
	return false;
}

} // namespace CastleEscape
