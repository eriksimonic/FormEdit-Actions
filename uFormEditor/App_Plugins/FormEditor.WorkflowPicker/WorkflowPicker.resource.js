angular.module('umbraco.resources').factory('workflowpickerResource',
function ($q, $http) {
    //the factory object returned
    return {
        //this cals the Api Controller we setup earlier
        getAll: function (selected) {
            return $http.get("backoffice/Api/FormEditorWorkflowApi/GetRegisteredWorkflows", {
                //params: { defaultArea: "asdasd" }
            });
        }
    };
}
);