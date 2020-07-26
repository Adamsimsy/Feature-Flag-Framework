// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

featureFlagFramework.on('ready', function () {
    console.log("It's now safe to request feature flags");
    if (featureFlagFramework.evaluate('example-feature-flag', false)) {
        document.getElementById("flag-js").innerHTML = "True";
    }
    else {
        document.getElementById("flag-js").innerHTML = "False";
    }
});