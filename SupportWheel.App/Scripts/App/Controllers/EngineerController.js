app.controller('engineerController', function ($scope, engineerService) {
    $scope.engineer = {};



    //Function to load all Employee records
    $scope.GetAllData = function () {
        var promiseGet = engineerService.getEngineers(); //The MEthod Call from service

        promiseGet.then(function (pl) { $scope.Engineers = pl.data },
            function (errorPl) {
                $log.error('failure loading Employee', errorPl);
            });
    }
});