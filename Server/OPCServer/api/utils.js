exports.getConnectionString = function () {
    return "mongodb://localhost:27017/opc";
}

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
