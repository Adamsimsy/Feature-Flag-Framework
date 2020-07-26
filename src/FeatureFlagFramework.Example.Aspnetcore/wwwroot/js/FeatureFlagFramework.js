var featureFlagFramework = {
    evaluate: function (name, defaultValue) {
        var feature = featureFlagFramework.toggleCollection.features.find(el => el.name === name);

        if (feature === undefined) {
            return defaultValue;
        }
        else {
            return feature.enabled;
        }
    },
    getJson : function (url, callback) {
        var xhr = new XMLHttpRequest();
        xhr.open('GET', url, true);
        xhr.responseType = 'json';
        xhr.onload = function () {
            var status = xhr.status;
            if (status === 200) {
                callback(null, xhr.response);
            } else {
                callback(status, xhr.response);
            }
        };
        xhr.send();
    },
    toggleCollection : null
}

featureFlagFramework.getJson('https://jsontoggler.blob.core.windows.net/examples/flags.json',
    function (err, data) {
        if (err !== null) {
            alert('Something went wrong: ' + err);
        } else {
            featureFlagFramework.toggleCollection = data;
        }
    });