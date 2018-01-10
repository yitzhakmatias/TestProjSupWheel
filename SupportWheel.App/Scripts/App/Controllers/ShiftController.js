app.controller('shiftController', function ($scope, shiftService) {
    $scope.shift = {};

    //Function to load all Shifts records
    $scope.GetAllData = function () {
        var promiseGet = shiftService.getShifts(); //The MEthod Call from service

        promiseGet.then(function (pl) { $scope.Shifts = pl.data },
            function (errorPl) {
                $log.error('failure loading Shifts', errorPl);
            });
    }
});