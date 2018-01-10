app.service("shiftService", function ($http) {
    this.getShifts = function () {
        return $http.get("/api/WheelApi/GetRules");
    }
});