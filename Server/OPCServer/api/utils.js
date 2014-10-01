var MongoClient = require('mongodb').MongoClient;
var assert = require('assert');

exports.getObjectWithoutId = function (object) {
    if (!object) {
        return null;
    }
    
    var result = {};
    
    for (var propName in object) {
        if (propName === "Id") {
            continue;
        }
        
        if (object.hasOwnProperty(propName)) {
            result[propName] = object[propName];
        }
    }
    
    return result;
}