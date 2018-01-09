app.service("engineerService", function($http) {
    this.getEngineers = function () {
        return $http.get("/api/EngineerAPI");
    }
});