var featureFlagFramework = {
    evaluate: function (name, defaultValue) {
        if (featureFlagFramework.initialized === false) {
            featureFlagFramework.initialize() //TODO lazy load flags correctly.

            if (featureFlagFramework.toggleCollection === null) {
                return defaultValue;
            }
        }

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
    initialize: function () {
        featureFlagFramework.getEndpointFromDataAttribute();
        featureFlagFramework.getJson(featureFlagFramework.endpoint,
            function (err, data) {
                if (err !== null) {
                    alert('Something went wrong: ' + err);
                } else {
                    featureFlagFramework.toggleCollection = data;
                    featureFlagFramework.initialized = true;
                }
            });
    },
    getEndpointFromDataAttribute: function () {
        var this_js_script = $('script[src*=FeatureFlagFramework]');
        featureFlagFramework.endpoint = this_js_script.attr('data-endpoint');
    },
    endpoint : null,
    initialized : false,
    toggleCollection : null
}
featureFlagFramework.initialize();