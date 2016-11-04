var App = App || {};
(function () {

    var appLocalizationSource = abp.localization.getSource('TAOKE');
    App.localize = function () {
        return appLocalizationSource.apply(this, arguments);
    };

})(App);