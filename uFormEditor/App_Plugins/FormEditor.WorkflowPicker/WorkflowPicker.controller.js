angular.module("umbraco").controller("WorkflowPicker.controller",
function ($scope, $log, workflowpickerResource) {
    workflowpickerResource.getAll($scope.model.config.area).then(function (response) {
        $scope.areas = response.data;
    });
    $scope.saveWorkflowPicker = function () {
        $scope.model.value = $scope.workflowpickerArea;
    };
});