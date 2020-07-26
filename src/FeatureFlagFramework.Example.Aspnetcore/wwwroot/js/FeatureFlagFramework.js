var featureFlagFramework = {
    evaluate: function (name, defaultValue) {
        if (featureFlagFramework.initialized === false) {
            featureFlagFramework.attemptInitializeWithDataAttribute() //TODO lazy load flags correctly.

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
    on: async function (awaiting, scopedFunction) {
        if (awaiting === 'ready') {
            await featureFlagFramework.isReady();
        }        
        scopedFunction();
    },
    isReady: async function () {
        while (featureFlagFramework.initialized === false) { await featureFlagFramework.sleep(100); };
    },
    sleep:function (ms) {
        return new Promise(resolve => setTimeout(resolve, ms));
    },
    attemptInitializeWithDataAttribute: function () {
        featureFlagFramework.getEndpointFromDataAttribute();
        featureFlagFramework.initialize(featureFlagFramework.endpoint);
    },
    initialize: function (url) {
        //TODO: Store flags for configured timespan in browser to improve performance instead of requesting json with every page load.
        featureFlagFramework.getJson(url,
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
        var this_js_script = $('script[src*=FeatureFlagFramework]'); //TODO avoid needing JQuery
        featureFlagFramework.endpoint = this_js_script.attr('data-endpoint'); //TODO add console logs if not able to get data attribute.
    },
    endpoint : null,
    initialized : false,
    toggleCollection : null
}
featureFlagFramework.attemptInitializeWithDataAttribute();