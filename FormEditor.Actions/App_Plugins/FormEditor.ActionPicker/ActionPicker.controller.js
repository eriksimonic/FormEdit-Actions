angular.module("umbraco").controller("ActionsPicker.controller",
function ($scope, $log, actionspickerResource) {
    actionspickerResource.getAll($scope.model.config.area).then(function (response) {
        $scope.areas = response.data;
    });
    $scope.saveActionsPicker = function () {
        $scope.model.value = $scope.actionspickerArea;
    };
});