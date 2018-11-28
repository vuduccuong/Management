(function (app) {
    app.controller('seatCarController', seatCarController);

    seatCarController.$inject = ['$scope', 'apiService', '$state', '$stateParams','notificationService', '$ngBootbox', 'authData'];

    function seatCarController($scope, apiService, $state, $stateParams, notificationService, $ngBootbox, authData) {
        
        $scope.seatStatus = [];
        $scope.getSeatStatus = getSeatStatus;
        var id = $stateParams.id;
        function getSeatStatus() {
            var config = {
                params: {
                    id: id,
                    dateBook: '11/28/2018'
                }
            };
            apiService.get('api/seat/getseatstatus?id=' + config.params.id + '&dateBook=' + config.params.dateBook,null, function (result) {
                console.log(result)
                //$scope.seatStatus = result.data;
                binData(result.data);
            }, function () {
                console.log("Oopz..");
            }
            )
        };

        function binData(item) {
            var html1 = item[0].NameCar;
            $('#nameCar').append(html1);
            var html = "";
            var check1 = "";
            var check2 = "";
            var check3 = "";
            var check4 = "";
            var check5 = "";
            for (var i = 0; i < item.length; i++) {
                if (item[i].row1 == 1) {
                    check1 = "checked";
                }
                if (item[i].row1 == 0) {
                    check1 = "";
                }

                if (item[i].row2 == 1) {
                    check2 = "checked";
                }
                if (item[i].row2 == 0) {
                    check2 = "";
                }

                if (item[i].row3 == 1) {
                    check3 = "checked";
                }
                if (item[i].row3 == 0) {
                    check3 = "";
                }

                if (item[i].row4 == 1) {
                    check4 = "checked";
                }
                if (item[i].row4 == 0) {
                    check4 = "";
                }

                if (item[i].row5 == 1) {
                    check5 = "checked";
                }
                if (item[i].row5==null) {
                    check5 = "hidden";
                }
                if (item[i].row5 == 0) {
                    check5 = "";
                }



                html += "<tr>";
                html += "<td>" + item[i].Row + "</td>";
                //html += "<td><div class='form - group'>< div class='' ><div class='checkbox checkbox - custom'><input id='checkbox11' type='checkbox' ng-checked='" + item[i].row1 + "'></div></div ></div ></td>";
                html += "<td><input id='checkbox11' type='checkbox' type='checkbox' value='1' " + check1 + " ng-model='" + item[i].row1 +"'></td>";
                html += "<td><input id='checkbox11' type='checkbox' type='checkbox' value='2' " + check2 + " ng-model='" + item[i].row2 +"'></td>";
                html += "<td><input id='checkbox11' type='checkbox' type='checkbox' value='3' " + check3 + " ng-model='" + item[i].row3 +"'></td>";
                html += "<td><input id='checkbox11' type='checkbox' type='checkbox' value='4' " + check4 + " ng-model='" + item[i].row4 +"'></td>";
                html += "<td><input id='checkbox11' type='checkbox' type='checkbox' value='5' " + check5 + " ng-model='" + item[i].row5 +"'></td>";

                check = "";
            }
            $('#tblData').append(html);
        }
        getSeatStatus();
    }
})(angular.module('management.seats'));