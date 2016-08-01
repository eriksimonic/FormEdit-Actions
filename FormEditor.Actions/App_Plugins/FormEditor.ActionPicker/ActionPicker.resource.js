angular.module('umbraco.resources').factory('actionspickerResource',
function ($q, $http) {
    //the factory object returned
    return {
        //this cals the Api Controller we setup earlier
        getAll: function (selected) {
            return $http.get("backoffice/Api/FormEditorActionApi/GetRegisteredActions", {
                //params: { defaultArea: "asdasd" }
            });
        }
    };
}
);