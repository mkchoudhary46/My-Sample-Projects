spicyApp.controller('SpicyController', ['$scope', 'notifyService', function ($scope, notifyService) {
    $scope.spice = 'very';

    $scope.chiliSpicy = function () {
        $scope.spice = 'chili';
    };

    $scope.jalapenoSpicy = function () {
        $scope.spice = 'jalapeño';
    };

    $scope.callNotify= function(msg) {
        notifyService(msg);
    }
}]);