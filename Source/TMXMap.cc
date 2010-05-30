#include "TMXMap.hh"

#include <stdexcept>
#include <string>
#include <vector>
using namespace std;

#include <boost/format.hpp>
#include "tinyxml/tinyxml.h"
using boost::format;

namespace CastleEscape {

const string ERROR_STRING = "Error: Could not load the map %1%\n";

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
	if (!map.ToElement()) {
		format error = format(ERROR_STRING
				+ "Reason: Could not find the <map> element.") % filename;
		throw runtime_error(error.str());
	}

	int errorCode = map.ToElement()->QueryIntAttribute("width", &mapWidth);
	errorCode = errorCode != TIXML_SUCCESS ? errorCode
			: map.ToElement()->QueryIntAttribute("height", &mapHeight);
	errorCode = errorCode != TIXML_SUCCESS ? errorCode
			: map.ToElement()->QueryIntAttribute("tilewidth", &tilesize);

	if (errorCode != TIXML_SUCCESS) {
		format error = format(ERROR_STRING
			+ "Reason: The <map> element doesn't have the required attributes.") % filename;
		throw runtime_error(error.str());
	}

	baseLayers.clear();
	topLayers.clear();
	collisionRects.clear();

	TiXmlElement* layers =
			handle.FirstChild("map").FirstChild("layer").ToElement();
	if (!layers) {
		format error = format(ERROR_STRING + "Reason: The map has no layers.") % filename;
		throw runtime_error(error.str());
	}
	for (; layers; layers = layers->NextSiblingElement()) {
		string name = layers->Attribute("name") != NULL ?
				layers->Attribute("name") : "";
		if (name.empty()) {
			format error = format(ERROR_STRING
					+ "Reason: A map layer has no name.") % filename;
			throw runtime_error(error.str());
		}
		TiXmlNode* layerData = layers->FirstChild();
		if (layerData == NULL) {
			format error = format(ERROR_STRING
				+ "Reason: A layer doesn't have a <data> child.") % filename;
			throw runtime_error(error.str());
		}
		if (name == "base")
			baseLayers.push_back(parseLayer(layerData));
		else if (name == "top")
			topLayers.push_back(parseLayer(layerData));
		else if (layers->ValueStr() != "objectgroup") {
			format error = format(ERROR_STRING
				+ "Reason: A layer has an invalid name (%2%).") % filename % name;
			throw runtime_error(error.str());
		}
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
